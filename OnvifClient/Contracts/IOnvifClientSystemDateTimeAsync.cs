using System.Threading.Tasks;
using onvif.services;
using Onvif.Camera.Client.Model;
using Onvif.Contracts.Messages.Onvif;

namespace Onvif.Camera.Client.Contracts
{
    public interface IOnvifClientSystemDateTimeAsync
    {
        Task<OnvifClientResult<SystemDateTime>> GetCameraSystemDateTimeAsync();
        Task<OnvifResult> SyncCameraSystemDateTimeWithLocalSystemAsync();
        Task<OnvifResult> SyncCameraSystemDateTimeWithNtpAsync();
    }
}
