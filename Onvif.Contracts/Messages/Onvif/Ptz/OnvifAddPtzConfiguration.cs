namespace Onvif.Contracts.Messages.Onvif.Ptz
{
    public class OnvifAddPtzConfiguration : OnvifBase
    {
        public string ProfileToken { get; private set; }
        public string ConfigToken { get; private set; }

        public OnvifAddPtzConfiguration(string uri, string userName, string password, string profileToken, string configToken)
            : base(uri, userName, password)
        {
            ProfileToken = profileToken;
            ConfigToken = configToken;
        }
    }
}
