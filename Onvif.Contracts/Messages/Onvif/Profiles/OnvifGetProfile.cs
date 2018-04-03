namespace Onvif.Contracts.Messages.Onvif.Profiles
{
    public class OnvifGetProfile : OnvifBase
    {
        public string ProfileToken { get; private set; }

        public OnvifGetProfile(string uri, string userName, string password, string profileToken)
            : base(uri, userName, password)
        {
            ProfileToken = profileToken;
        }
    }
}
