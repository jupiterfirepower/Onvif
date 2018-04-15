using onvif.services;
using Onvif.Camera.Client.Model;
using Onvif.Contracts.Messages.Onvif;
using Onvif.Contracts.Model;

namespace Onvif.Camera.Client.Contracts
{
    public interface IOnvifClientNetworkSync
    {
        OnvifResult SetNetworkSettings(NetworkSettings networkSettings);
        OnvifClientResult<NetworkSettings> GetCameraNetworkSettings();
        OnvifResult SetNetworkProtocols(NetworkProtocol[] protocols);
        OnvifResult SetNtp(bool useDhcp, NetworkHost[] ntpHosts);
        OnvifResult SetDns(bool useDhcp, IPAddress[] dnsAddresses, string[] dnsManual = null);
        OnvifResult SetNetworkDefaultGateway(string[] ipv4, string[] ipv6);
        OnvifResult SetZeroConfiguration(string zeroConfInterfaceToken, bool zeroConfEnabled);
        OnvifResult SetHostName(string host = "");
        OnvifResult SetDiscoveryMode(DiscoveryMode mode);
        OnvifResult SetNetworkInterfaces(string token, NetworkInterfaceSetConfiguration config);
        OnvifClientResult<NetworkInterface[]> GetNetworkInterfaces();
        OnvifClientResult<NTPInformation> GetNtp();
        OnvifClientResult<HostnameInformation> GetHostName();
        OnvifClientResult<NetworkGateway> GetNetworkDefaultGateway();
        OnvifClientResult<DNSInformation> GetDns();
        OnvifClientResult<NetworkProtocol[]> GetNetworkProtocols();
        OnvifClientResult<DiscoveryMode> GetDiscoveryMode();

        OnvifResult SetNetworkSettings(string url, string userName, string password, NetworkSettings networkSettings);
        OnvifClientResult<NetworkSettings> GetCameraNetworkSettings(string url, string userName, string password);
        OnvifResult SetNetworkProtocols(string url, string userName, string password, NetworkProtocol[] protocols);
        OnvifResult SetNtp(string url, string userName, string password, bool useDhcp, NetworkHost[] ntpHosts);
        OnvifResult SetDns(string url, string userName, string password, bool useDhcp, IPAddress[] dnsAddresses, string[] dnsManual = null);
        OnvifResult SetNetworkDefaultGateway(string url, string userName, string password, string[] ipv4, string[] ipv6);
        OnvifResult SetZeroConfiguration(string url, string userName, string password, string zeroConfInterfaceToken, bool zeroConfEnabled);
        OnvifResult SetHostName(string url, string userName, string password, string host = "");
        OnvifResult SetDiscoveryMode(string url, string userName, string password, DiscoveryMode mode);
        OnvifResult SetNetworkInterfaces(string url, string userName, string password, string token, NetworkInterfaceSetConfiguration config);
        OnvifClientResult<NetworkInterface[]> GetNetworkInterfaces(string url, string userName, string password);
        OnvifClientResult<NTPInformation> GetNtp(string url, string userName, string password);
        OnvifClientResult<HostnameInformation> GetHostName(string url, string userName, string password);
        OnvifClientResult<NetworkGateway> GetNetworkDefaultGateway(string url, string userName, string password);
        OnvifClientResult<DNSInformation> GetDns(string url, string userName, string password);
        OnvifClientResult<NetworkProtocol[]> GetNetworkProtocols(string url, string userName, string password);
        OnvifClientResult<DiscoveryMode> GetDiscoveryMode(string url, string userName, string password);
    }
}
