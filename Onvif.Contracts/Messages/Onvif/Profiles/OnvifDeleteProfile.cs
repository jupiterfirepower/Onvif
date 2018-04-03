namespace Onvif.Contracts.Messages.Onvif.Profiles
{
    public class OnvifDeleteProfile : OnvifBase
    {
        public string ProfileToken { get; private set; }

        public OnvifDeleteProfile(string uri, string userName, string password, string profileToken)
            : base(uri, userName, password)
        {
            ProfileToken = profileToken;
        }
    }
}
