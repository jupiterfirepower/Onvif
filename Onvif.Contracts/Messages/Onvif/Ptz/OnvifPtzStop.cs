namespace Onvif.Contracts.Messages.Onvif.Ptz
{
    public class OnvifPtzStop : OnvifBase
    {
        public string ProfileToken { get; set; }
        public bool PanTilt { get; set; }
        public bool Zoom { get; set; }

        public OnvifPtzStop(string uri, string userName, string password, string profileToken, bool panTilt, bool zoom)
            : base(uri, userName, password)
        {
            ProfileToken = profileToken;
            PanTilt = panTilt;
            Zoom = zoom;
        }
    }
}
