using onvif.services;

namespace Onvif.Contracts.Messages.Onvif.Ptz
{
    public class OnvifPtzRelativeMove : OnvifBase
    {
        public string ProfileToken { get; private set; }
        public PTZVector Traslation { get; private set; }
        public PTZSpeed Speed { get; private set; }

        public OnvifPtzRelativeMove(string uri, string userName, string password, string profileToken, PTZVector traslation, PTZSpeed speed)
            : base(uri, userName, password)
        {
            ProfileToken = profileToken;
            Traslation = traslation;
            Speed = speed;
        }
    }
}
