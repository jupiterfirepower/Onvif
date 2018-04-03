using onvif.services;

namespace Onvif.Contracts.Messages.Onvif.Video
{
    public class OnvifSetVideoResolution : OnvifBase
    {
        public string ProfileToken { get; private set; }
        public VideoResolution Resolution { get; private set; }

        public OnvifSetVideoResolution(string uri, string userName, string password, VideoResolution resolution, string profileToken)
            : base(uri, userName, password)
        {
            ProfileToken = profileToken;
            Resolution = resolution;
        }
    }
}
