using System.Threading.Tasks;
using onvif.services;
using Onvif.Camera.Client.Model;
using Onvif.Contracts.Messages.Onvif;
using Onvif.Contracts.Model;

namespace Onvif.Camera.Client.Contracts
{
    public interface IOnvifClientVideoAsync
    {
        Task<OnvifClientResult<VideoSettings>> GetVideoSettingsAsync(string profileName);
        Task<OnvifResult> SetVideoSettingsAsync(string profToken, VideoSettings settings);
        Task<OnvifResult> SetVideoResolutionAsync(VideoResolution resolution, string profToken = null);
        Task<OnvifResult> SetVideoFrameRateAsync(float frameRate, string profToken = null);
        Task<OnvifResult> SetVideoBitRateLimitAsync(float bitRate, string profToken = null);
        Task<OnvifResult> SetVideoQualityAsync(float quality, string profToken = null);
        Task<OnvifResult> SetVideoGovLengthAsync(int govLength, string profToken = null);
        Task<OnvifResult> SetVideoEncodingIntervalAsync(int encodingInterval, string profToken = null);
        Task<OnvifClientResult<VideoResolution[]>> GetVideoSupportedResolutionsAsync(VideoEncoding encoder);
        Task<OnvifResult> SetVideoEncoderConfigurationAsync(VideoEncoderConfiguration configEncoder);

        
    }
}
