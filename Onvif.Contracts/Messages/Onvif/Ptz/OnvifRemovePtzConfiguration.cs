namespace Onvif.Contracts.Messages.Onvif.Ptz
{
    public class OnvifRemovePtzConfiguration : OnvifBase
    {
        public string ProfileToken { get; set; }

        public OnvifRemovePtzConfiguration(string uri, string userName, string password, string profileToken)
            : base(uri, userName, password)
        {
            ProfileToken = profileToken;
        }
    }
}
