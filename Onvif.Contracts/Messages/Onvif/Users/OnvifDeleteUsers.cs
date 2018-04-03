namespace Onvif.Contracts.Messages.Onvif.Users
{
    public class OnvifDeleteUsers : OnvifBase
    {
        public string[] UserNames { get; private set; }

        public OnvifDeleteUsers(string uri, string userName, string password, string[] userNames)
            : base(uri, userName, password)
        {
            UserNames = userNames;
        }
    }
}
