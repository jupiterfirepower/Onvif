namespace Onvif.Contracts.Messages.Onvif.Profiles
{
    public class OnvifCreateProfile : OnvifBase
    {
        public string Name { get; private set; }
        public string Token { get; private set; }

        public OnvifCreateProfile(string uri, string userName, string password, string name, string token)
            : base(uri, userName, password)
        {
            Name = name;
            Token = token;
        }
    }
}
