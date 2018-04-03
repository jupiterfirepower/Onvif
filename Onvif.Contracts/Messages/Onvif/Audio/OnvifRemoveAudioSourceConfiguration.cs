namespace Onvif.Contracts.Messages.Onvif.Audio
{
    public class OnvifRemoveAudioSourceConfiguration : OnvifBase
    {
        public string ProfileToken { get; private set; }
        public OnvifRemoveAudioSourceConfiguration(string uri, string userName, string password, string profileToken)
            : base(uri, userName, password)
        {
            ProfileToken = profileToken;
        }
    }
}
