using Onvif.Contracts.Model;

namespace Onvif.Contracts.Messages.Onvif.Network
{
    public class OnvifSetNetworkSettings : OnvifBase
    {
        public NetworkSettings NetworkSettings { get; private set; }

        public OnvifSetNetworkSettings(string uri, string userName, string password, NetworkSettings networkSettings)
            : base(uri, userName, password)
        {
            NetworkSettings = networkSettings;
        }
    }
}
