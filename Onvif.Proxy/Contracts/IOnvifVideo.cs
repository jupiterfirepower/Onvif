using System.Threading.Tasks;
using onvif.services;
using Onvif.Contracts.Model;

namespace Onvif.Proxy.Contracts
{
    public interface IOnvifVideo
    {
        Task<VideoResolution[]> GetVideoSupportedResolutions(VideoEncoding encoder);
        Task SetVideoSettings(string profToken, VideoSettings settings);

        Task SetVideoResolution(VideoResolution resolution, string profToken = null);
        Task SetVideoFrameRate(float frameRate, string profToken = null);
        Task SetVideoBitRateLimit(float bitRate, string profToken = null);

        Task SetVideoQuality(float quality, string profToken = null);

        Task SetVideoGovLength(int govLength, string profToken = null);

        Task SetVideoEncodingInterval(int encodingInterval, string profToken = null);

        Task<VideoSettings> GetVideoSettings(string profToken);
    }
}
