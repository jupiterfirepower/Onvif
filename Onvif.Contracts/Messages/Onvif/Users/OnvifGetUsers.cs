namespace Onvif.Contracts.Messages.Onvif.Users
{
    public class OnvifGetUsers : OnvifBase
    {
        public OnvifGetUsers(string uri, string userName, string password) : base(uri, userName, password)
        {
        }
    }
}
