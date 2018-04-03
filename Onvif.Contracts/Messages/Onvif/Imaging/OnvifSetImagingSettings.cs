using onvif.services;

namespace Onvif.Contracts.Messages.Onvif.Imaging
{
    public class OnvifSetImagingSettings : OnvifBase
    {
        public string ProfToken { get; private set; }
        public ImagingSettings20 Settings { get; private set; }

        public OnvifSetImagingSettings(string uri, string userName, string password, string profToken, ImagingSettings20 settings)
            : base(uri, userName, password)
        {
            ProfToken = profToken;
            Settings = settings;
        }
    }
}
