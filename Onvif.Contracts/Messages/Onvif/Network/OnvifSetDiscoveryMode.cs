using onvif.services;

namespace Onvif.Contracts.Messages.Onvif.Network
{
    public class OnvifSetDiscoveryMode : OnvifBase
    {
        public DiscoveryMode DiscoveryMode { get; private set; }

        public OnvifSetDiscoveryMode(string uri, string userName, string password, DiscoveryMode discoveryMode)
            : base(uri, userName, password)
        {
            DiscoveryMode = discoveryMode;
        }
    }
}
