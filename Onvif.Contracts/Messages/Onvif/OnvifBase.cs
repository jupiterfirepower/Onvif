namespace Onvif.Contracts.Messages.Onvif
{
    public abstract class OnvifBase
    {
        public string UserName { get; private set; }
        public string Password { get; private set; }

        public string Uri { get; private set; }

        protected OnvifBase(string uri, string userName, string password)
        {
            Uri = uri;
            UserName = userName;
            Password = password;
        }
    }
}
