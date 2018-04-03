namespace Onvif.Contracts.Messages.Onvif.Network
{
    public class OnvifGetNetworkSettings : OnvifBase
    {
        public OnvifGetNetworkSettings(string uri, string userName, string password) : base(uri, userName, password)
        {
        }
    }
}
