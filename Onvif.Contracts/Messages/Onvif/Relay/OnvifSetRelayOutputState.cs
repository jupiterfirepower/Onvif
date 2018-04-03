using onvif.services;

namespace Onvif.Contracts.Messages.Onvif.Relay
{
    public class OnvifSetRelayOutputState : OnvifBase
    {
        public string Token { get; private set; }
        public RelayLogicalState State { get; private set; }

        public OnvifSetRelayOutputState(string uri, string userName, string password, string token, RelayLogicalState state)
            : base(uri, userName, password)
        {
            Token = token;
            State = state;
        }
    }
}
