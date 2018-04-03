namespace Onvif.Contracts.Messages.Onvif.Imaging
{
    public class OnvifGetImagingMoveOptions : OnvifBase
    {
        public string ProfileToken { get; private set; }

        public OnvifGetImagingMoveOptions(string uri, string userName, string password,string profileToken) : base(uri, userName, password)
        {
            ProfileToken = profileToken;
        }
    }
}
