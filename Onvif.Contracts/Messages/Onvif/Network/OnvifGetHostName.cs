namespace Onvif.Contracts.Messages.Onvif.Network
{
    public class OnvifGetHostName : OnvifBase
    {
        public OnvifGetHostName(string uri, string userName, string password) : base(uri, userName, password)
        {
        }
    }
}
