namespace Onvif.Contracts.Messages.Onvif.Network
{
    public class OnvifSetNetworkDefaultGateway : OnvifBase
    {
        public string[] Ipv4 { get; private set; }
        public string[] Ipv6 { get; private set; }

        public OnvifSetNetworkDefaultGateway(string uri, string userName, string password, string[] ipv4, string[] ipv6)
            : base(uri, userName, password)
        {
            Ipv4 = ipv4;
            Ipv6 = ipv6;
        }
    }
}
