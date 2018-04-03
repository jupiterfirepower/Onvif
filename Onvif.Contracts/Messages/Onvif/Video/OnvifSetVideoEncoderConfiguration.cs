using onvif.services;

namespace Onvif.Contracts.Messages.Onvif.Video
{
    public class OnvifSetVideoEncoderConfiguration : OnvifBase
    {
        public VideoEncoderConfiguration ConfigEncoder { get; private set; }

        public OnvifSetVideoEncoderConfiguration(string uri, string userName, string password, VideoEncoderConfiguration configEncoder)
            : base(uri, userName, password)
        {
            ConfigEncoder = configEncoder;
        }
    }
}
