using System.Threading.Tasks;
using onvif.services;

namespace Onvif.Proxy.Contracts.Contract
{
    public interface IOnvifRelays
    {
        Task<RelayOutput[]> GetRelayOutputsAsync();
        Task SetRelayOutputSettingsAsync(string token, RelayOutputSettings settings);
        Task SetRelayOutputStateAsync(string token, RelayLogicalState state);


        RelayOutput[] GetRelayOutputs();
        void SetRelayOutputSettings(string token, RelayOutputSettings settings);
        void SetRelayOutputState(string token, RelayLogicalState state);
    }
}
