using onvif.services;

namespace Onvif.Contracts.Messages.Onvif.Ptz
{
    public class OnvifPtzGotoHomePosition : OnvifBase
    {
        public string ProfileToken { get; private set; }
        public PTZSpeed Speed { get; private set; }

        public OnvifPtzGotoHomePosition(string uri, string userName, string password, string profileToken, PTZSpeed speed)
            : base(uri, userName, password)
        {
            ProfileToken = profileToken;
            Speed = speed;
        }
    }
}
