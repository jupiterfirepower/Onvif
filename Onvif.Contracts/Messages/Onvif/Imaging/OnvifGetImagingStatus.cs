namespace Onvif.Contracts.Messages.Onvif.Imaging
{
    public class OnvifGetImagingStatus : OnvifBase
    {
        public string ProfileToken { get; private set; }

        public OnvifGetImagingStatus(string uri, string userName, string password, string profileToken)
            : base(uri, userName, password)
        {
            ProfileToken = profileToken;
        }
    }
}
