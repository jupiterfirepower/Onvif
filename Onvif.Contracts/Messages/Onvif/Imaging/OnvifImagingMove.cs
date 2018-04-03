using onvif.services;

namespace Onvif.Contracts.Messages.Onvif.Imaging
{
    public class OnvifImagingMove : OnvifBase
    {
        public string ProfileToken { get; private set; }
        public FocusMove FocusMove { get; private set; }

        public OnvifImagingMove(string uri, string userName, string password, string profileToken, FocusMove focusMove)
            : base(uri, userName, password)
        {
            ProfileToken = profileToken;
            FocusMove = focusMove;
        }
    }
}
