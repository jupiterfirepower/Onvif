using System.Threading.Tasks;
using onvif.services;
using onvif.utils;
using Onvif.Contracts.Model;

namespace Onvif.Proxy.Contracts
{
    public interface IOnvifNetworks
    {
        bool IsZeroConfigurationSupported { get; }

        Task<NetworkSettings> GetNetworkSettings();

        Task SetNetworkSettings(NetworkSettings networkSettings);

        Task SetNetworkProtocols(NetworkProtocol[] protocols);
        Task SetNtp(bool useDhcp, NetworkHost[] ntpHosts);
        Task SetDns(bool useDhcp, IPAddress[] dnsAddresses, string[] dnsManual = null);
        Task SetNetworkDefaultGateway(string[] ipv4, string[] ipv6);
        Task SetZeroConfiguration(string zeroConfInterfaceToken, bool zeroConfEnabled);
        Task SetHostName(string host = "");
        Task SetDiscoveryMode(DiscoveryMode mode);
        Task SetNetworkInterfaces(string token, NetworkInterfaceSetConfiguration config);
        Task<NetStatus> GetNetworkStatus();

        Task<NetworkInterface[]> GetNetworkInterfaces();
        Task<NTPInformation> GetNtp();
        Task<HostnameInformation> GetHostName();
        Task<NetworkGateway> GetNetworkDefaultGateway();
        Task<DNSInformation> GetDns();
        Task<NetworkProtocol[]> GetNetworkProtocols();
        Task<DiscoveryMode> GetDiscoveryMode();


    }
}
