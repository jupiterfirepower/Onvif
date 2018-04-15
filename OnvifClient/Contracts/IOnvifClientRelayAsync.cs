using System.Threading.Tasks;
using onvif.services;
using Onvif.Contracts.Messages.Onvif;

namespace Onvif.Camera.Client.Contracts
{
    public interface IOnvifClientRelayAsync
    {
        Task<OnvifResult> SetRelayOutputSettingsAsync(string token, RelayOutputSettings settings);
        Task<OnvifResult> SetRelayOutputStateAsync(string token, RelayLogicalState state);

        
    }
}
