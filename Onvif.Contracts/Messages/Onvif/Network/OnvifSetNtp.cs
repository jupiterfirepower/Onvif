using onvif.services;

namespace Onvif.Contracts.Messages.Onvif.Network
{
    public class OnvifSetNtp : OnvifBase
    {
        public bool UseDhcp { get; private set; }
        public NetworkHost[] NtpHosts { get; private set; }

        public OnvifSetNtp(string uri, string userName, string password, bool useDhcp, NetworkHost[] ntpHosts)
            : base(uri, userName, password)
        {
            UseDhcp = useDhcp;
            NtpHosts = ntpHosts;
        }
    }
}
