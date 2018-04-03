using onvif.services;

namespace Onvif.Contracts.Messages.Onvif.Ptz
{
    public class OnvifPtzContinuousMove : OnvifBase
    {
        public string ProfileToken { get; private set; }
        public PTZSpeed Velocity { get; private set; }
        public XsDuration Timeout { get; private set; }

        public OnvifPtzContinuousMove(string uri, string userName, string password, string profileToken, PTZSpeed velocity, XsDuration timeout)
            : base(uri, userName, password)
        {
            ProfileToken = profileToken;
            Velocity = velocity;
            Timeout = timeout;
        }
    }
}
