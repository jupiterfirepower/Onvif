using System.Configuration;
using Onvif.Contracts.Constants;

namespace Onvif.Camera.Client.Settings
{
    public static class ClientAppSettings
    {
        private static string _server = "localhost";
        private static int _port = 8090;
        private static int _serverPort = 8080;
        private static string _localHost = "localhost";

        public static string Server { get { return _server; } }

        public static string LocalHost { get { return _localHost; } }

        public static int LocalPort { get { return _port; } }

        public static int ServerPort { get { return _serverPort; } }


        static ClientAppSettings()
        {
            InitParametersFromAppConfig();
        }

        private static void InitParametersFromAppConfig()
        {
            var server = ConfigurationManager.AppSettings[Constant.AkkaRemoteServerAppKey];
            _server = !string.IsNullOrEmpty(server) ? server : _server;

            var serverPort = ConfigurationManager.AppSettings[Constant.AkkaRemoteServerPortAppKey];
            if (!string.IsNullOrEmpty(serverPort))
            {
                int.TryParse(serverPort, out _serverPort);
            }

            var port = ConfigurationManager.AppSettings[Constant.AkkaHeliosLocalPortAppKey];
            if (!string.IsNullOrEmpty(port))
            {
                int.TryParse(port, out _port);
            }
        }
    }
}
