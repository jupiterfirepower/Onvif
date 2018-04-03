using onvif.services;

namespace Onvif.Contracts.Model
{
    public class NetworkSettings: ModelBase
    {
        public string ZeroConfIp { get; set; }
        public bool ZeroConfSupported { get; set; }
        public bool DiscoveryModeSupported { get; set; }
        public bool ZeroConfEnabled { get; set; }
        public bool UseHostFromDhcp { get; set; }
        public string Host { get; set; }

        public NetworkProtocol[] NetProtocols { get; set; }

        public DiscoveryMode DiscoveryMode { get; set; }

        public bool UseNtpFromDhcp { get; set; }

        public string NtpServers { get; set; }

        public string Gateway { get; set; }

        public string Dns { get; set; }

        public bool Dhcp { get; set; }

        public string Ip { get; set; }

        public string Subnet { get; set; }
        
        public NetworkSettings(): base(false)
        {
        }

        public NetworkSettings(bool result): base(result)
        {
        }
    }
}
