namespace Onvif.Contracts.Messages.Onvif.Ptz
{
    public class OnvifPtzRemovePreset : OnvifBase
    {
        public string ProfileToken { get; private set; }
        public string PresetToken { get; private set; }

        public OnvifPtzRemovePreset(string uri, string userName, string password,string profileToken,string presetToken) : base(uri, userName, password)
        {
            ProfileToken = profileToken;
            PresetToken = presetToken;
        }
    }
}
