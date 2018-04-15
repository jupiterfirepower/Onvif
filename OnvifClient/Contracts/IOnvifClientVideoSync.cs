using onvif.services;
using Onvif.Camera.Client.Model;
using Onvif.Contracts.Messages.Onvif;
using Onvif.Contracts.Model;

namespace Onvif.Camera.Client.Contracts
{
    public interface IOnvifClientVideoSync
    {
        OnvifClientResult<VideoSettings> GetVideoSettings(string url, string userName, string password, string profileName);
        OnvifResult SetVideoSettings(string url, string userName, string password, string profToken, VideoSettings settings);
        OnvifResult SetVideoResolution(string url, string userName, string password, VideoResolution resolution, string profileToken = null);
        OnvifClientResult<VideoResolution[]> GetVideoSupportedResolutions(string url, string userName, string password, VideoEncoding encoder);
        OnvifResult SetVideoFrameRate(string url, string userName, string password, float frameRate, string profToken = null);
        OnvifResult SetVideoBitRateLimit(string url, string userName, string password, float bitRate, string profToken = null);
        OnvifResult SetVideoQuality(string url, string userName, string password, float quality, string profToken = null);
        OnvifResult SetVideoGovLength(string url, string userName, string password, int govLength, string profToken = null);
        OnvifResult SetVideoEncodingInterval(string url, string userName, string password, int encodingInterval, string profToken = null);
        OnvifResult SetVideoEncoderConfiguration(string url, string userName, string password, VideoEncoderConfiguration configEncoder);
    }
}
