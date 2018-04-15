using onvif.services;
using Onvif.Camera.Client.Model;
using Onvif.Contracts.Messages.Onvif;

namespace Onvif.Camera.Client.Contracts
{
    public interface IOnvifClientImagingSync
    {
        OnvifClientResult<ImagingSettings20> GetImagingSettings(string profToken);
        OnvifResult SetImagingSettings(string profToken, ImagingSettings20 settings);
        OnvifClientResult<ImagingOptions20> GetOptions(string profToken);
        OnvifResult Move(string profToken, FocusMove move);
        OnvifClientResult<MoveOptions20> GetMoveOptions(string profToken);
        OnvifClientResult<ImagingStatus20> GetImagingStatus(string profToken);

        OnvifClientResult<ImagingSettings20> GetImagingSettings(string url, string userName, string password, string profToken);
        OnvifResult SetImagingSettings(string url, string userName, string password, string profToken, ImagingSettings20 settings);
        OnvifClientResult<ImagingOptions20> GetOptions(string url, string userName, string password, string profToken);
        OnvifResult Move(string url, string userName, string password, string profToken, FocusMove move);
        OnvifClientResult<MoveOptions20> GetMoveOptions(string url, string userName, string password, string profToken);
        OnvifClientResult<ImagingStatus20> GetImagingStatus(string url, string userName, string password, string profToken);
    }
}
