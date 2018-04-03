using onvif.services;

namespace Onvif.Contracts.Messages.Onvif.Ptz
{
    public class OnvifPtzAbsoluteMove : OnvifBase
    {
        public string ProfileToken { get; private set; } 
        public PTZVector Position { get; private set; }
        public PTZSpeed Speed { get; private set; }

        public OnvifPtzAbsoluteMove(string uri, string userName, string password, string profileToken, PTZVector position, PTZSpeed speed)
            : base(uri, userName, password)
        {
            ProfileToken = uri;
            Position = position;
            Speed = speed;
        }
    }
}
