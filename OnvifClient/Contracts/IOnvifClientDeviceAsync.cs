using System;
using System.Threading.Tasks;
using onvif.services;
using Onvif.Camera.Client.Model;
using Onvif.Contracts.Messages.Onvif;
using Onvif.Contracts.Model;

namespace Onvif.Camera.Client.Contracts
{
    public interface IOnvifClientDeviceAsync
    {
        Task<OnvifClientResult<DeviceInfo>> GetCameraDeviceInfoAsync();
        Task<OnvifResult> SetDeviceIdentificationAsync(DeviceInfo devInfo);
        Task<OnvifResult> SetDeviceNameAsync(string name);
        Task<OnvifResult> SetDeviceLocationAsync(string location);
        Task<OnvifResult> ResetAsync(FactoryDefaultType resetType);
        Task<OnvifResult> RebootAsync();
        Task<OnvifClientResult<Uri>> GetCameraWebPageUriAsync();

       
    }
}
