using onvif.services;

namespace Onvif.Contracts.Messages.Onvif.Users
{
    public class OnvifDeleteUser : OnvifBase
    {
        public User User { get; private set; }

        public OnvifDeleteUser(string uri, string userName, string password, User user)
            : base(uri, userName, password)
        {
            User = user;
        }
    }
}
