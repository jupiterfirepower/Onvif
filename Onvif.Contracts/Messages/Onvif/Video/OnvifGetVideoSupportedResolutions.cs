using onvif.services;

namespace Onvif.Contracts.Messages.Onvif.Video
{
    public class OnvifGetVideoSupportedResolutions : OnvifBase
    {
        public VideoEncoding Encoder { get; private set; }

        public OnvifGetVideoSupportedResolutions(string uri, string userName, string password, VideoEncoding encoder)
            : base(uri, userName, password)
        {
            Encoder = encoder;
        }
    }
}
