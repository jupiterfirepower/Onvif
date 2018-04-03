namespace Onvif.Contracts.Messages.Onvif.Network
{
    public class OnvifSetHostName : OnvifBase
    {
        public string Host { get; private set; }

        public OnvifSetHostName(string uri, string userName, string password, string host)
            : base(uri, userName, password)
        {
            Host = host;
        }
    }
}
