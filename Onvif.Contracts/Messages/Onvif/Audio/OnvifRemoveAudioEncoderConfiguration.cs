namespace Onvif.Contracts.Messages.Onvif.Audio
{
    public class OnvifRemoveAudioEncoderConfiguration : OnvifBase
    {
        public string ProfileToken { get; private set; }
        public OnvifRemoveAudioEncoderConfiguration(string uri, string userName, string password, string profileToken)
            : base(uri, userName, password)
        {
            ProfileToken = profileToken;
        }
    }
}
