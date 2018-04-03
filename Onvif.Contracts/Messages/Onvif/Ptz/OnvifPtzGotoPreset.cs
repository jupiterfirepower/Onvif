using onvif.services;

namespace Onvif.Contracts.Messages.Onvif.Ptz
{
    public class OnvifPtzGotoPreset : OnvifBase
    {
        public string ProfileToken { get; private set; }
        public string PresetToken { get; private set; }

        public PTZSpeed Speed { get; private set; }

        public OnvifPtzGotoPreset(string uri, string userName, string password, string profileToken, string presetToken, PTZSpeed speed)
            : base(uri, userName, password)
        {
            ProfileToken = profileToken;
            PresetToken = presetToken;
            Speed = speed;
        }
    }
}
