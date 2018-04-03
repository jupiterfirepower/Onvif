using onvif.services;

namespace Onvif.Contracts.Messages.Onvif.Users
{
    public class OnvifModifyUser : OnvifBase
    {
        public User User { get; private set; }

        public OnvifModifyUser(string uri, string userName, string password, User user)
            : base(uri, userName, password)
        {
            User = user;
        }
    }
}
