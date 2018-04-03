namespace Onvif.Contracts.Messages.Onvif.Imaging
{
    public class OnvifGetImagingSettings : OnvifBase
    {
        public string ProfileToken { get; private set; }

        public OnvifGetImagingSettings(string uri, string userName, string password, string profileToken)
            : base(uri, userName, password)
        {
            ProfileToken = profileToken;
        }
    }
}
