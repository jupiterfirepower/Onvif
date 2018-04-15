using System.Threading.Tasks;
using Akka.Actor;
using onvif.services;
using Onvif.Camera.Client.Model;
using Onvif.Contracts.Messages.Onvif;
using Onvif.Contracts.Messages.Onvif.Video;
using Onvif.Contracts.Model;

namespace Onvif.Camera.Client
{
    public partial class OnvifClient
    {
        public async Task<OnvifClientResult<VideoSettings>> GetVideoSettingsAsync(string profileName)
        {
            var result = await _proxyActor.Ask<Container<VideoSettings>>(new OnvifGetVideoSettings(_url, _userName, _password, profileName));
            return result.Success ? (OnvifClientResult<VideoSettings>)new OnvifClientResultData<VideoSettings>(result.WorkItem)
                : new OnvifClientResultEmpty<VideoSettings>(new VideoSettings());
        }

        public OnvifClientResult<VideoSettings> GetVideoSettings(string profileName)
        {
            return GetVideoSettings(_url, _userName, _password, profileName);
        }

        public OnvifClientResult<VideoSettings> GetVideoSettings(string url, string userName, string password, string profileName)
        {
            var result = _proxyActor.Ask<Container<VideoSettings>>(new OnvifGetVideoSettings(url, userName, password, profileName)).Result;
            return result.Success ? (OnvifClientResult<VideoSettings>)new OnvifClientResultData<VideoSettings>(result.WorkItem)
                : new OnvifClientResultEmpty<VideoSettings>(new VideoSettings());
        }

        public async Task<OnvifResult> SetVideoSettingsAsync(string profToken, VideoSettings settings)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifSetVideoSettings(_url, _userName, _password, profToken, settings));
        }

        public OnvifResult SetVideoSettings(string profToken, VideoSettings settings)
        {
            return SetVideoSettings(_url, _userName, _password, profToken, settings);
        }

        public OnvifResult SetVideoSettings(string url, string userName, string password, string profToken, VideoSettings settings)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifSetVideoSettings(url, userName, password, profToken, settings)).Result;
        }

        public async Task<OnvifResult> SetVideoResolutionAsync(VideoResolution resolution, string profileToken = null)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifSetVideoResolution(_url, _userName, _password, resolution, profileToken));
        }

        public OnvifResult SetVideoResolution(VideoResolution resolution, string profileToken = null)
        {
            return SetVideoResolution(_url, _userName, _password, resolution, profileToken);
        }

        public OnvifResult SetVideoResolution(string url, string userName, string password, VideoResolution resolution, string profileToken = null)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifSetVideoResolution(_url, _userName, _password, resolution, profileToken)).Result;
        }

        public async Task<OnvifClientResult<VideoResolution[]>> GetVideoSupportedResolutionsAsync(VideoEncoding encoder)
        {
            var result = await _proxyActor.Ask<Container<VideoResolution[]>>(new OnvifGetVideoSupportedResolutions(_url, _userName, _password, encoder));
            return result.Success ? (OnvifClientResult<VideoResolution[]>)new OnvifClientResultData<VideoResolution[]>(result.WorkItem)
                : new OnvifClientResultEmpty<VideoResolution[]>(new VideoResolution[0]);
        }

        public OnvifClientResult<VideoResolution[]> GetVideoSupportedResolutions(VideoEncoding encoder)
        {
            return GetVideoSupportedResolutions(_url, _userName, _password, encoder);
        }

        public OnvifClientResult<VideoResolution[]> GetVideoSupportedResolutions(string url, string userName, string password, VideoEncoding encoder)
        {
            var result = _proxyActor.Ask<Container<VideoResolution[]>>(new OnvifGetVideoSupportedResolutions(url, userName, password, encoder)).Result;
            return result.Success ? (OnvifClientResult<VideoResolution[]>)new OnvifClientResultData<VideoResolution[]>(result.WorkItem)
                : new OnvifClientResultEmpty<VideoResolution[]>(new VideoResolution[0]);
        }

        public async Task<OnvifResult> SetVideoFrameRateAsync(float frameRate, string profToken = null)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifSetVideoFrameRate(_url, _userName, _password, frameRate, profToken));
        }

        public OnvifResult SetVideoFrameRate(float frameRate, string profToken = null)
        {
            return SetVideoFrameRate(_url, _userName, _password, frameRate, profToken);
        }

        public OnvifResult SetVideoFrameRate(string url, string userName, string password, float frameRate, string profToken = null)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifSetVideoFrameRate(url, userName, password, frameRate, profToken)).Result;
        }

        public async Task<OnvifResult> SetVideoBitRateLimitAsync(float bitRate, string profToken = null)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifSetVideoBitRate(_url, _userName, _password, bitRate, profToken));
        }

        public OnvifResult SetVideoBitRateLimit(float bitRate, string profToken = null)
        {
            return SetVideoBitRateLimit(_url, _userName, _password, bitRate, profToken);
        }

        public OnvifResult SetVideoBitRateLimit(string url, string userName, string password, float bitRate, string profToken = null)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifSetVideoBitRate(url, userName, password, bitRate, profToken)).Result;
        }

        public async Task<OnvifResult> SetVideoQualityAsync(float quality, string profToken = null)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifSetVideoQuality(_url, _userName, _password, quality, profToken));
        }

        public OnvifResult SetVideoQuality(float quality, string profToken = null)
        {
            return SetVideoQuality(_url, _userName, _password, quality, profToken);
        }

        public OnvifResult SetVideoQuality(string url, string userName, string password, float quality, string profToken = null)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifSetVideoQuality(url, userName, password, quality, profToken)).Result;
        }

        public async Task<OnvifResult> SetVideoGovLengthAsync(int govLength, string profToken = null)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifSetVideoGovLength(_url, _userName, _password, govLength, profToken));
        }

        public OnvifResult SetVideoGovLength(int govLength, string profToken = null)
        {
            return SetVideoGovLength(_url, _userName, _password, govLength, profToken);
        }

        public OnvifResult SetVideoGovLength(string url, string userName, string password, int govLength, string profToken = null)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifSetVideoGovLength(url, userName, password, govLength, profToken)).Result;
        }

        public async Task<OnvifResult> SetVideoEncodingIntervalAsync(int encodingInterval, string profToken = null)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifSetVideoEncodingInterval(_url, _userName, _password, encodingInterval, profToken));
        }

        public OnvifResult SetVideoEncodingInterval(int encodingInterval, string profToken = null)
        {
            return SetVideoEncodingInterval(_url, _userName, _password, encodingInterval, profToken);
        }

        public OnvifResult SetVideoEncodingInterval(string url, string userName, string password, int encodingInterval, string profToken = null)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifSetVideoEncodingInterval(url, userName, password, encodingInterval, profToken)).Result;
        }

        public async Task<OnvifResult> SetVideoEncoderConfigurationAsync(VideoEncoderConfiguration configEncoder)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifSetVideoEncoderConfiguration(_url, _userName, _password, configEncoder));
        }

        public OnvifResult SetVideoEncoderConfiguration(VideoEncoderConfiguration configEncoder)
        {
            return SetVideoEncoderConfiguration(_url, _userName, _password, configEncoder);
        }

        public OnvifResult SetVideoEncoderConfiguration(string url, string userName, string password, VideoEncoderConfiguration configEncoder)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifSetVideoEncoderConfiguration(url, userName, password, configEncoder)).Result;
        }
    }
}
