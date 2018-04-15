using System.Threading.Tasks;
using Onvif.Camera.Client.Model;

namespace Onvif.Camera.Client.Contracts
{
    public interface IOnvifClientPropertyAsync
    {
        Task<OnvifClientResult<bool>> IsAnalyticsSupportedAsync();
        Task<OnvifClientResult<bool>> IsEventsSupportedAsync();
        Task<OnvifClientResult<bool>> IsFirmwareUpgradeSupportedAsync();
        Task<OnvifClientResult<bool>> IsPtzSupportedAsync();
        Task<OnvifClientResult<bool>> IsZeroConfigurationSupportedAsync();
    }
}
