using onvif.services;
using Onvif.Camera.Client.Model;
using Onvif.Contracts.Messages.Onvif;

namespace Onvif.Camera.Client.Contracts
{
    public interface IOnvifClientSystemDateTimeSync
    {
        OnvifClientResult<SystemDateTime> GetCameraSystemDateTime();
        OnvifResult SyncCameraSystemDateTimeWithNtp();
        OnvifResult SyncCameraSystemDateTimeWithLocalSystem();

        OnvifClientResult<SystemDateTime> GetCameraSystemDateTime(string url, string userName, string password);
        OnvifResult SyncCameraSystemDateTimeWithNtp(string url, string userName, string password);
        OnvifResult SyncCameraSystemDateTimeWithLocalSystem(string url, string userName, string password);
    }
}
