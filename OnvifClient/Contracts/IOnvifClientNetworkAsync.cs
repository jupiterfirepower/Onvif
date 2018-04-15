using System.Threading.Tasks;
using onvif.services;
using Onvif.Camera.Client.Model;
using Onvif.Contracts.Messages.Onvif;
using Onvif.Contracts.Model;

namespace Onvif.Camera.Client.Contracts
{
    public interface IOnvifClientNetworkAsync
    {
        Task<OnvifClientResult<NetworkSettings>> GetCameraNetworkSettingsAsync();
        Task<OnvifResult> SetNetworkSettingsAsync(NetworkSettings networkSettings);
        Task<OnvifResult> SetNetworkProtocolsAsync(NetworkProtocol[] protocols);
        Task<OnvifResult> SetNtpAsync(bool useDhcp, NetworkHost[] ntpHosts);
        Task<OnvifResult> SetDnsAsync(bool useDhcp, IPAddress[] dnsAddresses, string[] dnsManual = null);
        Task<OnvifResult> SetNetworkDefaultGatewayAsync(string[] ipv4, string[] ipv6);
        Task<OnvifResult> SetZeroConfigurationAsync(string zeroConfInterfaceToken, bool zeroConfEnabled);
        Task<OnvifResult> SetHostNameAsync(string host = "");
        Task<OnvifResult> SetDiscoveryModeAsync(DiscoveryMode mode);
        Task<OnvifResult> SetNetworkInterfacesAsync(string token, NetworkInterfaceSetConfiguration config);
        Task<OnvifClientResult<NetworkInterface[]>> GetNetworkInterfacesAsync();
        Task<OnvifClientResult<NTPInformation>> GetNtpAsync();
        Task<OnvifClientResult<HostnameInformation>> GetHostNameAsync();
        Task<OnvifClientResult<NetworkGateway>> GetNetworkDefaultGatewayAsync();
        Task<OnvifClientResult<DNSInformation>> GetDnsAsync();
        Task<OnvifClientResult<NetworkProtocol[]>> GetNetworkProtocolsAsync();
        Task<OnvifClientResult<DiscoveryMode>> GetDiscoveryModeAsync();

        
    }
}
