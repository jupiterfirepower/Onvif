using onvif.services;

namespace Onvif.Contracts.Messages.Onvif.Users
{
    public class OnvifCreateUser : OnvifBase
    {
        public User User { get; private set; }

        public OnvifCreateUser(string uri, string userName, string password, User user)
            : base(uri, userName, password)
        {
            User = user;
        }
    }
}
