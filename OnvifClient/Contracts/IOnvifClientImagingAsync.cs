using System.Threading.Tasks;
using onvif.services;
using Onvif.Camera.Client.Model;
using Onvif.Contracts.Messages.Onvif;

namespace Onvif.Camera.Client.Contracts
{
    public interface IOnvifClientImagingAsync
    {
        Task<OnvifClientResult<ImagingSettings20>> GetImagingSettingsAsync(string profToken);

        Task<OnvifResult> SetImagingSettingsAsync(string profToken, ImagingSettings20 settings);

        Task<OnvifClientResult<ImagingOptions20>> GetOptionsAsync(string profToken);

        Task<OnvifResult> MoveAsync(string profToken, FocusMove move);

        Task<OnvifClientResult<MoveOptions20>> GetMoveOptionsAsync(string profToken);

        Task<OnvifClientResult<ImagingStatus20>> GetImagingStatusAsync(string profToken);
    }
}
