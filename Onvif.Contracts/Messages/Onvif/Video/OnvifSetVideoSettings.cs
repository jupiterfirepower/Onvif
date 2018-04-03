using Onvif.Contracts.Model;

namespace Onvif.Contracts.Messages.Onvif.Video
{
    public class OnvifSetVideoSettings : OnvifBase
    {
        public string ProfToken { get; private set; }
        public VideoSettings Settings { get; private set; }

        public OnvifSetVideoSettings(string uri, string userName, string password, string profToken, VideoSettings settings)
            : base(uri, userName, password)
        {
            ProfToken = profToken;
            Settings = settings;
        }
    }
}
