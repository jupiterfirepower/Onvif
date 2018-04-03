using System.Threading.Tasks;
using onvif.services;
using onvif.utils;
using Onvif.Contracts.Model;

namespace Onvif.Proxy.Contracts.Contract
{
    public interface IOnvifNetworks
    {
        bool IsZeroConfigurationSupported { get; }

        Task<NetworkSettings> GetNetworkSettingsAsync();

        Task SetNetworkSettingsAsync(NetworkSettings networkSettings);
        Task SetNetworkProtocolsAsync(NetworkProtocol[] protocols);
        Task SetNtpAsync(bool useDhcp, NetworkHost[] ntpHosts);
        Task SetDnsAsync(bool useDhcp, IPAddress[] dnsAddresses, string[] dnsManual = null);
        Task SetNetworkDefaultGatewayAsync(string[] ipv4, string[] ipv6);
        Task SetZeroConfigurationAsync(string zeroConfInterfaceToken, bool zeroConfEnabled);
        Task SetHostNameAsync(string host = "");
        Task SetDiscoveryModeAsync(DiscoveryMode mode);
        Task SetNetworkInterfacesAsync(string token, NetworkInterfaceSetConfiguration config);
        Task<NetStatus> GetNetworkStatusAsync();
        Task<NetworkInterface[]> GetNetworkInterfacesAsync();
        Task<NTPInformation> GetNtpAsync();
        Task<HostnameInformation> GetHostNameAsync();
        Task<NetworkGateway> GetNetworkDefaultGatewayAsync();
        Task<DNSInformation> GetDnsAsync();
        Task<NetworkProtocol[]> GetNetworkProtocolsAsync();
        Task<DiscoveryMode> GetDiscoveryModeAsync();

        NetworkSettings GetNetworkSettings();
        void SetNetworkSettings(NetworkSettings networkSettings);
        NetworkInterface[] GetNetworkInterfaces();
        NTPInformation GetNtp();
        HostnameInformation GetHostName();
        NetworkGateway GetNetworkDefaultGateway();
        DNSInformation GetDns();
        NetworkProtocol[] GetNetworkProtocols();
        DiscoveryMode GetDiscoveryMode();
        void SetNetworkProtocols(NetworkProtocol[] protocols);
        void SetNtp(bool useDhcp, NetworkHost[] ntpHosts);
        void SetDns(bool useDhcp, IPAddress[] dnsAddresses, string[] dnsManual = null);
        void SetNetworkDefaultGateway(string[] ipv4, string[] ipv6);
        void SetZeroConfiguration(string zeroConfInterfaceToken, bool zeroConfEnabled);
        void SetHostName(string host = "");
        void SetDiscoveryMode(DiscoveryMode mode);
        void SetNetworkInterfaces(string token, NetworkInterfaceSetConfiguration config);
        NetStatus GetNetworkStatus();
    }
}
