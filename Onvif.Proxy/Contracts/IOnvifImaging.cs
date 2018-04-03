using System.Threading.Tasks;
using onvif.services;

namespace Onvif.Proxy.Contracts
{
    public interface IOnvifImaging
    {
        Task SetImagingSettings(string profToken, ImagingSettings20 settings);

        Task<ImagingSettings20> GetImagingSettings(string profToken);

        Task<ImagingOptions20> GetOptions(string profToken);

        Task Move(string profToken, FocusMove move);

        Task<MoveOptions20> GetMoveOptions(string profToken);

        Task<ImagingStatus20> GetImagingStatus(string profToken);
    }
}
