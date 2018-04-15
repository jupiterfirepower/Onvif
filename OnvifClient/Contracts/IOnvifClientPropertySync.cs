using Onvif.Camera.Client.Model;

namespace Onvif.Camera.Client.Contracts
{
    public interface IOnvifClientPropertySync
    {
        OnvifClientResult<bool> IsAnalyticsSupported();
        OnvifClientResult<bool> IsEventsSupported();
        OnvifClientResult<bool> IsFirmwareUpgradeSupported();
        OnvifClientResult<bool> IsPtzSupported();
        OnvifClientResult<bool> IsZeroConfigurationSupported();

        OnvifClientResult<bool> IsAnalyticsSupported(string url, string userName, string password);
        OnvifClientResult<bool> IsEventsSupported(string url, string userName, string password);
        OnvifClientResult<bool> IsFirmwareUpgradeSupported(string url, string userName, string password);
        OnvifClientResult<bool> IsPtzSupported(string url, string userName, string password);
        OnvifClientResult<bool> IsZeroConfigurationSupported(string url, string userName, string password);
    }
}
