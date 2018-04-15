using onvif.services;
using Onvif.Contracts.Messages.Onvif;

namespace Onvif.Camera.Client.Contracts
{
    public interface IOnvifClientRelaySync
    {
        OnvifResult SetRelayOutputSettings(string token, RelayOutputSettings settings);
        OnvifResult SetRelayOutputState(string token, RelayLogicalState state);

        OnvifResult SetRelayOutputSettings(string url, string userName, string password, string token, RelayOutputSettings settings);
        OnvifResult SetRelayOutputState(string url, string userName, string password, string token, RelayLogicalState state);
    }
}
