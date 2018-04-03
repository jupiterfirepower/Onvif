namespace Onvif.Contracts.Messages.Onvif.Audio
{
    public class OnvifAddAudioSourceConfiguration : OnvifBase
    {
        public string ProfileToken { get; private set; }
        public string ConfigurationToken { get; private set; }
        public OnvifAddAudioSourceConfiguration(string uri, string userName, string password, string profileToken, string configurationToken)
            : base(uri, userName, password)
        {
            ProfileToken = profileToken;
            ConfigurationToken = configurationToken;
        }
    }
}
