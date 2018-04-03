namespace Onvif.Contracts.Messages.Onvif.Imaging
{
    public class OnvifGetImagingOptions : OnvifBase
    {
        public string ProfileToken { get; private set; }

        public OnvifGetImagingOptions(string uri, string userName, string password, string profileToken)
            : base(uri, userName, password)
        {
            ProfileToken = profileToken;
        }
    }
}
