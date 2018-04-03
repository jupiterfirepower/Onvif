using onvif.services;

namespace Onvif.Contracts.Messages.Onvif.Relay
{
    public class OnvifSetRelayOutputSettings : OnvifBase
    {
        public string Token { get; private set; }
        public RelayOutputSettings Settings { get; private set; }

        public OnvifSetRelayOutputSettings(string uri, string userName, string password, string token, RelayOutputSettings settings)
            : base(uri, userName, password)
        {
            Token = token;
            Settings = settings;
        }
    }
}
