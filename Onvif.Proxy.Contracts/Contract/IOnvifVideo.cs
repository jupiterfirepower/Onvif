using System.Threading.Tasks;
using onvif.services;
using Onvif.Contracts.Model;

namespace Onvif.Proxy.Contracts.Contract
{
    public interface IOnvifVideo
    {
        VideoSettings GetVideoSettings(string profToken);
        Task<VideoResolution[]> GetVideoSupportedResolutionsAsync(VideoEncoding encoder);
        Task SetVideoSettingsAsync(string profToken, VideoSettings settings);
        Task SetVideoResolutionAsync(VideoResolution resolution, string profToken = null);
        Task SetVideoFrameRateAsync(float frameRate, string profToken = null);
        Task SetVideoBitRateLimitAsync(float bitRate, string profToken = null);
        Task SetVideoQualityAsync(float quality, string profToken = null);
        Task SetVideoGovLengthAsync(int govLength, string profToken = null);
        Task SetVideoEncodingIntervalAsync(int encodingInterval, string profToken = null);
        Task SetVideoEncoderConfigurationAsync(VideoEncoderConfiguration configEncoder, bool forcePersistance = false);
        Task AddVideoEncoderConfigurationAsync(string profileToken, string configurationToken);
        Task RemoveVideoEncoderConfigurationAsync(string profileToken);
        Task AddVideoSourceConfigurationAsync(string profileToken, string configurationToken);
        Task RemoveVideoSourceConfigurationAsync(string profileToken);

        VideoEncoderConfigurationOptions GetVideoEncoderConfigurationOptions(string configToken, string profToken = null);
        void SetVideoEncoderConfiguration(VideoEncoderConfiguration configEncoder, bool forcePersistance = false);
        void AddVideoEncoderConfiguration(string profileToken, string configurationToken);
        void RemoveVideoEncoderConfiguration(string profileToken);
        void AddVideoSourceConfiguration(string profileToken, string configurationToken);
        void RemoveVideoSourceConfiguration(string profileToken);
        void SetVideoResolution(VideoResolution resolution, string profToken = null);
        void SetVideoFrameRate(float frameRate, string profToken = null);
        void SetVideoBitRateLimit(float bitRate, string profToken = null);
        void SetVideoQuality(float quality, string profToken = null);
        void SetVideoGovLength(int govLength, string profToken = null);
        void SetVideoEncodingInterval(int encodingInterval, string profToken = null);
        void SetVideoSettings(string profToken, VideoSettings settings);
        VideoResolution[] GetVideoSupportedResolutions(VideoEncoding encoder);
    }
}
