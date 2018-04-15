using System.Threading.Tasks;
using Akka.Actor;
using onvif.services;
using Onvif.Contracts.Messages.Onvif;
using Onvif.Contracts.Messages.Onvif.Relay;

namespace Onvif.Camera.Client
{
    public partial class OnvifClient
    {
        public async Task<OnvifResult> SetRelayOutputSettingsAsync(string token, RelayOutputSettings settings)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifSetRelayOutputSettings(_url, _userName, _password, token, settings));
        }

        public OnvifResult SetRelayOutputSettings(string token, RelayOutputSettings settings)
        {
            return SetRelayOutputSettings(_url, _userName, _password, token, settings);
        }

        public OnvifResult SetRelayOutputSettings(string url, string userName, string password, string token, RelayOutputSettings settings)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifSetRelayOutputSettings(_url, _userName, _password, token, settings)).Result;
        }

        public async Task<OnvifResult> SetRelayOutputStateAsync(string token, RelayLogicalState state)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifSetRelayOutputState(_url, _userName, _password, token, state));
        }

        public OnvifResult SetRelayOutputState(string token, RelayLogicalState state)
        {
            return SetRelayOutputState(_url, _userName, _password, token, state);
        }

        public OnvifResult SetRelayOutputState(string url, string userName, string password, string token, RelayLogicalState state)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifSetRelayOutputState(url, userName, password, token, state)).Result;
        }
    }
}
