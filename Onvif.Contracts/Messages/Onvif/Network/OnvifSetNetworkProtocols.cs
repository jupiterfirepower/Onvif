using onvif.services;

namespace Onvif.Contracts.Messages.Onvif.Network
{
    public class OnvifSetNetworkProtocols : OnvifBase
    {
        public NetworkProtocol[] NetworkProtocols { get; private set; }

        public OnvifSetNetworkProtocols(string uri, string userName, string password, NetworkProtocol[] networkProtocols)
            : base(uri, userName, password)
        {
            NetworkProtocols = networkProtocols;
        }
    }
}
