using System.Threading.Tasks;
using Akka.Actor;
using onvif.services;
using Onvif.Camera.Client.Model;
using Onvif.Contracts.Messages.Onvif;
using Onvif.Contracts.Messages.Onvif.Network;
using Onvif.Contracts.Model;

namespace Onvif.Camera.Client
{
    public partial class OnvifClient
    {
        public async Task<OnvifResult> SetNetworkSettingsAsync(NetworkSettings networkSettings)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifSetNetworkSettings(_url, _userName, _password, networkSettings));
        }

        public OnvifResult SetNetworkSettings(NetworkSettings networkSettings)
        {
            return SetNetworkSettings(_url, _userName, _password, networkSettings);
        }

        public OnvifResult SetNetworkSettings(string url, string userName, string password, NetworkSettings networkSettings)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifSetNetworkSettings(url, userName, password, networkSettings)).Result;
        }

        public async Task<OnvifClientResult<NetworkSettings>> GetCameraNetworkSettingsAsync()
        {
            var result = await _proxyActor.Ask<Container<NetworkSettings>>(new OnvifGetNetworkSettings(_url, _userName, _password));
            return result.Success ? (OnvifClientResult<NetworkSettings>)new OnvifClientResultData<NetworkSettings>(result.WorkItem)
                : new OnvifClientResultEmpty<NetworkSettings>(new NetworkSettings());
        }

        public OnvifClientResult<NetworkSettings> GetCameraNetworkSettings()
        {
            return GetCameraNetworkSettings(_url, _userName, _password);
        }

        public OnvifClientResult<NetworkSettings> GetCameraNetworkSettings(string url, string userName, string password)
        {
            var result = _proxyActor.Ask<Container<NetworkSettings>>(new OnvifGetNetworkSettings(url, userName, password)).Result;
            return result.Success ? (OnvifClientResult<NetworkSettings>)new OnvifClientResultData<NetworkSettings>(result.WorkItem)
                : new OnvifClientResultEmpty<NetworkSettings>(new NetworkSettings());
        }

        public async Task<OnvifResult> SetNetworkProtocolsAsync(NetworkProtocol[] protocols)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifSetNetworkProtocols(_url, _userName, _password, protocols));
        }

        public OnvifResult SetNetworkProtocols(NetworkProtocol[] protocols)
        {
            return SetNetworkProtocols(_url, _userName, _password, protocols);
        }

        public OnvifResult SetNetworkProtocols(string url, string userName, string password, NetworkProtocol[] protocols)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifSetNetworkProtocols(url, userName, password, protocols)).Result;
        }

        public async Task<OnvifResult> SetNtpAsync(bool useDhcp, NetworkHost[] ntpHosts)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifSetNtp(_url, _userName, _password, useDhcp, ntpHosts));
        }

        public OnvifResult SetNtp(bool useDhcp, NetworkHost[] ntpHosts)
        {
            return SetNtp(_url, _userName, _password, useDhcp, ntpHosts);
        }

        public OnvifResult SetNtp(string url, string userName, string password, bool useDhcp, NetworkHost[] ntpHosts)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifSetNtp(url, userName, password, useDhcp, ntpHosts)).Result;
        }

        public async Task<OnvifResult> SetDnsAsync(bool useDhcp, IPAddress[] dnsAddresses, string[] dnsManual = null)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifSetDns(_url, _userName, _password, useDhcp, dnsAddresses, dnsManual));
        }

        public OnvifResult SetDns(bool useDhcp, IPAddress[] dnsAddresses, string[] dnsManual = null)
        {
            return SetDns(_url, _userName, _password, useDhcp, dnsAddresses, dnsManual);
        }

        public OnvifResult SetDns(string url, string userName, string password, bool useDhcp, IPAddress[] dnsAddresses, string[] dnsManual = null)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifSetDns(url, userName, password, useDhcp, dnsAddresses, dnsManual)).Result;
        }

        public async Task<OnvifResult> SetNetworkDefaultGatewayAsync(string[] ipv4, string[] ipv6)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifSetNetworkDefaultGateway(_url, _userName, _password, ipv4, ipv6));
        }

        public OnvifResult SetNetworkDefaultGateway(string[] ipv4, string[] ipv6)
        {
            return SetNetworkDefaultGateway(_url, _userName, _password, ipv4, ipv6);
        }

        public OnvifResult SetNetworkDefaultGateway(string url, string userName, string password, string[] ipv4, string[] ipv6)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifSetNetworkDefaultGateway(url, userName, password, ipv4, ipv6)).Result;
        }

        public async Task<OnvifResult> SetZeroConfigurationAsync(string zeroConfInterfaceToken, bool zeroConfEnabled)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifSetZeroConfiguration(_url, _userName, _password, zeroConfInterfaceToken, zeroConfEnabled));
        }

        public OnvifResult SetZeroConfiguration(string zeroConfInterfaceToken, bool zeroConfEnabled)
        {
            return SetZeroConfiguration(_url, _userName, _password, zeroConfInterfaceToken, zeroConfEnabled);
        }

        public OnvifResult SetZeroConfiguration(string url, string userName, string password, string zeroConfInterfaceToken, bool zeroConfEnabled)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifSetZeroConfiguration(url, userName, password, zeroConfInterfaceToken, zeroConfEnabled)).Result;
        }

        public async Task<OnvifResult> SetHostNameAsync(string host = "")
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifSetHostName(_url, _userName, _password, host));
        }

        public OnvifResult SetHostName(string host = "")
        {
            return SetHostName(_url, _userName, _password, host);
        }

        public OnvifResult SetHostName(string url, string userName, string password, string host = "")
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifSetHostName(url, userName, password, host)).Result;
        }

        public async Task<OnvifResult> SetDiscoveryModeAsync(DiscoveryMode mode)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifSetDiscoveryMode(_url, _userName, _password, mode));
        }

        public OnvifResult SetDiscoveryMode(DiscoveryMode mode)
        {
            return SetDiscoveryMode(_url, _userName, _password, mode);
        }

        public OnvifResult SetDiscoveryMode(string url, string userName, string password, DiscoveryMode mode)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifSetDiscoveryMode(url, userName, password, mode)).Result;
        }

        public async Task<OnvifResult> SetNetworkInterfacesAsync(string token, NetworkInterfaceSetConfiguration config)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifSetNetworkInterfaces(_url, _userName, _password, token, config));
        }

        public OnvifResult SetNetworkInterfaces(string token, NetworkInterfaceSetConfiguration config)
        {
            return SetNetworkInterfaces(_url, _userName, _password, token, config);
        }

        public OnvifResult SetNetworkInterfaces(string url, string userName, string password, string token, NetworkInterfaceSetConfiguration config)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifSetNetworkInterfaces(url, userName, password, token, config)).Result;
        }

        public async Task<OnvifClientResult<NetworkInterface[]>> GetNetworkInterfacesAsync()
        {
            var result = await _proxyActor.Ask<Container<NetworkInterface[]>>(new OnvifGetNetworkInterfaces(_url, _userName, _password));
            return result.Success ? (OnvifClientResult<NetworkInterface[]>)new OnvifClientResultData<NetworkInterface[]>(result.WorkItem)
                : new OnvifClientResultEmpty<NetworkInterface[]>(new NetworkInterface[0]);
        }

        public OnvifClientResult<NetworkInterface[]> GetNetworkInterfaces()
        {
            return GetNetworkInterfaces(_url, _userName, _password);
        }

        public OnvifClientResult<NetworkInterface[]> GetNetworkInterfaces(string url, string userName, string password)
        {
            var result = _proxyActor.Ask<Container<NetworkInterface[]>>(new OnvifGetNetworkInterfaces(url, userName, password)).Result;
            return result.Success ? (OnvifClientResult<NetworkInterface[]>)new OnvifClientResultData<NetworkInterface[]>(result.WorkItem)
                : new OnvifClientResultEmpty<NetworkInterface[]>(new NetworkInterface[0]);
        }

        public async Task<OnvifClientResult<NTPInformation>> GetNtpAsync()
        {
            var result = await _proxyActor.Ask<Container<NTPInformation>>(new OnvifGetNtp(_url, _userName, _password));
            return result.Success ? (OnvifClientResult<NTPInformation>)new OnvifClientResultData<NTPInformation>(result.WorkItem)
                : new OnvifClientResultEmpty<NTPInformation>(new NTPInformation());
        }

        public OnvifClientResult<NTPInformation> GetNtp()
        {
            return GetNtp(_url, _userName, _password);
        }

        public OnvifClientResult<NTPInformation> GetNtp(string url, string userName, string password)
        {
            var result = _proxyActor.Ask<Container<NTPInformation>>(new OnvifGetNtp(url, userName, password)).Result;
            return result.Success ? (OnvifClientResult<NTPInformation>)new OnvifClientResultData<NTPInformation>(result.WorkItem)
                : new OnvifClientResultEmpty<NTPInformation>(new NTPInformation());
        }

        public async Task<OnvifClientResult<HostnameInformation>> GetHostNameAsync()
        {
            var result = await _proxyActor.Ask<Container<HostnameInformation>>(new OnvifGetHostName(_url, _userName, _password));
            return result.Success ? (OnvifClientResult<HostnameInformation>)new OnvifClientResultData<HostnameInformation>(result.WorkItem)
                : new OnvifClientResultEmpty<HostnameInformation>(new HostnameInformation());
        }

        public OnvifClientResult<HostnameInformation> GetHostName()
        {
            return GetHostName(_url, _userName, _password);
        }

        public OnvifClientResult<HostnameInformation> GetHostName(string url, string userName, string password)
        {
            var result = _proxyActor.Ask<Container<HostnameInformation>>(new OnvifGetHostName(url, userName, password)).Result;
            return result.Success ? (OnvifClientResult<HostnameInformation>)new OnvifClientResultData<HostnameInformation>(result.WorkItem)
                : new OnvifClientResultEmpty<HostnameInformation>(new HostnameInformation());
        }

        public async Task<OnvifClientResult<NetworkGateway>> GetNetworkDefaultGatewayAsync()
        {
            var result = await _proxyActor.Ask<Container<NetworkGateway>>(new OnvifGetNetworkDefaultGateway(_url, _userName, _password));
            return result.Success ? (OnvifClientResult<NetworkGateway>)new OnvifClientResultData<NetworkGateway>(result.WorkItem)
                : new OnvifClientResultEmpty<NetworkGateway>(new NetworkGateway());
        }

        public OnvifClientResult<NetworkGateway> GetNetworkDefaultGateway()
        {
            return GetNetworkDefaultGateway(_url, _userName, _password);
        }

        public OnvifClientResult<NetworkGateway> GetNetworkDefaultGateway(string url, string userName, string password)
        {
            var result = _proxyActor.Ask<Container<NetworkGateway>>(new OnvifGetNetworkDefaultGateway(url, userName, password)).Result;
            return result.Success ? (OnvifClientResult<NetworkGateway>)new OnvifClientResultData<NetworkGateway>(result.WorkItem)
                : new OnvifClientResultEmpty<NetworkGateway>(new NetworkGateway());
        }

        public async Task<OnvifClientResult<DNSInformation>> GetDnsAsync()
        {
            var result = await _proxyActor.Ask<Container<DNSInformation>>(new OnvifGetDns(_url, _userName, _password));
            return result.Success ? (OnvifClientResult<DNSInformation>)new OnvifClientResultData<DNSInformation>(result.WorkItem)
                : new OnvifClientResultEmpty<DNSInformation>(new DNSInformation());
        }

        public OnvifClientResult<DNSInformation> GetDns()
        {
            return GetDns(_url, _userName, _password);
        }

        public OnvifClientResult<DNSInformation> GetDns(string url, string userName, string password)
        {
            var result = _proxyActor.Ask<Container<DNSInformation>>(new OnvifGetDns(url, userName, password)).Result;
            return result.Success ? (OnvifClientResult<DNSInformation>)new OnvifClientResultData<DNSInformation>(result.WorkItem)
                : new OnvifClientResultEmpty<DNSInformation>(new DNSInformation());
        }

        public async Task<OnvifClientResult<NetworkProtocol[]>> GetNetworkProtocolsAsync()
        {
            var result = await _proxyActor.Ask<Container<NetworkProtocol[]>>(new OnvifGetNetworkProtocols(_url, _userName, _password));
            return result.Success ? (OnvifClientResult<NetworkProtocol[]>)new OnvifClientResultData<NetworkProtocol[]>(result.WorkItem)
                : new OnvifClientResultEmpty<NetworkProtocol[]>(new NetworkProtocol[0]);
        }

        public OnvifClientResult<NetworkProtocol[]> GetNetworkProtocols()
        {
            return GetNetworkProtocols(_url, _userName, _password);
        }

        public OnvifClientResult<NetworkProtocol[]> GetNetworkProtocols(string url, string userName, string password)
        {
            var result = _proxyActor.Ask<Container<NetworkProtocol[]>>(new OnvifGetNetworkProtocols(url, userName, password)).Result;
            return result.Success ? (OnvifClientResult<NetworkProtocol[]>)new OnvifClientResultData<NetworkProtocol[]>(result.WorkItem)
                : new OnvifClientResultEmpty<NetworkProtocol[]>(new NetworkProtocol[0]);
        }

        public async Task<OnvifClientResult<DiscoveryMode>> GetDiscoveryModeAsync()
        {
            var result = await _proxyActor.Ask<Container<DiscoveryMode>>(new OnvifGetDiscoveryMode(_url, _userName, _password));
            return result.Success ? (OnvifClientResult<DiscoveryMode>)new OnvifClientResultData<DiscoveryMode>(result.WorkItem)
                : new OnvifClientResultEmpty<DiscoveryMode>(DiscoveryMode.nonDiscoverable);
        }

        public OnvifClientResult<DiscoveryMode> GetDiscoveryMode()
        {
            return GetDiscoveryMode(_url, _userName, _password);
        }

        public OnvifClientResult<DiscoveryMode> GetDiscoveryMode(string url, string userName, string password)
        {
            var result = _proxyActor.Ask<Container<DiscoveryMode>>(new OnvifGetDiscoveryMode(url, userName, password)).Result;
            return result.Success ? (OnvifClientResult<DiscoveryMode>)new OnvifClientResultData<DiscoveryMode>(result.WorkItem)
                : new OnvifClientResultEmpty<DiscoveryMode>(DiscoveryMode.nonDiscoverable);
        }
    }
}
