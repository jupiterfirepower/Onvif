namespace Onvif.Contracts.Messages.Onvif.Ptz
{
    public class OnvifPtzSetPreset : OnvifBase
    {
        public string ProfileToken { get; private set; }
        public string PresetName { get; private set; }
        public string PresetToken { get; private set; }

        public OnvifPtzSetPreset(string uri, string userName, string password, string profileToken, string presetName, string presetToken)
            : base(uri, userName, password)
        {
            ProfileToken = profileToken;
            PresetName = presetName;
            PresetToken = presetToken;
        }
    }
}
