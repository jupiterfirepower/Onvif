using System.Threading.Tasks;
using onvif.services;

namespace Onvif.Proxy.Contracts.Contract
{
    public interface IOnvifImaging
    {
        Task SetImagingSettingsAsync(string profToken, ImagingSettings20 settings);

        Task<ImagingSettings20> GetImagingSettingsAsync(string profToken);

        Task<ImagingOptions20> GetOptionsAsync(string profToken);

        Task MoveAsync(string profToken, FocusMove move);

        Task<MoveOptions20> GetMoveOptionsAsync(string profToken);

        Task<ImagingStatus20> GetImagingStatusAsync(string profToken);

        void SetImagingSettings(string profToken, ImagingSettings20 settings);
        ImagingSettings20 GetImagingSettings(string profToken);
        ImagingOptions20 GetOptions(string profToken);
        void Move(string profToken, FocusMove move);
        MoveOptions20 GetMoveOptions(string profToken);
        ImagingStatus20 GetImagingStatus(string profToken);
    }
}
