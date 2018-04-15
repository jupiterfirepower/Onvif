using System;
using System.Net;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.Configuration;
using Akka.Routing;
using onvif.services;
using Onvif.Camera.Client.Actors;
using Onvif.Camera.Client.Settings;
using Onvif.Contracts.Constants;
using Onvif.Contracts.Messages.Onvif;
using Onvif.Contracts.Messages.Onvif.Metadata;

namespace Onvif.Camera.Client
{
    public partial class OnvifClient : IOnvifClient
    {
        #region Private Fields
        private const string ActorSystemName = Constant.OnvifClientActorSystem;
        private ActorSystem _actorClientSystem;
        private IActorRef _proxyActor;
        private readonly string _userName;
        private readonly string _password;
        private readonly string _url;
        private Akka.Configuration.Config _config;
        #endregion

        #region Constructors
        public OnvifClient(string userName, string password, string url)
        {
            InitConfig();
            InitActorProxyPool();
            _userName = userName;
            _password = password;
            _url = url;
        }

        public OnvifClient(NetworkCredential networkCredential, string url)
            : this(networkCredential.UserName, networkCredential.Password, url)
        {
        }

        public OnvifClient(NetworkCredential networkCredential, Uri uri)
            : this(networkCredential.UserName, networkCredential.Password, uri.AbsolutePath)
        {
        }

        public OnvifClient(string userName, string password, Uri uri)
            : this(userName, password, uri.AbsolutePath)
        {
        }
        #endregion

        protected void InitConfig()
        {
            var hoconTemplate = @"
akka {
              loggers = [""Akka.Logger.NLog.NLogLogger,Akka.Logger.NLog""] 
              stdout-loglevel = DEBUG
              loglevel = DEBUG
              log-config-on-start = on
              log-dead-letters = on
              log-dead-letters-during-shutdown = on
              actor
              {
                    provider = ""Akka.Remote.RemoteActorRefProvider, Akka.Remote""
                  
                    debug 
                    {
                      # enable function of LoggingReceive, which is to log any received message at
                      # DEBUG level
                      unhandled = on
                      receive = on
                      lifecycle = on
                      fsm = on
                    }

                    ask-timeout = 15s
              }

            remote {
                        log-sent-messages = on
                        log-received-messages = on
                        helios.tcp {
                                      #transport-class = ""Akka.Remote.Transport.Helios.HeliosTcpTransport, Akka.Remote""
                                      #applied-adapters = []
                                      #transport-protocol = tcp
                                      port = #Port#
                                      hostname = #Server#
                                   }
                      }
            }
           }";
            var hocon = hoconTemplate.
                Replace(Constant.ServerKey, ClientAppSettings.LocalHost).
                Replace(Constant.ServerPortKey, Convert.ToString(ClientAppSettings.LocalPort));
            _config = ConfigurationFactory.ParseString(hocon);
        }

        private void InitActorProxyPool()
        {
            _actorClientSystem = _config != null ? ActorSystem.Create(ActorSystemName, _config) : ActorSystem.Create(ActorSystemName);
            _proxyActor = _actorClientSystem.ActorOf(Props.Create(() => new OnvifProxyWorkerActor()).WithRouter((new RoundRobinPool(10, new DefaultResizer(5, 20)))));
        }

        public void Dispose()
        {
            _actorClientSystem?.Dispose();
        }

        #region Facade Public Methods
        public async Task<OnvifResult> SetMetadataConfigurationAsync(MetadataConfiguration metaCfg)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifSetMetadataConfiguration(_url, _userName, _password, metaCfg));
        }

        public OnvifResult SetMetadataConfiguration(MetadataConfiguration metaCfg)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifSetMetadataConfiguration(_url, _userName, _password, metaCfg)).Result;
        }
        #endregion

        
    }
}
