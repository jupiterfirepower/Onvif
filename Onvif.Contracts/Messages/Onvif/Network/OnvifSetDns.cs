using onvif.services;

namespace Onvif.Contracts.Messages.Onvif.Network
{
    public class OnvifSetDns : OnvifBase
    {
        public bool UseDhcp { get; private set; } 
        public IPAddress[] DnsAddresses { get; private set; }
        public string[] DnsManual { get; private set; }

        public OnvifSetDns(string uri, string userName, string password, bool useDhcp, IPAddress[] dnsAddresses, string[] dnsManual)
            : base(uri, userName, password)
        {
            UseDhcp = useDhcp;
            DnsAddresses = dnsAddresses;
            DnsManual = dnsManual;
        }
    }
}
