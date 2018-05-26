using System;
using System.Net;
using System.Threading.Tasks;
using onvif.services;
using Onvif.Contracts.Constants;
using Onvif.Contracts.Messages.Onvif;
using Onvif.Contracts.Messages.Onvif.Metadata;

namespace Onvif.Client
{
    public partial class OnvifClient : IOnvifClient
    {
        #region Private Fields
        private readonly string _userName;
        private readonly string _password;
        private readonly string _url;
        #endregion

        #region Constructors
        public OnvifClient(string userName, string password, string url)
        {
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

        public void Dispose()
        {
        }

        #region Facade Public Methods
       /* public async Task<OnvifResult> SetMetadataConfigurationAsync(MetadataConfiguration metaCfg)
        {
            //return await _proxyActor.Ask<OnvifResult>(new OnvifSetMetadataConfiguration(_url, _userName, _password, metaCfg));
        }

        public OnvifResult SetMetadataConfiguration(MetadataConfiguration metaCfg)
        {
            //return _proxyActor.Ask<OnvifResult>(new OnvifSetMetadataConfiguration(_url, _userName, _password, metaCfg)).Result;
        }*/
        #endregion

    }
}
