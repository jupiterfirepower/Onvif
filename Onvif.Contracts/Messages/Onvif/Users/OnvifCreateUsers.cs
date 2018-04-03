using onvif.services;

namespace Onvif.Contracts.Messages.Onvif.Users
{
    public class OnvifCreateUsers : OnvifBase
    {
        public User[] Users { get; private set; }

        public OnvifCreateUsers(string uri, string userName, string password, User[] users)
            : base(uri, userName, password)
        {
            Users = users;
        }
    }
}
