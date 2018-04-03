using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;
using odm.core;
using odm.onvif;
using onvif.services;
using onvif.utils;
using Onvif.Contracts.Model;
using Onvif.Proxy.Contracts;
using utils;
using DateTime = onvif.services.DateTime;
using Profile = onvif.services.Profile;
using TimeZone = onvif.services.TimeZone;

namespace Onvif.Proxy
{
    public class OnvifProxy : IOnvifProxy
    {
        private INvtSession _session;
        private OdmSession _facade;
        private NvtSessionFactory _factory;

        #region Constructor
        public OnvifProxy(NetworkCredential networkCredential, Uri uri)
        {
            _factory = new NvtSessionFactory(networkCredential);
            _session = _factory.CreateSession(uri);
            _facade = new OdmSession(_session);
        }
        #endregion

        #region OdmSession

        public bool IsAnalyticsSupported
        {
            get
            {
                return _facade.IsAnalyticsSupported().StartAsTask().Result;
            }
            
        }

        public bool IsEventsSupported
        {
            get
            {
                return _facade.IsEventsSupported().StartAsTask().Result;
            }
        }

        public bool IsFirmwareUpgradeSupported
        {
            get
            {
                return _facade.IsFirmwareUpgradeSupported().StartAsTask().Result;
            }
        }

        public bool IsPtzSupported
        {
            get
            {
                return _facade.IsPtzSupported().StartAsTask().Result;
            }
        }

        public bool IsZeroConfigurationSupported
        {
            get
            {
                return _facade.IsZeroConfigurationSupported().StartAsTask().Result;
            }
        }

        public async Task<System.Xml.Schema.XmlSchemaSet> DownloadSchemesAsync(string[] uris)
        {
            return await _facade.DownloadSchemes(uris);
        }

        public System.Xml.Schema.XmlSchemaSet DownloadSchemes(string[] uris)
        {
            return _facade.DownloadSchemes(uris).StartAsTask().Result;
        }

        public IObservable<OnvifEvent> GetBaseEvents(int port, FilterType type)
        {
            return _facade.GetBaseEvents(port, type);
        }

        public IObservable<OnvifEvent> GetPullPointEvents()
        {
            return _facade.GetPullPointEvents();
        }

        public async Task<Stream> DownloadStream(Uri uri, string accept)
        {
            return await _facade.DownloadStream(uri, accept);
        }

        public async Task<Stream> FtpDownload(Uri uri)
        {
            return await _facade.FtpDownload(uri);
        }

        public async Task<IChannel> GetChannelAsync(string profileToken)
        {
            return await _facade.GetChannel(profileToken);
        }

        public IChannel GetChannel(string profileToken)
        {
            return _facade.GetChannel(profileToken).StartAsTask().Result;
        }

        public async Task<ChannelDescription[]> GetChannelDescriptions()
        {
            return await _facade.GetChannelDescriptions();
        }

        public async Task<Stream> GetSnapshot(string token)
        {
            return await _facade.GetSnapshot(token);
        }

        public async Task<SupportedFirmwareUpgradeModes> GetSupportedFirmwareUpgradeModesAsync(string token)
        {
            return await _facade.GetSupportedFirmwareUpgradeModes();
        }

        public SupportedFirmwareUpgradeModes GetSupportedFirmwareUpgradeModes(string token)
        {
            return _facade.GetSupportedFirmwareUpgradeModes().StartAsTask().Result;
        }

        public async Task RestoreSystem(string backUpPath)
        {
            await _facade.RestoreSystem(backUpPath);
        }

        public async Task<string> UpgradeFirmware(string firmwarePath)
        {
            return await _facade.UpgradeFirmware(firmwarePath);
        }

        public async Task<string> UpgradeFirmware(Uri uri, Stream strem, string contentType, NetworkCredential  networkCredential)
        {
            return await _facade.UploadStream(uri, strem, contentType, networkCredential);
        }

        public INvtSession GetNvtSession()
        {
            return _session;
        }

        public OdmSession OdmSession
        {
            get
            {
                return _facade;
            }
        }
        #endregion

        #region NvtSession
        public INvtSession Session
        {
            get
            {
                return _session;
            }
        }
        #endregion

        #region Events
        public IObservable<OnvifEvent> GetPullPointEvents(TopicExpressionFilter[] topArray, MessageContentFilter[] contArray)
        {
            return _facade.GetPullPointEvents(topArray, contArray);
        }

        public IObservable<OnvifEvent> GetAllPullPointEvents()
        {
            return _facade.GetPullPointEvents();
        }

        public IObservable<OnvifEvent> GetPullPointEvents(FilterType filter)
        {
            return _facade.GetPullPointEvents(filter);
        }

        public IObservable<OnvifEvent> GetPullPointEvents(IEnumerable<XElement> filter)
        {
            return _facade.GetPullPointEvents(filter);
        }
        
        public IObservable<OnvifEvent> GetBaseEvents(int port, MessageContentFilter[] contArray, TopicExpressionFilter[] topArray)
        {
            return _facade.GetBaseEvents(port, topArray, contArray);
        }

        public IObservable<OnvifEvent> GetBaseEvents(int port)
        {
            return _facade.GetBaseEvents(port);
        }

        public IObservable<OnvifEvent> GetBaseEvents(FilterType filter, int port )
        {
            return _facade.GetBaseEvents(port, filter);
        }

        public IObservable<OnvifEvent> GetBaseEvents(IEnumerable<XElement> filter, int port)
        {
            return _facade.GetBaseEvents(port, filter);
        }
        #endregion

        #region Identification
        public async Task<DeviceInfo> GetDeviceInformationAsync()
        {
            var device = await _session.GetDeviceInformation();
            var scopes = await _session.GetScopes();
            var zeroConf = await _facade.IsZeroConfigurationSupported().StartAsTask() ? await _session.GetZeroConfiguration().StartAsTask() : null;
            var nics = await _session.GetNetworkInterfaces();
            var caps = await _session.GetCapabilities();

            var result = new DeviceInfo 
            { 
                Manufacturer = device.Manufacturer, 
                Model = device.Model, 
                FirmwareVersion = device.FirmwareVersion, 
                HardwareId = device.HardwareId, 
                SerialNumber = device.SerialNumber
            };

            var onvifVersion =
                NotNull(caps.device) && NotNull(caps.device.system) && NotNull(caps.device.system.supportedVersions)
                    ? caps.device.system.supportedVersions.Max()
                    : null;
            if (onvifVersion != null) result.OnvifVersion = onvifVersion.ToString();

            Tuple<string, PrefixedIPv4Address[]> nicInfs = null;

            if (nics != null)
            {
               System.Array.ForEach(nics, nic =>
               {
                   if (nic.enabled && NotNull(nic.iPv4) && NotNull(nic.iPv4.config))
                   {
                       var nicCfg = nic.iPv4.config;
                       var mac = nic.info != null ? nic.info.hwAddress.Replace(':', '-').ToUpper() : null;
                       if (nicCfg.dhcp && NotNull(nicCfg.fromDHCP))
                       {
                           nicInfs = Tuple.Create(mac, new[] { nicCfg.fromDHCP});
                       }
                       else if(!nicCfg.dhcp && NotNull(nicCfg.manual) && nicCfg.manual.Any())
                       {
                           nicInfs = Tuple.Create(mac, nicCfg.manual);
                       }
                   }
               });
            }

            if (nicInfs != null)
            {
                var ips = nicInfs.Item2.Select(addr => addr.address != null
                    ? addr.address.Trim()
                    : null).Where(x=>x!=null).ToArray();
                if (!ips.Any())
                {
                    ips = (zeroConf != null && NotNull(zeroConf.addresses)
                            ? zeroConf.addresses.ToArray()
                            : null);
                }
                
                result.Mac = String.Join(", ", nicInfs.Item1);
                if (ips != null)
                {
                    result.IpAddress = ips.Any() ? String.Join(", ", ips.Distinct().ToArray()) : string.Empty;
                }
            }

            result.OriginName = ScopeHelper.GetName(scopes.Select(x => x.scopeItem));
            result.OriginLocation = ScopeHelper.GetLocation(scopes.Select(x => x.scopeItem));

            return result;
        }

        public DeviceInfo GetDeviceInformation()
        {
            var device = _session.GetDeviceInformation().StartAsTask().Result;
            var scopes = _session.GetScopes().StartAsTask().Result;
            var zeroConf = _facade.IsZeroConfigurationSupported().StartAsTask().Result ? _session.GetZeroConfiguration().StartAsTask().Result : null;
            var nics = _session.GetNetworkInterfaces().StartAsTask().Result;
            var caps = _session.GetCapabilities().StartAsTask().Result;

            var result = new DeviceInfo
            {
                Manufacturer = device.Manufacturer,
                Model = device.Model,
                FirmwareVersion = device.FirmwareVersion,
                HardwareId = device.HardwareId,
                SerialNumber = device.SerialNumber
            };

            var onvifVersion =
                NotNull(caps.device) && NotNull(caps.device.system) && NotNull(caps.device.system.supportedVersions)
                    ? caps.device.system.supportedVersions.Max()
                    : null;
            if (onvifVersion != null) result.OnvifVersion = onvifVersion.ToString();

            Tuple<string, PrefixedIPv4Address[]> nicInfs = null;

            if (nics != null)
            {
                System.Array.ForEach(nics, nic =>
                {
                    if (nic.enabled && NotNull(nic.iPv4) && NotNull(nic.iPv4.config))
                    {
                        var nicCfg = nic.iPv4.config;
                        var mac = nic.info != null ? nic.info.hwAddress.Replace(':', '-').ToUpper() : null;
                        if (nicCfg.dhcp && NotNull(nicCfg.fromDHCP))
                        {
                            nicInfs = Tuple.Create(mac, new[] { nicCfg.fromDHCP });
                        }
                        else if (!nicCfg.dhcp && NotNull(nicCfg.manual) && nicCfg.manual.Any())
                        {
                            nicInfs = Tuple.Create(mac, nicCfg.manual);
                        }
                    }
                });
            }

            if (nicInfs != null)
            {
                var ips = nicInfs.Item2.Select(addr => addr.address != null
                    ? addr.address.Trim()
                    : null).Where(x => x != null).ToArray();
                if (!ips.Any())
                {
                    ips = (zeroConf != null && NotNull(zeroConf.addresses)
                            ? zeroConf.addresses.ToArray()
                            : null);
                }

                result.Mac = String.Join(", ", nicInfs.Item1);
                if (ips != null)
                {
                    result.IpAddress = ips.Any() ? String.Join(", ", ips.Distinct().ToArray()) : string.Empty;
                }
            }

            result.OriginName = ScopeHelper.GetName(scopes.Select(x => x.scopeItem));
            result.OriginLocation = ScopeHelper.GetLocation(scopes.Select(x => x.scopeItem));

            return result;
        }

        public async Task SetDeviceNameAsync(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                var devInfo = await GetDeviceInformationAsync();
                devInfo.Name = name;
                await SetDeviceIdentificationAsync(devInfo);
            }
        }

        public void SetDeviceName(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                var devInfo = GetDeviceInformation();
                devInfo.Name = name;
                SetDeviceIdentification(devInfo);
            }
        }

        public async Task SetDeviceLocationAsync(string location)
        {
            if (!string.IsNullOrEmpty(location))
            {
                var devInfo = await GetDeviceInformationAsync();
                devInfo.Location = location;
                await SetDeviceIdentificationAsync(devInfo);
            }
        }

        public void SetDeviceLocation(string location)
        {
            if (!string.IsNullOrEmpty(location))
            {
                var devInfo = GetDeviceInformation();
                devInfo.Location = location;
                SetDeviceIdentification(devInfo);
            }
        }

        public async Task SetDeviceIdentificationAsync(DeviceInfo devInfo)
        {
            var changedScopes = new List<Tuple<string,string>>();
            var nameChanged = !string.IsNullOrEmpty(devInfo.Name) && devInfo.Name != devInfo.OriginName;
            var locationChanged = !string.IsNullOrEmpty(devInfo.Location) && devInfo.Location != devInfo.OriginLocation;
            var modified = nameChanged || locationChanged;

            if (modified)
            {
                var scopes = await _session.GetScopes();
                if (nameChanged)
                {
                    var useOnvifScopes = scopes.Where(x => x.scopeDef == ScopeDefinition.@fixed)
                        .All(x => !x.scopeItem.StartsWith(ScopeHelper.onvifNameScope));
                    var prefix = useOnvifScopes ? ScopeHelper.onvifNameScope :
                    ScopeHelper.odmNameScope;
                    var value = Uri.EscapeUriString(devInfo.Name);
                    changedScopes.Add(Tuple.Create(prefix, value)); 
                }

                if (locationChanged)
                {
                    var useOnvifScopes = scopes.Where(x => x.scopeDef == ScopeDefinition.@fixed)
                        .All(x => !x.scopeItem.StartsWith(ScopeHelper.onvifLocationScope));
                    var prefix = useOnvifScopes ? ScopeHelper.onvifLocationScope :
                    ScopeHelper.odmLocationScope;

                    var data = devInfo.Location.Split(';').
                        Select(x =>!string.IsNullOrEmpty(x.Trim()) ? Uri.EscapeUriString(x.Trim()) : null).
                        Where(x=>x!=null).ToList();
                    data.ForEach(x=>changedScopes.Add(Tuple.Create(prefix, x)));
                }

                var changed = scopes.Where(x => x.scopeDef == ScopeDefinition.configurable).
                    Select(x => x.scopeItem).
                    Where(x => changedScopes.All(t => !(x.StartsWith(t.Item1))));

                var scopesToSet = changedScopes.Select(x => string.Concat(x.Item1, x.Item2)).ToList();
                scopesToSet.AddRange(changed);
                await _session.SetScopes(scopesToSet.ToArray());
            }
        }

        public void SetDeviceIdentification(DeviceInfo devInfo)
        {
            var changedScopes = new List<Tuple<string, string>>();
            var nameChanged = !string.IsNullOrEmpty(devInfo.Name) && devInfo.Name != devInfo.OriginName;
            var locationChanged = !string.IsNullOrEmpty(devInfo.Location) && devInfo.Location != devInfo.OriginLocation;
            var modified = nameChanged || locationChanged;

            if (modified)
            {
                var scopes = _session.GetScopes().StartAsTask().Result;
                if (nameChanged)
                {
                    var useOnvifScopes = scopes.Where(x => x.scopeDef == ScopeDefinition.@fixed)
                        .All(x => !x.scopeItem.StartsWith(ScopeHelper.onvifNameScope));
                    var prefix = useOnvifScopes ? ScopeHelper.onvifNameScope :
                    ScopeHelper.odmNameScope;
                    var value = Uri.EscapeUriString(devInfo.Name);
                    changedScopes.Add(Tuple.Create(prefix, value));
                }

                if (locationChanged)
                {
                    var useOnvifScopes = scopes.Where(x => x.scopeDef == ScopeDefinition.@fixed)
                        .All(x => !x.scopeItem.StartsWith(ScopeHelper.onvifLocationScope));
                    var prefix = useOnvifScopes ? ScopeHelper.onvifLocationScope :
                    ScopeHelper.odmLocationScope;

                    var data = devInfo.Location.Split(';').
                        Select(x => !string.IsNullOrEmpty(x.Trim()) ? Uri.EscapeUriString(x.Trim()) : null).
                        Where(x => x != null).ToList();
                    data.ForEach(x => changedScopes.Add(Tuple.Create(prefix, x)));
                }

                var changed = scopes.Where(x => x.scopeDef == ScopeDefinition.configurable).
                    Select(x => x.scopeItem).
                    Where(x => changedScopes.All(t => !(x.StartsWith(t.Item1))));

                var scopesToSet = changedScopes.Select(x => string.Concat(x.Item1, x.Item2)).ToList();
                scopesToSet.AddRange(changed);
                _session.SetScopes(scopesToSet.ToArray());
            }
        }

        public async Task SetScopesAsync(string[] scopes)
        {
            await _session.SetScopes(scopes);
        }

        public void SetScopes(string[] scopes)
        {
            _session.SetScopes(scopes).RunSynchronously();
        }

        public async Task SetNameLocationAsync(string name, string location)
        {
            await _facade.SetNameLocation(name, location);
        }

        public void SetNameLocation(string name, string location)
        {
            _facade.SetNameLocation(name, location).RunSynchronously();
        }

        #endregion

        #region Network Settings
        public async Task<NetworkSettings> GetNetworkSettingsAsync()
        {
            var dev =  (IDeviceAsync)_session;
            var nics = await dev.GetNetworkInterfaces();
            var ntpInfo = await dev.GetNTP();
            var zeroConfSupported = await _facade.IsZeroConfigurationSupported();
            var zeroConf = await _facade.IsZeroConfigurationSupported() ? await dev.GetZeroConfiguration() : null;
            var host = await dev.GetHostname();
            var gatewayInfo = await dev.GetNetworkDefaultGateway();
            var dnsInfo = await dev.GetDNS();
            var netProtocols = await dev.GetNetworkProtocols();
            var dicoveryMode = await dev.GetDiscoveryMode();
            var zeroConfIp = zeroConfSupported && zeroConf != null && NotNull(zeroConf.addresses)
                ? zeroConf.addresses.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray()
                : new[] { string.Empty };

            var ntp = ntpInfo.ntpManual != null && ntpInfo.ntpManual.Length > 0 ? ntpInfo.ntpManual : ntpInfo.ntpFromDHCP;
            string[] addresses = { String.Empty };

            if (gatewayInfo != null)
            {
                addresses = gatewayInfo.iPv4Address != null
                    ? gatewayInfo.iPv4Address.Where(ip => !string.IsNullOrWhiteSpace(ip))
                        .Select(ip => ip.Trim())
                        .ToArray() : null;
                if (gatewayInfo.iPv6Address != null)
                {
                    addresses.AddRange(gatewayInfo.iPv6Address.Where(ip => !string.IsNullOrWhiteSpace(ip))
                        .Select(ip => ip.Trim())
                        .ToArray());
                }
            }

            IEnumerable<string> ipAddrs = null;
            var dns = dnsInfo.dnsManual != null && dnsInfo.dnsManual.Length > 0 ? dnsInfo.dnsManual : dnsInfo.dnsFromDHCP;
            if (dns != null)
            {
                ipAddrs = dns.Where(x => string.IsNullOrWhiteSpace(x.iPv4Address)).Select(x=>x.iPv4Address);
            }

            var nic = nics.FirstOrDefault(x => x.enabled);

            var result = new NetworkSettings
            {
                ZeroConfIp = String.Join("; ", zeroConfIp),
                ZeroConfSupported = zeroConfSupported,
                DiscoveryModeSupported = true,
                ZeroConfEnabled = zeroConfSupported && zeroConf != null && zeroConf.enabled,
                UseHostFromDhcp = host.fromDHCP,
                Host = host.name,
                NetProtocols = netProtocols,
                DiscoveryMode = dicoveryMode,
                UseNtpFromDhcp = ntpInfo.fromDHCP,
                NtpServers = String.Join("; ", ntp.Where(n=>!string.IsNullOrWhiteSpace(OdmSession.NetHostToStr(n))).Select(OdmSession.NetHostToStr)),
                Gateway = String.Join(";", addresses),
                Dns = String.Join("; ", ipAddrs),
                Dhcp = nic != null && nic.iPv4.config.dhcp
            };

            if (nic == null)
            {
                result.Dhcp = false;
                result.Ip = "255.255.255.255";
                result.Subnet = "255.255.255.255";
            }
            else
            {
                var nicCfg = nic.iPv4.config;
                if (nicCfg.manual != null && nicCfg.manual.Length > 0)
                {
                    var ipInfo = nicCfg.manual[0];
                    result.Ip = ipInfo.address;
                    result.Subnet = NetMaskHelper.CidrToIpMask(ipInfo.prefixLength).ToString();
                }
                else if (nicCfg.fromDHCP != null)
                {
                    result.Ip = nicCfg.fromDHCP.address;
                    result.Subnet = NetMaskHelper.CidrToIpMask(nicCfg.fromDHCP.prefixLength).ToString();
                }
            }

            return result;
        }

        public NetworkSettings GetNetworkSettings()
        {
            var dev = (IDeviceAsync)_session;
            var nics = dev.GetNetworkInterfaces().StartAsTask().Result;
            var ntpInfo = dev.GetNTP().StartAsTask().Result;
            var zeroConfSupported = _facade.IsZeroConfigurationSupported().StartAsTask().Result;
            var zeroConf = _facade.IsZeroConfigurationSupported().StartAsTask().Result ? dev.GetZeroConfiguration().StartAsTask().Result : null;
            var host = dev.GetHostname().StartAsTask().Result;
            var gatewayInfo = dev.GetNetworkDefaultGateway().StartAsTask().Result;
            var dnsInfo = dev.GetDNS().StartAsTask().Result;
            var netProtocols = dev.GetNetworkProtocols().StartAsTask().Result;
            var dicoveryMode = dev.GetDiscoveryMode().StartAsTask().Result;

            var zeroConfIp = zeroConfSupported && zeroConf != null && NotNull(zeroConf.addresses)
                ? zeroConf.addresses.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray()
                : new[] { string.Empty };

            var ntp = ntpInfo.ntpManual != null && ntpInfo.ntpManual.Length > 0 ? ntpInfo.ntpManual : ntpInfo.ntpFromDHCP;
            string[] addresses = { String.Empty };

            if (gatewayInfo != null)
            {
                addresses = gatewayInfo.iPv4Address != null
                    ? gatewayInfo.iPv4Address.Where(ip => !string.IsNullOrWhiteSpace(ip))
                        .Select(ip => ip.Trim())
                        .ToArray() : null;
                if (gatewayInfo.iPv6Address != null)
                {
                    addresses.AddRange(gatewayInfo.iPv6Address.Where(ip => !string.IsNullOrWhiteSpace(ip))
                        .Select(ip => ip.Trim())
                        .ToArray());
                }
            }

            IEnumerable<string> ipAddrs = null;
            var dns = dnsInfo.dnsManual != null && dnsInfo.dnsManual.Length > 0 ? dnsInfo.dnsManual : dnsInfo.dnsFromDHCP;
            if (dns != null)
            {
                ipAddrs = dns.Where(x => string.IsNullOrWhiteSpace(x.iPv4Address)).Select(x => x.iPv4Address);
            }

            var nic = nics.FirstOrDefault(x => x.enabled);

            var result = new NetworkSettings
            {
                ZeroConfIp = String.Join("; ", zeroConfIp),
                ZeroConfSupported = zeroConfSupported,
                DiscoveryModeSupported = true,
                ZeroConfEnabled = zeroConfSupported && zeroConf != null && zeroConf.enabled,
                UseHostFromDhcp = host.fromDHCP,
                Host = host.name,
                NetProtocols = netProtocols,
                DiscoveryMode = dicoveryMode,
                UseNtpFromDhcp = ntpInfo.fromDHCP,
                NtpServers = String.Join("; ", ntp.Where(n => !string.IsNullOrWhiteSpace(OdmSession.NetHostToStr(n))).Select(OdmSession.NetHostToStr)),
                Gateway = String.Join(";", addresses),
                Dns = String.Join("; ", ipAddrs),
                Dhcp = nic != null && nic.iPv4.config.dhcp
            };

            if (nic == null)
            {
                result.Dhcp = false;
                result.Ip = "255.255.255.255";
                result.Subnet = "255.255.255.255";
            }
            else
            {
                var nicCfg = nic.iPv4.config;
                if (nicCfg.manual != null && nicCfg.manual.Length > 0)
                {
                    var ipInfo = nicCfg.manual[0];
                    result.Ip = ipInfo.address;
                    result.Subnet = NetMaskHelper.CidrToIpMask(ipInfo.prefixLength).ToString();
                }
                else if (nicCfg.fromDHCP != null)
                {
                    result.Ip = nicCfg.fromDHCP.address;
                    result.Subnet = NetMaskHelper.CidrToIpMask(nicCfg.fromDHCP.prefixLength).ToString();
                }
            }

            return result;
        }

        public async Task SetNetworkSettingsAsync(NetworkSettings networkSettings)
        {
            var currentNetProtocols = networkSettings.NetProtocols ?? new NetworkProtocol[0];
            await _session.SetNetworkProtocols(currentNetProtocols);
            var ntpAddresses = networkSettings.NtpServers.Split(new[] { ';',' ',',' }, StringSplitOptions.RemoveEmptyEntries).
                Where(x => !string.IsNullOrWhiteSpace(x)).
                Select(OdmSession.NetHostFromStr);

            var useDhcp = networkSettings.Dhcp && networkSettings.UseNtpFromDhcp;
            await _session.SetNTP(useDhcp, ntpAddresses.ToArray());

            var dnsAddresses = networkSettings.Dns.Split(new[] { ';', ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).
                Where(x => !string.IsNullOrWhiteSpace(x)).
                Select(x => new onvif.services.IPAddress { type = IPType.iPv4, iPv4Address = x });

            await _session.SetDNS(useDhcp, null, dnsAddresses.ToArray());

            var ips = networkSettings.Dns.Split(new[] { ';', ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).
                Select(x =>
                {
                    System.Net.IPAddress ip;
                    var valid = System.Net.IPAddress.TryParse(x.Trim(), out ip);
                    return valid ? ip : null;
                }).Where(x=>x!= null).ToArray();

            var ipv4 = ips.Where(x => x.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).
                           Select(x => x.ToString()).ToArray();

            var ipv6= ips.Where(x => x.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6).
                           Select(x => x.ToString()).ToArray();

            await _session.SetNetworkDefaultGateway(ipv4, ipv6);

            var zeroConf = await _session.GetZeroConfiguration();
            await _session.SetZeroConfiguration(zeroConf.interfaceToken, networkSettings.ZeroConfEnabled);
            
            if (networkSettings.UseHostFromDhcp)
            {
                await _session.SetHostname(string.Empty);
            }
            else
            {
                await _session.SetHostname(networkSettings.Host ?? string.Empty);
            }
            await _session.SetDiscoveryMode(networkSettings.DiscoveryMode);

            var nics = await _session.GetNetworkInterfaces();
            var nic = nics.FirstOrDefault(x => x.enabled);
            var nicSet = new NetworkInterfaceSetConfiguration
            {
                enabled = true,
                enabledSpecified = true,
                mtuSpecified = nic != null && nic.info != null && nic.info.mtuSpecified
            };

            if (nicSet.mtuSpecified && nic != null && nic.info != null)
            {
                nicSet.mtu = nic.info.mtu;
            }

            nicSet.iPv4 = new IPv4NetworkInterfaceSetConfiguration
            {
                dhcp = networkSettings.Dhcp,
                dhcpSpecified = true,
                enabled = true,
                enabledSpecified = true
            };

            if (!networkSettings.Dhcp)
            {
                var pa = new PrefixedIPv4Address
                {
                    address = networkSettings.Ip,
                    prefixLength =
                        NetMaskHelper.IpToCidrMask(System.Net.IPAddress.Parse(networkSettings.Subnet))
                };
                nicSet.iPv4.manual = string.IsNullOrWhiteSpace(networkSettings.Ip)
                    ? new PrefixedIPv4Address[0]
                    : new[] { pa };
            }
            if (nic != null)
            {
                var rebootIsNeeded = await _session.SetNetworkInterfaces(nic.token, nicSet);
                if (rebootIsNeeded)
                {
                    try
                    {
                        await _session.SystemReboot();
                    }
                    catch
                    {
                        // ignored
                    }
                }
            }
        }

        public void SetNetworkSettings(NetworkSettings networkSettings)
        {
            var currentNetProtocols = networkSettings.NetProtocols ?? new NetworkProtocol[0];
            _session.SetNetworkProtocols(currentNetProtocols).RunSynchronously();
            var ntpAddresses = networkSettings.NtpServers.Split(new[] { ';', ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).
                Where(x => !string.IsNullOrWhiteSpace(x)).
                Select(OdmSession.NetHostFromStr);

            var useDhcp = networkSettings.Dhcp && networkSettings.UseNtpFromDhcp;
            _session.SetNTP(useDhcp, ntpAddresses.ToArray()).RunSynchronously();

            var dnsAddresses = networkSettings.Dns.Split(new[] { ';', ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).
                Where(x => !string.IsNullOrWhiteSpace(x)).
                Select(x => new onvif.services.IPAddress { type = IPType.iPv4, iPv4Address = x });

            _session.SetDNS(useDhcp, null, dnsAddresses.ToArray()).RunSynchronously();

            var ips = networkSettings.Dns.Split(new[] { ';', ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).
                Select(x =>
                {
                    System.Net.IPAddress ip;
                    var valid = System.Net.IPAddress.TryParse(x.Trim(), out ip);
                    return valid ? ip : null;
                }).Where(x => x != null).ToArray();

            var ipv4 = ips.Where(x => x.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).
                           Select(x => x.ToString()).ToArray();

            var ipv6 = ips.Where(x => x.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6).
                           Select(x => x.ToString()).ToArray();

            _session.SetNetworkDefaultGateway(ipv4, ipv6).RunSynchronously();

            var zeroConf = _session.GetZeroConfiguration().StartAsTask().Result;
            _session.SetZeroConfiguration(zeroConf.interfaceToken, networkSettings.ZeroConfEnabled).RunSynchronously();

            if (networkSettings.UseHostFromDhcp)
            {
                _session.SetHostname(string.Empty).RunSynchronously();
            }
            else
            {
                _session.SetHostname(networkSettings.Host ?? string.Empty).RunSynchronously();
            }
            _session.SetDiscoveryMode(networkSettings.DiscoveryMode).RunSynchronously();

            var nics = _session.GetNetworkInterfaces().StartAsTask().Result;
            var nic = nics.FirstOrDefault(x => x.enabled);
            var nicSet = new NetworkInterfaceSetConfiguration
            {
                enabled = true,
                enabledSpecified = true,
                mtuSpecified = nic != null && nic.info != null && nic.info.mtuSpecified
            };

            if (nicSet.mtuSpecified && nic != null && nic.info != null)
            {
                nicSet.mtu = nic.info.mtu;
            }

            nicSet.iPv4 = new IPv4NetworkInterfaceSetConfiguration
            {
                dhcp = networkSettings.Dhcp,
                dhcpSpecified = true,
                enabled = true,
                enabledSpecified = true
            };

            if (!networkSettings.Dhcp)
            {
                var pa = new PrefixedIPv4Address
                {
                    address = networkSettings.Ip,
                    prefixLength =
                        NetMaskHelper.IpToCidrMask(System.Net.IPAddress.Parse(networkSettings.Subnet))
                };
                nicSet.iPv4.manual = string.IsNullOrWhiteSpace(networkSettings.Ip)
                    ? new PrefixedIPv4Address[0]
                    : new[] { pa };
            }
            if (nic != null)
            {
                var rebootIsNeeded = _session.SetNetworkInterfaces(nic.token, nicSet).StartAsTask().Result;
                if (rebootIsNeeded)
                {
                    try
                    {
                        _session.SystemReboot().RunSynchronously();
                    }
                    catch
                    {
                        // ignored
                    }
                }
            }
        }

        public async Task<NetworkInterface[]> GetNetworkInterfacesAsync()
        {
            return await _session.GetNetworkInterfaces();
        }

        public NetworkInterface[] GetNetworkInterfaces()
        {
            return _session.GetNetworkInterfaces().StartAsTask().Result;
        }

        public async Task<NTPInformation> GetNtpAsync()
        {
            return await _session.GetNTP();
        }

        public NTPInformation GetNtp()
        {
            return _session.GetNTP().StartAsTask().Result;
        }

        public async Task<HostnameInformation> GetHostNameAsync()
        {
            return await _session.GetHostname();
        }

        public HostnameInformation GetHostName()
        {
            return _session.GetHostname().StartAsTask().Result;
        }

        public async Task<NetworkGateway> GetNetworkDefaultGatewayAsync()
        {
            return await _session.GetNetworkDefaultGateway();
        }

        public NetworkGateway GetNetworkDefaultGateway()
        {
            return _session.GetNetworkDefaultGateway().StartAsTask().Result;
        }

        public async Task<DNSInformation> GetDnsAsync()
        {
            return await _session.GetDNS();
        }

        public DNSInformation GetDns()
        {
            return _session.GetDNS().StartAsTask().Result;
        }

        public async Task<NetworkProtocol[]> GetNetworkProtocolsAsync()
        {
            return await _session.GetNetworkProtocols();
        }

        public NetworkProtocol[] GetNetworkProtocols()
        {
            return _session.GetNetworkProtocols().StartAsTask().Result;
        }

        public async Task<DiscoveryMode> GetDiscoveryModeAsync()
        {
            return await _session.GetDiscoveryMode();
        }

        public DiscoveryMode GetDiscoveryMode()
        {
            return _session.GetDiscoveryMode().StartAsTask().Result;
        }

        public async Task SetNetworkProtocolsAsync(NetworkProtocol[] protocols)
        {
            await _session.SetNetworkProtocols(protocols);
        }

        public void SetNetworkProtocols(NetworkProtocol[] protocols)
        {
            _session.SetNetworkProtocols(protocols).RunSynchronously();
        }

        public async Task SetNtpAsync(bool useDhcp, NetworkHost[] ntpHosts)
        {
            await _session.SetNTP(useDhcp, ntpHosts);
        }

        public void SetNtp(bool useDhcp, NetworkHost[] ntpHosts)
        {
            _session.SetNTP(useDhcp, ntpHosts).RunSynchronously();
        }

        public async Task SetDnsAsync(bool useDhcp, onvif.services.IPAddress[] dnsAddresses, string[] dnsManual = null)
        {
            await _session.SetDNS(useDhcp, dnsManual, dnsAddresses);
        }

        public void SetDns(bool useDhcp, onvif.services.IPAddress[] dnsAddresses, string[] dnsManual = null)
        {
            _session.SetDNS(useDhcp, dnsManual, dnsAddresses).RunSynchronously();
        }

        public async Task SetNetworkDefaultGatewayAsync(string[] ipv4, string[] ipv6)
        {
            await _session.SetNetworkDefaultGateway(ipv4, ipv6);
        }

        public void SetNetworkDefaultGateway(string[] ipv4, string[] ipv6)
        {
            _session.SetNetworkDefaultGateway(ipv4, ipv6).RunSynchronously();
        }

        public async Task SetZeroConfigurationAsync(string zeroConfInterfaceToken, bool zeroConfEnabled)
        {
            await _session.SetZeroConfiguration(zeroConfInterfaceToken, zeroConfEnabled);
        }

        public void SetZeroConfiguration(string zeroConfInterfaceToken, bool zeroConfEnabled)
        {
            _session.SetZeroConfiguration(zeroConfInterfaceToken, zeroConfEnabled).RunSynchronously();
        }

        public async Task SetHostNameAsync(string host = "")
        {
            await _session.SetHostname(host);
        }

        public void SetHostName(string host = "")
        {
            _session.SetHostname(host).RunSynchronously();
        }

        public async Task SetDiscoveryModeAsync(DiscoveryMode mode)
        {
            await _session.SetDiscoveryMode(mode);
        }

        public void SetDiscoveryMode(DiscoveryMode mode)
        {
            _session.SetDiscoveryMode(mode).RunSynchronously();
        }

        public async Task SetNetworkInterfacesAsync(string token, NetworkInterfaceSetConfiguration config)
        {
            await _session.SetNetworkInterfaces(token, config);
        }

        public void SetNetworkInterfaces(string token, NetworkInterfaceSetConfiguration config)
        {
            _session.SetNetworkInterfaces(token, config).RunSynchronously();
        }

        public async Task<NetStatus> GetNetworkStatusAsync()
        {
            return await _facade.GetNetworkStatus();
        }

        public NetStatus GetNetworkStatus()
        {
            return _facade.GetNetworkStatus().StartAsTask().Result;
        }
        #endregion

        #region Maintenance

        public async Task GetMaintenance()
        {
            var dev = _session;
            var devInfo = await dev.GetDeviceInformation();
            var caps = dev.GetCapabilities();
            var isFirmwareUpgradeSupported = await _facade.IsFirmwareUpgradeSupported();
        }

        public async Task<bool> ResetAsync(FactoryDefaultType resetType)
        {
            try
            {
                await _session.SetSystemFactoryDefault(resetType);
                return true; 
            }
            catch (Exception)
            {
                return false; 
            }
        }

        public bool Reset(FactoryDefaultType resetType)
        {
            try
            {
                _session.SetSystemFactoryDefault(resetType).RunSynchronously();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<string> RebootAsync()
        {
            return await _session.SystemReboot();
        }

        public string Reboot()
        {
            return _session.SystemReboot().StartAsTask().Result;
        }

        #endregion

        #region Certificates

        public async Task<Certificate[]> GetCertificatesAsync()
        {
            return await _session.GetCertificates();
        }

        public Certificate[] GetCertificates()
        {
            return _session.GetCertificates().StartAsTask().Result;
        }

        public async Task<CertificateStatus[]> GetCertificatesStatusAsync()
        {
            return await _session.GetCertificatesStatus();
        }

        public CertificateStatus[] GetCertificatesStatus()
        {
            return _session.GetCertificatesStatus().StartAsTask().Result;
        }

        public async Task SetCertificatesStatusAsync(CertificateStatus[] statuses)
        {
            await _session.SetCertificatesStatus(statuses);
        }

        public void SetCertificatesStatus(CertificateStatus[] statuses)
        {
            _session.SetCertificatesStatus(statuses).RunSynchronously();
        }

        public async Task DeleteCertificatesAsync(string[] certificateIds)
        {
            await _session.DeleteCertificates(certificateIds);
        }

        public void DeleteCertificates(string[] certificateIds)
        {
            _session.DeleteCertificates(certificateIds).RunSynchronously();
        }

        public async Task LoadCertificatesAsync(Certificate[] certs)
        {
            await _session.LoadCertificates(certs);
        }

        public void LoadCertificates(Certificate[] certs)
        {
            _session.LoadCertificates(certs).RunSynchronously();
        }

        public async Task UploadCertificatesAsync(string filePath)
        {
            var cert = new Certificate();
            var finfo = new FileInfo(filePath);
            cert.certificateID = finfo.Name;
            cert.certificate = new BinaryData();
            var fstream = finfo.OpenRead();
            byte[] data = new byte[fstream.Length];
            await fstream.ReadAsync(data, 0, (int)fstream.Length);
            cert.certificate.data = data;
            await _session.LoadCertificates(new[] { cert });
        }
        
        #endregion 

        #region User Management
        public async Task<User[]> GetUsersAsync()
        {
            return await _session.GetUsers();
        }

        public User[] GetUsers()
        {
            return _session.GetUsers().StartAsTask().Result;
        }

        public async Task CreateUsersAsync(User[] users)
        {
            await _session.CreateUsers(users);
        }

        public void CreateUsers(User[] users)
        {
            _session.CreateUsers(users).RunSynchronously();
        }

        public async Task CreateUserAsync(User user)
        {
            await CreateUsersAsync(new[]
            {
                user
            });
        }

        public void CreateUser(User user)
        {
            CreateUsers(new[]
            {
                user
            });
        }

        public async Task DeleteUserAsync(string[] userNames)
        {
            await _session.DeleteUsers(userNames);
        }

        public void DeleteUser(string[] userNames)
        {
            _session.DeleteUsers(userNames).RunSynchronously();
        }

        public async Task DeleteUserAsync(User user)
        {
            await _session.DeleteUsers(new[] { user.username });
        }

        public void DeleteUser(User user)
        {
            _session.DeleteUsers(new[] { user.username });
        }

        public async Task ModifyUserAsync(User user)
        {
            await _session.SetUser(new[] { user });
        }

        public void ModifyUser(User user)
        {
            _session.SetUser(new[] { user }).RunSynchronously();
        }
        #endregion

        #region Time Settings

        public async Task<SystemDateTime> GetSystemDateTimeAsync()
        {
            return await _session.GetSystemDateAndTime();
        }

        public SystemDateTime GetSystemDateTime()
        {
            return _session.GetSystemDateAndTime().StartAsTask().Result;
        }

        public async Task SyncWithSystemAsync()
        {
            var utcNow = System.DateTime.UtcNow;
            var newUtc = new DateTime
            {
                date = new Date { year = utcNow.Year, month = utcNow.Month, day = utcNow.Day },
                time = new Time { hour = utcNow.Hour, minute = utcNow.Minute, second = utcNow.Second }
            };

            var dateTimeInfo = await _session.GetSystemDateAndTime();
            var timeZone = dateTimeInfo.timeZone != null ? dateTimeInfo.timeZone.tz : null;
            var newTz = new TimeZone { tz = timeZone };

            await _session.SetSystemDateAndTime(SetDateTimeType.manual, dateTimeInfo.daylightSavings, newTz, newUtc);
        }

        public void SyncWithSystem()
        {
            var utcNow = System.DateTime.UtcNow;
            var newUtc = new DateTime
            {
                date = new Date { year = utcNow.Year, month = utcNow.Month, day = utcNow.Day },
                time = new Time { hour = utcNow.Hour, minute = utcNow.Minute, second = utcNow.Second }
            };

            var dateTimeInfo = _session.GetSystemDateAndTime().StartAsTask().Result;
            var timeZone = dateTimeInfo.timeZone != null ? dateTimeInfo.timeZone.tz : null;
            var newTz = new TimeZone { tz = timeZone };

            _session.SetSystemDateAndTime(SetDateTimeType.manual, dateTimeInfo.daylightSavings, newTz, newUtc).RunSynchronously();
        }

        public async Task SyncWithNtpAsync()
        {
            var dateTimeInfo = await _session.GetSystemDateAndTime();
            var timeZone = dateTimeInfo.timeZone != null ? dateTimeInfo.timeZone.tz : null;
            var newTz = new TimeZone { tz = timeZone };
            await _session.SetSystemDateAndTime(SetDateTimeType.ntp, dateTimeInfo.daylightSavings, newTz, null);
        }

        public void SyncWithNtp()
        {
            var dateTimeInfo = _session.GetSystemDateAndTime().StartAsTask().Result;
            var timeZone = dateTimeInfo.timeZone != null ? dateTimeInfo.timeZone.tz : null;
            var newTz = new TimeZone { tz = timeZone };
            _session.SetSystemDateAndTime(SetDateTimeType.ntp, dateTimeInfo.daylightSavings, newTz, null).RunSynchronously();
        }

        public async Task SetManualAsync(System.DateTime utcDateTime)
        {
            var utcNow = utcDateTime;
            var newUtc = new DateTime
            {
                date = new Date { year = utcNow.Year, month = utcNow.Month, day = utcNow.Day },
                time = new Time { hour = utcNow.Hour, minute = utcNow.Minute, second = utcNow.Second }
            };

            var dateTimeInfo = await _session.GetSystemDateAndTime();
            var timeZone = dateTimeInfo.timeZone != null ? dateTimeInfo.timeZone.tz : null;
            var newTz = new TimeZone { tz = timeZone };

            await _session.SetSystemDateAndTime(SetDateTimeType.manual, dateTimeInfo.daylightSavings, newTz, newUtc);
        }

        public void SetManual(System.DateTime utcDateTime)
        {
            var utcNow = utcDateTime;
            var newUtc = new DateTime
            {
                date = new Date { year = utcNow.Year, month = utcNow.Month, day = utcNow.Day },
                time = new Time { hour = utcNow.Hour, minute = utcNow.Minute, second = utcNow.Second }
            };

            var dateTimeInfo = _session.GetSystemDateAndTime().StartAsTask().Result;
            var timeZone = dateTimeInfo.timeZone != null ? dateTimeInfo.timeZone.tz : null;
            var newTz = new TimeZone { tz = timeZone };

            _session.SetSystemDateAndTime(SetDateTimeType.manual, dateTimeInfo.daylightSavings, newTz, newUtc).RunSynchronously();
        }

        #endregion

        #region Analytics


        public async Task CreateAnalyticsModulesAsync(string vacToken, Config[] analytycsModules)
        {
            await _session.CreateAnalyticsModules(vacToken, analytycsModules);
        }

        public void CreateAnalyticsModules(string vacToken, Config[] analytycsModules)
        {
            _session.CreateAnalyticsModules(vacToken, analytycsModules).RunSynchronously();
        }

        public async Task DeleteAnalyticsModulesAsync(string vacToken, string[] analytycModuleNames)
        {
            await _session.DeleteAnalyticsModules(vacToken, analytycModuleNames);
        }

        public void DeleteAnalyticsModules(string vacToken, string[] analytycModuleNames)
        {
            _session.DeleteAnalyticsModules(vacToken, analytycModuleNames).RunSynchronously();
        }

        public async Task<Config[]> GetAnalyticsModulesAsync(string vacToken)
        {
            return await _session.GetAnalyticsModules(vacToken);
        }

        public Config[] GetAnalyticsModules(string vacToken)
        {
            return _session.GetAnalyticsModules(vacToken).StartAsTask().Result;
        }

        public async Task<SupportedAnalyticsModules> GetSupportedAnalyticsModules(string vacToken)
        {
            return await _session.GetSupportedAnalyticsModules(vacToken);
        }

        public async Task ModifyAnalyticsModulesAsync(string vacToken, Config[] analytycsModules)
        {
            await _session.ModifyAnalyticsModules(vacToken, analytycsModules);
        }

        public void ModifyAnalyticsModules(string vacToken, Config[] analytycsModules)
        {
            _session.ModifyAnalyticsModules(vacToken, analytycsModules).RunSynchronously();
        }

        public async Task<AnalyticsEngineControl[]> GetAnalyticsEngineControlsAsync()
        {
            return await _session.GetAnalyticsEngineControls();
        }

        public AnalyticsEngineControl[] GetAnalyticsEngineControls()
        {
            return _session.GetAnalyticsEngineControls().StartAsTask().Result;
        }

        public async Task<AnalyticsEngineControl> GetAnalyticsEngineControlAsync(string configurationToken)
        {
            return await _session.GetAnalyticsEngineControl(configurationToken);
        }

        public AnalyticsEngineControl GetAnalyticsEngineControl(string configurationToken)
        {
            return _session.GetAnalyticsEngineControl(configurationToken).StartAsTask().Result;
        }

        public async Task<AnalyticsEngine[]> GetAnalyticsEnginesAsync()
        {
            return await _session.GetAnalyticsEngines();
        }

        public AnalyticsEngine[] GetAnalyticsEngines()
        {
            return _session.GetAnalyticsEngines().StartAsTask().Result;
        }

        public async Task<AnalyticsEngine> GetAnalyticsEngineAsync(string configurationToken)
        {
            return await _session.GetAnalyticsEngine(configurationToken);
        }

        public AnalyticsEngine GetAnalyticsEngine(string configurationToken)
        {
            return _session.GetAnalyticsEngine(configurationToken).StartAsTask().Result;
        }

        public async Task<AnalyticsEngineInput[]> CreateAnalyticsEngineControlAsync(AnalyticsEngineControl configuration)
        {
            return await _session.CreateAnalyticsEngineControl(configuration);
        }

        public AnalyticsEngineInput[] CreateAnalyticsEngineControl(AnalyticsEngineControl configuration)
        {
            return _session.CreateAnalyticsEngineControl(configuration).StartAsTask().Result;
        }

        public async Task SetAnalyticsEngineControlAsync(AnalyticsEngineControl configuration, bool forcePersitent)
        {
            await _session.SetAnalyticsEngineControl(configuration, forcePersitent);
        }

        public void SetAnalyticsEngineControl(AnalyticsEngineControl configuration, bool forcePersitent)
        {
            _session.SetAnalyticsEngineControl(configuration, forcePersitent).RunSynchronously();
        }

        public async Task DeleteAnalyticsEngineControlAsync(string configurationToken)
        {
            await _session.DeleteAnalyticsEngineControl(configurationToken);
        }

        public void DeleteAnalyticsEngineControl(string configurationToken)
        {
            _session.DeleteAnalyticsEngineControl(configurationToken).RunSynchronously();
        }

        public async Task<AnalyticsEngineInput[]> GetAnalyticsEngineInputsAsync()
        {
            return await _session.GetAnalyticsEngineInputs();
        }

        public AnalyticsEngineInput[] GetAnalyticsEngineInputs()
        {
            return _session.GetAnalyticsEngineInputs().StartAsTask().Result;
        }

        public async Task SetAnalyticsEngineInputAsync(AnalyticsEngineInput configuration, bool forcePersitent)
        {
            await _session.SetAnalyticsEngineInput(configuration, forcePersitent);
        }

        public void SetAnalyticsEngineInput(AnalyticsEngineInput configuration, bool forcePersitent)
        {
            _session.SetAnalyticsEngineInput(configuration, forcePersitent).RunSynchronously();
        }

        public async Task SetVideoAnalyticsConfigurationAsync(VideoAnalyticsConfiguration configuration, bool forcePersitent)
        {
            await ((IAnalyticsDeviceAsync)_session).SetVideoAnalyticsConfiguration(configuration, forcePersitent);
        }

        public void SetVideoAnalyticsConfiguration(VideoAnalyticsConfiguration configuration, bool forcePersitent)
        {
            ((IAnalyticsDeviceAsync)_session).SetVideoAnalyticsConfiguration(configuration, forcePersitent).RunSynchronously();
        }

        public async Task<string> GetAnalyticsDeviceStreamUriAsync(StreamSetup setup, string analyticsEngineControlToken)
        {
            return await _session.GetAnalyticsDeviceStreamUri(setup, analyticsEngineControlToken);
        }

        public string GetAnalyticsDeviceStreamUri(StreamSetup setup, string analyticsEngineControlToken)
        {
            return _session.GetAnalyticsDeviceStreamUri(setup, analyticsEngineControlToken).StartAsTask().Result;
        }

        public async Task<VideoAnalyticsConfiguration> GetVideoAnalyticsConfigurationAsync(string configurationToken)
        {
            return await ((IAnalyticsDeviceAsync)_session).GetVideoAnalyticsConfiguration(configurationToken);
        }

        public VideoAnalyticsConfiguration GetVideoAnalyticsConfiguration(string configurationToken)
        {
            return ((IAnalyticsDeviceAsync)_session).GetVideoAnalyticsConfiguration(configurationToken).StartAsTask().Result;
        }

        public async Task<AnalyticsEngineInput[]> CreateAnalyticsEngineInputsAsync(AnalyticsEngineInput[] configuration, bool[] forcePersistent)
        {
            return await _session.CreateAnalyticsEngineInputs(configuration, forcePersistent);
        }

        public AnalyticsEngineInput[] CreateAnalyticsEngineInputs(AnalyticsEngineInput[] configuration, bool[] forcePersistent)
        {
            return _session.CreateAnalyticsEngineInputs(configuration, forcePersistent).StartAsTask().Result;
        }

        public async Task DeleteAnalyticsEngineInputsAsync(string[] configurationToken)
        {
            await _session.DeleteAnalyticsEngineInputs(configurationToken);
        }

        public void DeleteAnalyticsEngineInputs(string[] configurationToken)
        {
            _session.DeleteAnalyticsEngineInputs(configurationToken).RunSynchronously();
        }

        public async Task<AnalyticsStateInformation> GetAnalyticsStateAsync(string analyticsEngineControlToken)
        {
            return await _session.GetAnalyticsState(analyticsEngineControlToken);
        }

        public AnalyticsStateInformation GetAnalyticsState(string analyticsEngineControlToken)
        {
            return _session.GetAnalyticsState(analyticsEngineControlToken).StartAsTask().Result;
        }

        #endregion

        #region Rules

        public async Task CreateRulesAsync(string vacToken, Config[] rules)
        {
            await _session.CreateRules(vacToken, rules);
        }

        public void CreateRules(string vacToken, Config[] rules)
        {
            _session.CreateRules(vacToken, rules).RunSynchronously();
        }

        public async Task DeleteRulesAsync(string vacToken, string[] ruleNames)
        {
            await _session.DeleteRules(vacToken, ruleNames);
        }

        public void DeleteRules(string vacToken, string[] ruleNames)
        {
            _session.DeleteRules(vacToken, ruleNames).RunSynchronously();
        }

        public async Task<Config[]> GetRulesAsync(string vacToken)
        {
            return await _session.GetRules(vacToken);
        }

        public Config[] GetRules(string vacToken)
        {
            return _session.GetRules(vacToken).RunSynchronously();
        }

        public async Task ModifyRulesAsync(string vacToken, Config[] rules)
        {
            await _session.ModifyRules(vacToken, rules);
        }

        public void ModifyRules(string vacToken, Config[] rules)
        {
            _session.ModifyRules(vacToken, rules).RunSynchronously();
        }

        #endregion

        #region Actions
        public async Task<SupportedActions> GetSupportedActionsAsync()
        {
            return await _session.GetSupportedActions();
        }

        public SupportedActions GetSupportedActions()
        {
            return _session.GetSupportedActions().StartAsTask().Result;
        }

        public async Task<Action1[]> GetActionsAsync()
        {
            return await _session.GetActions();
        }

        public Action1[] GetActions()
        {
            return _session.GetActions().StartAsTask().Result;
        }

        public async Task<ActionTrigger[]> GetActionTriggersAsync()
        {
            return await _session.GetActionTriggers();
        }

        public ActionTrigger[] GetActionTriggers()
        {
            return _session.GetActionTriggers().StartAsTask().Result;
        }

        public async Task<Action1[]> CreateActionsAsync(ActionConfiguration[] actConf)
        {
            return await _session.CreateActions(actConf);
        }

        public Action1[] CreateActions(ActionConfiguration[] actConf)
        {
            return _session.CreateActions(actConf).StartAsTask().Result;
        }

        public async Task DeleteActionsAsync(string[] actions)
        {
            await _session.DeleteActions(actions);
        }

        public void DeleteActions(string[] actions)
        {
            _session.DeleteActions(actions).RunSynchronously();
        }

        public async Task ModifyActionsAsync(Action1[] actions)
        {
            await _session.ModifyActions(actions);
        }

        public void ModifyActions(Action1[] actions)
        {
            _session.ModifyActions(actions).RunSynchronously();
        }

        public async Task<ActionTrigger[]> CreateActionTriggersAsync(ActionTriggerConfiguration[] configurations)
        {
            return await _session.CreateActionTriggers(configurations);
        }

        public ActionTrigger[] CreateActionTriggers(ActionTriggerConfiguration[] configurations)
        {
            return _session.CreateActionTriggers(configurations).StartAsTask().Result;
        }

        public async Task DeleteActionTriggersAsync(string[] triggers)
        {
            await _session.DeleteActionTriggers(triggers);
        }

        public void DeleteActionTriggers(string[] triggers)
        {
            _session.DeleteActionTriggers(triggers).RunSynchronously();
        }

        public async Task ModifyActionTriggersAsync(ActionTrigger[] triggers)
        {
            await _session.ModifyActionTriggers(triggers);
        }

        public void ModifyActionTriggers(ActionTrigger[] triggers)
        {
            _session.ModifyActionTriggers(triggers).RunSynchronously();
        }
        #endregion

        #region System Log

        public async Task<SystemLogType[]> GetSystemLogTypesAsync()
        {
            return await Task.Run(() => new [] { SystemLogType.access, SystemLogType.system });
        }

        public SystemLogType[] GetSystemLogTypes()
        {
            return Task.Run(() => new[] { SystemLogType.access, SystemLogType.system }).Result;
        }

        public async Task<SystemLog> GetSystemLogAsync(SystemLogType logType)
        {
            return await _session.GetSystemLog(logType);
        }

        public SystemLog GetSystemLog(SystemLogType logType)
        {
            return _session.GetSystemLog(logType).StartAsTask().Result;
        }
        #endregion

        #region Relays
        public async Task<RelayOutput[]> GetRelayOutputsAsync()
        {
            return await _session.GetRelayOutputs();
        }

        public RelayOutput[] GetRelayOutputs()
        {
            return _session.GetRelayOutputs().StartAsTask().Result;
        }

        public async Task SetRelayOutputSettingsAsync(string token, RelayOutputSettings settings)
        {
             await _session.SetRelayOutputSettings(token, settings);
        }

        public void SetRelayOutputSettings(string token, RelayOutputSettings settings)
        {
            _session.SetRelayOutputSettings(token, settings).RunSynchronously();
        }

        public async Task SetRelayOutputStateAsync(string token, RelayLogicalState state)
        {
            await _session.SetRelayOutputState(token, state);
        }

        public void SetRelayOutputState(string token, RelayLogicalState state)
        {
            _session.SetRelayOutputState(token, state).RunSynchronously();
        }

        #endregion

        #region WebPage

        public Uri GetWebPageUri()
        {
            return new Uri(_session.deviceUri.GetLeftPart(UriPartial.Authority));
        }
        #endregion

        #region Profile

        public async Task<ProfileManagement> GetProfileManagementAsync(string activeProfToken, string vsToken)
        {
            var caps = await _session.GetCapabilities();
            var profiles = await _session.GetProfiles();
            var profs = profiles.Where(p => p.videoSourceConfiguration != null && p.videoSourceConfiguration.sourceToken == vsToken);
            var videoSources = await _session.GetVideoSources();
            var audioSources = await _session.GetAudioSources();
            var ptzNodes = await _facade.IsPtzSupported() ? (await _session.GetNodes()) ?? new[] { new PTZNode() } : new[] { new PTZNode() };

            var result = new ProfileManagement
            {
                Profiles = profiles,
                VideoSources = videoSources,
                AudioSources = audioSources,
                PtzNodes = ptzNodes
            };

            return result;
        }

        public ProfileManagement GetProfileManagement(string activeProfToken, string vsToken)
        {
            var caps = _session.GetCapabilities().StartAsTask().Result;
            var profiles = _session.GetProfiles().StartAsTask().Result;
            var profs = profiles.Where(p => p.videoSourceConfiguration != null && p.videoSourceConfiguration.sourceToken == vsToken);
            var videoSources = _session.GetVideoSources().StartAsTask().Result;
            var audioSources = _session.GetAudioSources().StartAsTask().Result;
            var ptzNodes = _facade.IsPtzSupported().StartAsTask().Result ? (_session.GetNodes().StartAsTask().Result) ?? new[] { new PTZNode() } : new[] { new PTZNode() };

            var result = new ProfileManagement
            {
                Profiles = profiles,
                VideoSources = videoSources,
                AudioSources = audioSources,
                PtzNodes = ptzNodes
            };

            return result;
        }

        public async Task<Profile[]> GetProfilesAsync()
        {
            return await _session.GetProfiles();
        }

        public Profile[] GetProfiles()
        {
            return _session.GetProfiles().StartAsTask().Result;
        }

        public async Task<Profile> GetProfileAsync(string profToken)
        {
            var profiles = await _session.GetProfiles();
            return profiles.FirstOrDefault(x => x.token == profToken);
        }

        public Profile GetProfile(string profToken)
        {
            var profiles = _session.GetProfiles().StartAsTask().Result;
            return profiles.FirstOrDefault(x => x.token == profToken);
        }

        public async Task<Profile> CreateProfileAsync(string name, string token)
        {
            return await _session.CreateProfile(name, token);
        }

        public Profile CreateProfile(string name, string token)
        {
            return _session.CreateProfile(name, token).StartAsTask().Result;
        }

        public async Task DeleteProfileAsync(string token)
        {
            await _session.DeleteProfile(token);
        }

        public void DeleteProfile(string token)
        {
            _session.DeleteProfile(token).RunSynchronously();
        }
        #endregion

        #region Audio
        public async Task AddAudioEncoderConfigurationAsync(string profileToken, string configurationToken)
        {
            await _session.AddAudioEncoderConfiguration(profileToken, configurationToken);
        }

        public void AddAudioEncoderConfiguration(string profileToken, string configurationToken)
        {
            _session.AddAudioEncoderConfiguration(profileToken, configurationToken).RunSynchronously();
        }

        public async Task RemoveAudioEncoderConfigurationAsync(string profileToken)
        {
            await _session.RemoveAudioEncoderConfiguration(profileToken);
        }

        public void RemoveAudioEncoderConfiguration(string profileToken)
        {
            _session.RemoveAudioEncoderConfiguration(profileToken).RunSynchronously();
        }

        public async Task AddAudioSourceConfigurationAsync(string profileToken, string configurationToken)
        {
            await _session.AddAudioSourceConfiguration(profileToken, configurationToken);
        }

        public void AddAudioSourceConfiguration(string profileToken, string configurationToken)
        {
            _session.AddAudioSourceConfiguration(profileToken, configurationToken).RunSynchronously();
        }

        public async Task RemoveAudioSourceConfigurationAsync(string profileToken)
        {
            await _session.RemoveAudioSourceConfiguration(profileToken);
        }

        public void RemoveAudioSourceConfiguration(string profileToken)
        {
            _session.RemoveAudioSourceConfiguration(profileToken).RunSynchronously();
        }
        
        #endregion

        #region  Video Settings
        public VideoSettings GetVideoSettings(string profToken)
        {
            var result = new VideoSettings();
            var profiles = GetProfilesAsync().Result;
            var profile = profiles.FirstOrDefault(x=>x.token == profToken);
            if (profile != null)
            {
                var vec = profile.videoEncoderConfiguration;
                var options = _session.GetVideoEncoderConfigurationOptions(vec.token, profile.token).StartAsTask().Result;
                var resolution = vec.resolution;
                var framerate = vec.rateControl != null ? vec.rateControl.frameRateLimit : -1;
                var encodingInterval = vec.rateControl != null ? vec.rateControl.encodingInterval : -1;
                var bitrate = vec.rateControl != null ? vec.rateControl.bitrateLimit : -1;

                var frameRateRanges = new List<IntRange>();

                if (options.h264 != null)
                    frameRateRanges.Add(options.h264.frameRateRange);
                if (options.jpeg != null)
                    frameRateRanges.Add(options.jpeg.frameRateRange);
                if (options.mpeg4 != null)
                    frameRateRanges.Add(options.mpeg4.frameRateRange);

                var encIntervalRanges = new List<IntRange>();

                if (options.h264 != null)
                {
                    encIntervalRanges.Add(options.h264.encodingIntervalRange);
                }
                if (options.jpeg != null)
                {
                    encIntervalRanges.Add(options.jpeg.encodingIntervalRange);
                }
                if (options.mpeg4 != null)
                {
                    encIntervalRanges.Add(options.mpeg4.encodingIntervalRange);
                }

                var govLengthRanges = new List<IntRange>();
                if (options.h264 != null)
                {
                    govLengthRanges.Add(options.h264.govLengthRange);
                }
                if (options.mpeg4 != null)
                {
                    govLengthRanges.Add(options.mpeg4.govLengthRange);
                }

                var govLength = vec.encoding == VideoEncoding.h264 && vec.h264 != null
                    ? vec.h264.govLength
                    : vec.encoding == VideoEncoding.mpeg4 && vec.mpeg4 != null ? vec.mpeg4.govLength : -1;

                var bitrateRanges = new List<IntRange>();
                if (options.extension != null && options.extension.any != null)
                {
                    var data = options.extension.any.Where(x => x.NamespaceURI == @"http://www.onvif.org/ver10/schema").ToList();
                    data.ForEach(d =>
                    {
                        if (d.Name == @"JPEG")
                        {
                            bitrateRanges.Add(d.Deserialize<JpegOptions2>().bitrateRange);
                        }
                        else if (d.Name == @"MPEG4")
                        {
                            bitrateRanges.Add(d.Deserialize<Mpeg4Options2>().bitrateRange);
                        }
                        else if (d.Name == @"H264")
                        {
                            bitrateRanges.Add(d.Deserialize<H264Options2>().bitrateRange);
                        }
                    });
                }

                var quality = vec.quality;
                var qualityRange = options.qualityRange ?? (new IntRange { min = -1, max = -1 });

                var tupleFrameRate = Tuple.Create(frameRateRanges.Count > 0 ? frameRateRanges.Min(x => x.min) : framerate,
                    frameRateRanges.Count > 0 ? frameRateRanges.Max(x => x.max) : framerate);

                var tupleEncodingInterval =
                    Tuple.Create(encIntervalRanges.Count > 0 ? encIntervalRanges.Min(x => x.min) : encodingInterval,
                        encIntervalRanges.Count > 0 ? encIntervalRanges.Max(x => x.max) : encodingInterval);

                var tupleBitrate = Tuple.Create(bitrateRanges.Count > 0 ? bitrateRanges.Min(x => x.min) : 0,
                    bitrateRanges.Count > 0 ? bitrateRanges.Max(x => x.max) : Int32.MaxValue);

                var tupleGovLength = Tuple.Create(govLengthRanges.Count > 0 ? govLengthRanges.Min(x => x.min) : govLength,
                    govLengthRanges.Count > 0 ? govLengthRanges.Max(x => x.max) : govLength);

                result.MinQuality = qualityRange.min;
                result.MaxQuality = qualityRange.max;
                result.MinBitrate = tupleBitrate.Item1;
                result.MaxBitrate = tupleBitrate.Item2;
                result.MinEncodingInterval = tupleEncodingInterval.Item1;
                result.MaxEncodingInterval = tupleEncodingInterval.Item2;
                result.MinFrameRate = tupleFrameRate.Item1;
                result.MaxFrameRate = tupleFrameRate.Item2;
                result.MinGovLength = tupleGovLength.Item1;
                result.MaxGovLength = tupleGovLength.Item2;
                result.EncoderOptions = options;
                result.Encoder = vec.encoding;
                result.VideoResolution = resolution;
                result.FrameRate = framerate;
                result.GovLength = govLength;
                result.EncodingInterval = encodingInterval;
                result.Quality = quality;
                result.Bitrate = bitrate;
            }

            return result;
        }

        public async Task<VideoEncoderConfigurationOptions> GetVideoEncoderConfigurationOptionsAsync(string configToken, string profToken = null)
        {
            return await _session.GetVideoEncoderConfigurationOptions(configToken, profToken);
        }

        public VideoEncoderConfigurationOptions GetVideoEncoderConfigurationOptions(string configToken, string profToken = null)
        {
            return _session.GetVideoEncoderConfigurationOptions(configToken, profToken).StartAsTask().Result;
        }

        public async Task SetVideoEncoderConfigurationAsync(VideoEncoderConfiguration configEncoder, bool forcePersistance = false)
        {
            await _session.SetVideoEncoderConfiguration(configEncoder, forcePersistance);
        }

        public void SetVideoEncoderConfiguration(VideoEncoderConfiguration configEncoder, bool forcePersistance = false)
        {
            _session.SetVideoEncoderConfiguration(configEncoder, forcePersistance).RunSynchronously();
        }

        public async Task AddVideoEncoderConfigurationAsync(string profileToken, string configurationToken)
        {
            await _session.AddVideoEncoderConfiguration(profileToken, configurationToken);
        }

        public void AddVideoEncoderConfiguration(string profileToken, string configurationToken)
        {
            _session.AddVideoEncoderConfiguration(profileToken, configurationToken).RunSynchronously();
        }

        public async Task RemoveVideoEncoderConfigurationAsync(string profileToken)
        {
            await _session.RemoveVideoEncoderConfiguration(profileToken);
        }

        public void RemoveVideoEncoderConfiguration(string profileToken)
        {
            _session.RemoveVideoEncoderConfiguration(profileToken).RunSynchronously();
        }

        public async Task AddVideoSourceConfigurationAsync(string profileToken, string configurationToken)
        {
            await _session.AddVideoSourceConfiguration(profileToken, configurationToken);
        }

        public void AddVideoSourceConfiguration(string profileToken, string configurationToken)
        {
            _session.AddVideoSourceConfiguration(profileToken, configurationToken).RunSynchronously();
        }

        public async Task RemoveVideoSourceConfigurationAsync(string profileToken)
        {
            await _session.RemoveVideoSourceConfiguration(profileToken);
        }

        public void RemoveVideoSourceConfiguration(string profileToken)
        {
            _session.RemoveVideoSourceConfiguration(profileToken).RunSynchronously();
        }

        public async Task SetVideoResolutionAsync(VideoResolution resolution, string profToken = null)
        {
            var profiles = await GetProfilesAsync();
            var profile = string.IsNullOrEmpty(profToken) ? 
                profiles.FirstOrDefault() :
                profiles.FirstOrDefault(p => p.token == profToken);

            if (profile != null)
            {
                var settings = GetVideoSettings(profile.token);
                settings.VideoResolution = resolution;
                await SetVideoSettingsAsync(profile.token, settings);
            }
        }

        public void SetVideoResolution(VideoResolution resolution, string profToken = null)
        {
            var profiles = GetProfiles();
            var profile = string.IsNullOrEmpty(profToken) ?
                profiles.FirstOrDefault() :
                profiles.FirstOrDefault(p => p.token == profToken);

            if (profile != null)
            {
                var settings = GetVideoSettings(profile.token);
                settings.VideoResolution = resolution;
                SetVideoSettings(profile.token, settings);
            }
        }

        public async Task SetVideoFrameRateAsync(float frameRate, string profToken = null)
        {
            var profiles = await GetProfilesAsync();
            var profile = string.IsNullOrEmpty(profToken) ?
                profiles.FirstOrDefault() :
                profiles.FirstOrDefault(p => p.token == profToken);

            if (profile != null)
            {
                var settings = GetVideoSettings(profile.token);
                settings.FrameRate = frameRate;
                await SetVideoSettingsAsync(profile.token, settings);
            }
        }

        public void SetVideoFrameRate(float frameRate, string profToken = null)
        {
            var profiles = GetProfiles();
            var profile = string.IsNullOrEmpty(profToken) ?
                profiles.FirstOrDefault() :
                profiles.FirstOrDefault(p => p.token == profToken);

            if (profile != null)
            {
                var settings = GetVideoSettings(profile.token);
                settings.FrameRate = frameRate;
                SetVideoSettings(profile.token, settings);
            }
        }

        public async Task SetVideoBitRateLimitAsync(float bitRate, string profToken = null)
        {
            var profiles = await GetProfilesAsync();
            var profile = string.IsNullOrEmpty(profToken) ?
                profiles.FirstOrDefault() :
                profiles.FirstOrDefault(p => p.token == profToken);

            if (profile != null)
            {
                var settings = GetVideoSettings(profile.token);
                settings.Bitrate = bitRate;
                await SetVideoSettingsAsync(profile.token, settings);
            }
        }

        public void SetVideoBitRateLimit(float bitRate, string profToken = null)
        {
            var profiles = GetProfiles();
            var profile = string.IsNullOrEmpty(profToken) ?
                profiles.FirstOrDefault() :
                profiles.FirstOrDefault(p => p.token == profToken);

            if (profile != null)
            {
                var settings = GetVideoSettings(profile.token);
                settings.Bitrate = bitRate;
                SetVideoSettings(profile.token, settings);
            }
        }

        public async Task SetVideoQualityAsync(float quality, string profToken = null)
        {
            var profiles = await GetProfilesAsync();
            var profile = string.IsNullOrEmpty(profToken) ?
                profiles.FirstOrDefault() :
                profiles.FirstOrDefault(p => p.token == profToken);

            if (profile != null)
            {
                var settings = GetVideoSettings(profile.token);
                settings.Quality = quality;
                await SetVideoSettingsAsync(profile.token, settings);
            }
        }

        public void SetVideoQuality(float quality, string profToken = null)
        {
            var profiles = GetProfiles();
            var profile = string.IsNullOrEmpty(profToken) ?
                profiles.FirstOrDefault() :
                profiles.FirstOrDefault(p => p.token == profToken);

            if (profile != null)
            {
                var settings = GetVideoSettings(profile.token);
                settings.Quality = quality;
                SetVideoSettings(profile.token, settings);
            }
        }

        public async Task SetVideoGovLengthAsync(int govLength, string profToken = null)
        {
            var profiles = await GetProfilesAsync();
            var profile = string.IsNullOrEmpty(profToken) ?
                profiles.FirstOrDefault() :
                profiles.FirstOrDefault(p => p.token == profToken);

            if (profile != null)
            {
                var settings = GetVideoSettings(profile.token);
                settings.GovLength = govLength;
                await SetVideoSettingsAsync(profile.token, settings);
            }
        }

        public void SetVideoGovLength(int govLength, string profToken = null)
        {
            var profiles = GetProfiles();
            var profile = string.IsNullOrEmpty(profToken) ?
                profiles.FirstOrDefault() :
                profiles.FirstOrDefault(p => p.token == profToken);

            if (profile != null)
            {
                var settings = GetVideoSettings(profile.token);
                settings.GovLength = govLength;
                SetVideoSettings(profile.token, settings);
            }
        }

        public async Task SetVideoEncodingIntervalAsync(int encodingInterval, string profToken = null)
        {
            var profiles = await GetProfilesAsync();
            var profile = string.IsNullOrEmpty(profToken) ?
                profiles.FirstOrDefault() :
                profiles.FirstOrDefault(p => p.token == profToken);

            if (profile != null)
            {
                var settings = GetVideoSettings(profile.token);
                settings.EncodingInterval = encodingInterval;
                await SetVideoSettingsAsync(profile.token, settings);
            }
        }

        public void SetVideoEncodingInterval(int encodingInterval, string profToken = null)
        {
            var profiles = GetProfiles();
            var profile = string.IsNullOrEmpty(profToken) ?
                profiles.FirstOrDefault() :
                profiles.FirstOrDefault(p => p.token == profToken);

            if (profile != null)
            {
                var settings = GetVideoSettings(profile.token);
                settings.EncodingInterval = encodingInterval;
                SetVideoSettings(profile.token, settings);
            }
        }

        public async Task SetVideoSettingsAsync(string profToken, VideoSettings settings)
        {
            var profiles = GetProfilesAsync().Result;
            var profile = profiles.FirstOrDefault(x => x.token == profToken);
            if (profile != null)
            {
                var vec = profile.videoEncoderConfiguration;
            
                var options = await _session.GetVideoEncoderConfigurationOptions(vec.token, null);
                var qualityMin = (float) options.qualityRange.min;
                var qualityMax = (float) options.qualityRange.max;
                var quality = Coerce(settings.Quality, qualityMin, qualityMax);

                vec.encoding = settings.Encoder;
                vec.quality = quality;
                vec.resolution = settings.VideoResolution;

                bool isVecConfigured;
                switch(settings.Encoder)
                {
                   case VideoEncoding.h264:
                       isVecConfigured = ValidateConfig(vec, options, options.h264, settings);
                       break;
                   case VideoEncoding.jpeg:
                       isVecConfigured = ValidateConfig(vec, options, options.jpeg, settings);
                       break;
                   case VideoEncoding.mpeg4:
                       isVecConfigured = ValidateConfig(vec, options, options.mpeg4, settings);
                       break;
                    default:
                        throw new ArgumentException(ErrorEncoder);
                }
                if (isVecConfigured)
                {
                    await _session.SetVideoEncoderConfiguration(vec, true);
                }
            }
        }

        public void SetVideoSettings(string profToken, VideoSettings settings)
        {
            var profiles = GetProfilesAsync().Result;
            var profile = profiles.FirstOrDefault(x => x.token == profToken);
            if (profile != null)
            {
                var vec = profile.videoEncoderConfiguration;

                var options = _session.GetVideoEncoderConfigurationOptions(vec.token, null).StartAsTask().Result;
                var qualityMin = (float)options.qualityRange.min;
                var qualityMax = (float)options.qualityRange.max;
                var quality = Coerce(settings.Quality, qualityMin, qualityMax);

                vec.encoding = settings.Encoder;
                vec.quality = quality;
                vec.resolution = settings.VideoResolution;

                bool isVecConfigured;
                switch (settings.Encoder)
                {
                    case VideoEncoding.h264:
                        isVecConfigured = ValidateConfig(vec, options, options.h264, settings);
                        break;
                    case VideoEncoding.jpeg:
                        isVecConfigured = ValidateConfig(vec, options, options.jpeg, settings);
                        break;
                    case VideoEncoding.mpeg4:
                        isVecConfigured = ValidateConfig(vec, options, options.mpeg4, settings);
                        break;
                    default:
                        throw new ArgumentException(ErrorEncoder);
                }
                if (isVecConfigured)
                {
                    _session.SetVideoEncoderConfiguration(vec, true).RunSynchronously();
                }
            }
        }

        private const string ErrorEncoder = "Settings.Encoder has invalid value";

        public async Task<VideoResolution[]> GetVideoSupportedResolutionsAsync(VideoEncoding encoder)
        {
            VideoResolution[] result = null;
            var profiles = await GetProfilesAsync();
            var profile = profiles.FirstOrDefault();
            if (profile != null)
            {
                var vec = profile.videoEncoderConfiguration;

                var options = await _session.GetVideoEncoderConfigurationOptions(vec.token, null);
                switch (encoder)
                {
                    case VideoEncoding.h264:
                        result = (VideoResolution[])GetPropValue(options.h264, "resolutionsAvailable");
                        break;
                    case VideoEncoding.jpeg:
                        result = (VideoResolution[])GetPropValue(options.jpeg, "resolutionsAvailable");
                        break;
                    case VideoEncoding.mpeg4:
                        result = (VideoResolution[])GetPropValue(options.mpeg4, "resolutionsAvailable");
                        break;
                    default:
                        throw new ArgumentException(ErrorEncoder);
                }
            }
            return result;
        }

        public VideoResolution[] GetVideoSupportedResolutions(VideoEncoding encoder)
        {
            VideoResolution[] result = null;
            var profiles = GetProfiles();
            var profile = profiles.FirstOrDefault();
            if (profile != null)
            {
                var vec = profile.videoEncoderConfiguration;

                var options = _session.GetVideoEncoderConfigurationOptions(vec.token, null).StartAsTask().Result;
                switch (encoder)
                {
                    case VideoEncoding.h264:
                        result = (VideoResolution[])GetPropValue(options.h264, "resolutionsAvailable");
                        break;
                    case VideoEncoding.jpeg:
                        result = (VideoResolution[])GetPropValue(options.jpeg, "resolutionsAvailable");
                        break;
                    case VideoEncoding.mpeg4:
                        result = (VideoResolution[])GetPropValue(options.mpeg4, "resolutionsAvailable");
                        break;
                    default:
                        throw new ArgumentException(ErrorEncoder);
                }
            }
            return result;
        }

        private bool ValidateConfig(VideoEncoderConfiguration vec, VideoEncoderConfigurationOptions options, object opts, VideoSettings settings)
        {
            if (options != null)
            {
                var resolutions = (VideoResolution[])GetPropValue(opts, "resolutionsAvailable");
                if (resolutions.Any(x => x.height == settings.VideoResolution.height 
                    && x.width == settings.VideoResolution.width))
                {
                    if(vec.rateControl == null)
                    vec.rateControl = new VideoRateControl();
                }
                else
                {
                    return false;
                }
                var frameRateRange = (IntRange)GetPropValue(opts, "frameRateRange");
                var frameRateMin = frameRateRange.min;
                var frameRateMax = frameRateRange.max;
                var frameRate = Coerce((int)settings.FrameRate, frameRateMin, frameRateMax);

                vec.rateControl.frameRateLimit = frameRate;
                vec.rateControl.bitrateLimit = (int)settings.Bitrate;

                var encodingIntervalRange = (IntRange)GetPropValue(opts, "encodingIntervalRange");
                var encodingIntervalMin = encodingIntervalRange.min;
                var encodingIntervalMax = encodingIntervalRange.max;
                var encodingInterval = Coerce(settings.EncodingInterval, encodingIntervalMin, encodingIntervalMax);
                vec.rateControl.encodingInterval = encodingInterval;

                switch (settings.Encoder)
                {
                    case VideoEncoding.h264:
                        vec.h264 = vec.h264 ?? new H264Configuration();
                        vec.h264.govLength = CoerceGovLength(options.h264, settings.GovLength);
                        break;
                    case VideoEncoding.mpeg4:
                        vec.mpeg4 = vec.mpeg4 ?? new Mpeg4Configuration();
                        vec.mpeg4.govLength = CoerceGovLength(options.mpeg4, settings.GovLength);
                        break;
                }

                return true;
            }
            return false;
        }

        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }

        private float Coerce(float value , float min, float max)
        {
            return value < min ? min : value > max ? max : value;
        }
        private int Coerce(int value, int min, int max)
        {
            return value < min ? min : value > max ? max : value;
        }

        private int CoerceGovLength(object obj, int value)
        {
            IntRange range = (IntRange)GetPropValue(obj, "govLengthRange");
            return range != null ? Coerce(value, range.min, range.max) : value;
        }
        #endregion

        #region Metadata Settings

        public async Task<MetadataSettings> GetMetadataSettings(string profToken)
        {
            const string xmlnsWsnt = "http://docs.oasis-open.org/wsn/b-2";
            MetadataSettings result = new MetadataSettings();
            var profiles = await GetProfilesAsync();
            var profile = profiles.FirstOrDefault(x=>x.token == profToken);
            var metaCfg = await _session.GetMetadataConfiguration(profToken);
            var metaCfgOpts = await _session.GetMetadataConfigurationOptions(metaCfg.token, profToken);
            
            var isPtzStatusSupported = metaCfgOpts != null && metaCfgOpts.ptzStatusFilterOptions != null && (metaCfgOpts.ptzStatusFilterOptions.zoomStatusSupported ||
                                                                                                             metaCfgOpts.ptzStatusFilterOptions.panTiltStatusSupported);
            var isPtzPositionSupported = (metaCfgOpts != null && metaCfgOpts.ptzStatusFilterOptions != null) && ((metaCfgOpts.ptzStatusFilterOptions.panTiltPositionSupportedSpecified &&
                                                                                                                  metaCfgOpts.ptzStatusFilterOptions.panTiltPositionSupported) ||
                                                                                                                 (metaCfgOpts.ptzStatusFilterOptions.zoomPositionSupportedSpecified &&
                                                                                                                  metaCfgOpts.ptzStatusFilterOptions.zoomPositionSupported));

            var device = ((IDeviceAsync)_session);
            var evnt = ((IEventAsync) _session);

            var newMetaCfg = await _session.GetMetadataConfiguration(metaCfg.token);
            metaCfg = newMetaCfg;

            var caps = await device.GetCapabilities();
            var isEventsSupported = await _facade.IsEventsSupported();
            if (isEventsSupported)
            {
                var eventProps = await evnt.GetEventProperties();
                result.MessageContentFilterDialects = eventProps.MessageContentFilterDialect;
                result.TopicExpressionDialects = eventProps.TopicExpressionDialect;
                result.TopicSet = eventProps.TopicSet;
                result.IsFixedTopicSet = eventProps.FixedTopicSet;
                result.IsPtzStatusSupported = isPtzStatusSupported;
                result.IsPtzPositionSupported = isPtzPositionSupported;
            }

            result.IncludeAnalitycs = metaCfg.analyticsSpecified && metaCfg.analytics;

            if (metaCfg.ptzStatus != null)
            {
                result.IncludePtzStatus = metaCfg.ptzStatus.status;
                result.IncludePtzPosition = metaCfg.ptzStatus.position;
            }
            else
            {
                result.IncludePtzStatus = result.IncludePtzPosition = false;
            }

            if (metaCfg.events != null)
            {
                result.IncludeEvents = true;

                var any = metaCfg.events.filter != null ?  metaCfg.events.filter.Any : null; 
                if(any != null)
                {
                    result.TopicExpressionFilters = any.Select(x =>
                    {
                        if (x.Name == XName.Get("TopicExpression", xmlnsWsnt))
                            return x.Deserialize<TopicExpressionFilter>();
                        return null;
                    }).Where(x=>x != null).ToArray();

                    result.MessageContentFilters = any.Select(x =>
                    {
                        if (x.Name == XName.Get("MessageContent", xmlnsWsnt))
                            return x.Deserialize<MessageContentFilter>();
                        return null;
                    }).Where(x => x != null).ToArray();
                }
            }
            else
            {
                result.IncludeEvents = false;
                result.TopicExpressionFilters = null;
                result.MessageContentFilters = null;
            }

            return result;
        }

        public async Task SetMetadataConfigurationAsync(MetadataConfiguration metaCfg)
        {
            var media = ((IMediaAsync)_session);
            await media.SetMetadataConfiguration(metaCfg, true);
        }

        public void SetMetadataConfiguration(MetadataConfiguration metaCfg)
        {
            var media = ((IMediaAsync)_session);
            media.SetMetadataConfiguration(metaCfg, true).RunSynchronously();
        }
        
        #endregion

        #region PTZ

        public async Task<string> GetStreamUrlAsync(string profileToken, StreamType streamType, Transport transport)
        {
            var result = await _session.GetStreamUri(new StreamSetup { stream = streamType, transport = transport }, profileToken);
            return result.uri;
        }

        public string GetStreamUrl(string profileToken, StreamType streamType, Transport transport)
        {
            var result = _session.GetStreamUri(new StreamSetup { stream = streamType, transport = transport }, profileToken).StartAsTask().Result;
            return result.uri;
        }

        public async Task<MediaUri> GetStreamUriAsync(StreamSetup setup, string profileToken)
        {
            return await _session.GetStreamUri(setup, profileToken);
        }

        public MediaUri GetStreamUri(StreamSetup setup, string profileToken)
        {
            return _session.GetStreamUri(setup, profileToken).StartAsTask().Result;
        }

        public async Task<bool> IsAbsoluteMoveSupportedAsync()
        {
            return await Task.Run(()=>IsPtzSupported);
        }

        public bool IsAbsoluteMoveSupported()
        {
            return IsPtzSupported;
        }

        public async Task<bool> IsRelativeMoveSupportedAsync()
        {
            var nodes = await _session.GetNodes();
            return nodes.Any(x => x.supportedPTZSpaces.relativeZoomTranslationSpace != null || x.supportedPTZSpaces.relativePanTiltTranslationSpace != null);
        }

        public bool IsRelativeMoveSupported()
        {
            var nodes = _session.GetNodes().StartAsTask().Result;
            return nodes.Any(x => x.supportedPTZSpaces.relativeZoomTranslationSpace != null || x.supportedPTZSpaces.relativePanTiltTranslationSpace != null);
        }

        public async Task<bool> IsContinuousMoveSupportedAsync()
        {
            var nodes = await _session.GetNodes();
            return nodes.Any(x => x.supportedPTZSpaces.continuousPanTiltVelocitySpace != null || x.supportedPTZSpaces.continuousZoomVelocitySpace != null);
        }

        public bool IsContinuousMoveSupported()
        {
            var nodes = _session.GetNodes().StartAsTask().Result;
            return nodes.Any(x => x.supportedPTZSpaces.continuousPanTiltVelocitySpace != null || x.supportedPTZSpaces.continuousZoomVelocitySpace != null);
        }

        public async Task<bool> IsHomeSupportedAsync()
        {
            var nodes = await _session.GetNodes();
            return nodes.Any(x => x.homeSupported);
        }

        public bool IsHomeSupported()
        {
            var nodes = _session.GetNodes().StartAsTask().Result;
            return nodes.Any(x => x.homeSupported);
        }

        public async Task<bool> IsFixedHomePositionAsync()
        {
            var nodes = await _session.GetNodes();
            return nodes.Any(x => x.fixedHomePosition);
        }

        public bool IsFixedHomePosition()
        {
            var nodes = _session.GetNodes().StartAsTask().Result;
            return nodes.Any(x => x.fixedHomePosition);
        }

        public async Task<bool> IsFixedHomePositionSpecifiedAsync()
        {
            var nodes = await _session.GetNodes();
            return nodes.Any(x => x.fixedHomePositionSpecified);
        }

        public bool IsFixedHomePositionSpecified()
        {
            var nodes = _session.GetNodes().StartAsTask().Result;
            return nodes.Any(x => x.fixedHomePositionSpecified);
        }

        public async Task AddPtzConfigurationAsync(string profileToken, string configToken)
        {
            await _session.AddPTZConfiguration(profileToken, configToken);
        }

        public void AddPtzConfiguration(string profileToken, string configToken)
        {
            _session.AddPTZConfiguration(profileToken, configToken).RunSynchronously();
        }

        public async Task RemovePtzConfigurationAsync(string profileToken)
        {
            await _session.RemovePTZConfiguration(profileToken);
        }

        public void RemovePtzConfiguration(string profileToken)
        {
            _session.RemovePTZConfiguration(profileToken).RunSynchronously();
        }

        public async Task<PTZNode[]> GetNodesAsync()
        {
            return await _session.GetNodes();
        }

        public PTZNode[] GetNodes()
        {
            return _session.GetNodes().StartAsTask().Result;
        }

        public async Task<PTZNode> GetNodeAsync(string nodeToken)
        {
            return await _session.GetNode(nodeToken);
        }

        public PTZNode GetNode(string nodeToken)
        {
            return _session.GetNode(nodeToken).StartAsTask().Result;
        }

        public async Task<PTZConfiguration> GetConfigurationAsync(string configurationToken)
        {
            return await _session.GetConfiguration(configurationToken);
        }

        public PTZConfiguration GetConfiguration(string configurationToken)
        {
            return _session.GetConfiguration(configurationToken).StartAsTask().Result;
        }

        public async Task<PTZConfiguration[]> GetConfigurationsAsync()
        {
            return await _session.GetConfigurations();
        }

        public PTZConfiguration[] GetConfigurations()
        {
            return _session.GetConfigurations().StartAsTask().Result;
        }

        public async Task SetConfigurationAsync(PTZConfiguration config, bool forcePersistance)
        {
            await _session.SetConfiguration(config, forcePersistance);
        }

        public void SetConfiguration(PTZConfiguration config, bool forcePersistance)
        {
            _session.SetConfiguration(config, forcePersistance).RunSynchronously();
        }

        public async Task<PTZConfigurationOptions> GetConfigurationsOptionsAsync(string configurationToken)
        {
            return await _session.GetConfigurationOptions(configurationToken);
        }

        public PTZConfigurationOptions GetConfigurationsOptions(string configurationToken)
        {
            return _session.GetConfigurationOptions(configurationToken).StartAsTask().Result;
        }

        public async Task<string> SendAuxiliaryCommandAsync(string profileToken, string auxData)
        {
            return await _session.SendAuxiliaryCommand(profileToken, auxData);
        }

        public string SendAuxiliaryCommand(string profileToken, string auxData)
        {
            return _session.SendAuxiliaryCommand(profileToken, auxData).StartAsTask().Result;
        }

        public async Task<PTZPreset[]> GetPresetsAsync(string profileToken)
        {
            return await _session.GetPresets(profileToken);
        }

        public PTZPreset[] GetPresets(string profileToken)
        {
            return _session.GetPresets(profileToken).StartAsTask().Result;
        }

        public async Task<string> SetPresetAsync(string profileToken, string presetName, string presetToken)
        {
            return await _session.SetPreset(profileToken, presetName, presetToken);
        }

        public string SetPreset(string profileToken, string presetName, string presetToken)
        {
            return _session.SetPreset(profileToken, presetName, presetToken).StartAsTask().Result;
        }

        public async Task RemovePresetAsync(string profileToken, string presetToken)
        {
            await _session.RemovePreset(profileToken, presetToken);
        }

        public void RemovePreset(string profileToken, string presetToken)
        {
            _session.RemovePreset(profileToken, presetToken).RunSynchronously();
        }

        public async Task GotoPresetAsync(string profileToken, string presetToken, PTZSpeed speed = null)
        {
            await _session.GotoPreset(profileToken, presetToken, speed);
        }

        public void GotoPreset(string profileToken, string presetToken, PTZSpeed speed = null)
        {
            _session.GotoPreset(profileToken, presetToken, speed).RunSynchronously();
        }

        public async Task GotoHomePositionAsync(string profileToken, PTZSpeed speed = null)
        {
            await _session.GotoHomePosition(profileToken, speed);
        }

        public void GotoHomePosition(string profileToken, PTZSpeed speed = null)
        {
            _session.GotoHomePosition(profileToken, speed);
        }

        public async Task SetHomePositionAsync(string profileToken)
        {
            await _session.SetHomePosition(profileToken);
        }

        public void SetHomePosition(string profileToken)
        {
            _session.SetHomePosition(profileToken).RunSynchronously();
        }

        public async Task ContinuousMoveAsync(string profileToken, PTZSpeed velocity, XsDuration timeout = null)
        {
            await _session.ContinuousMove(profileToken, velocity, timeout);
        }

        public void ContinuousMove(string profileToken, PTZSpeed velocity, XsDuration timeout = null)
        {
            _session.ContinuousMove(profileToken, velocity, timeout).RunSynchronously();
        }

        public async Task RelativeMoveAsync(string profileToken, PTZVector traslation, PTZSpeed speed = null)
        {
            await _session.RelativeMove(profileToken, traslation, speed);
        }

        public void RelativeMove(string profileToken, PTZVector traslation, PTZSpeed speed = null)
        {
            _session.RelativeMove(profileToken, traslation, speed).RunSynchronously();
        }

        public async Task AbsoluteMoveAsync(string profileToken, PTZVector position, PTZSpeed speed = null)
        {
            await _session.AbsoluteMove(profileToken, position, speed);
        }

        public void AbsoluteMove(string profileToken, PTZVector position, PTZSpeed speed = null)
        {
            _session.AbsoluteMove(profileToken, position, speed).RunSynchronously();
        }

        public async Task<PTZStatus> GetStatusAsync(string profileToken)
        {
            return await ((IPtzAsync)_session).GetStatus(profileToken);
        }

        public PTZStatus GetStatus(string profileToken)
        {
            return ((IPtzAsync)_session).GetStatus(profileToken).StartAsTask().Result;
        }

        public async Task StopAsync(string profileToken, bool panTilt, bool zoom)
        {
            await _session.Stop(profileToken, panTilt, zoom);
        }

        public void Stop(string profileToken, bool panTilt, bool zoom)
        {
            _session.Stop(profileToken, panTilt, zoom).RunSynchronously();
        }

        public async Task<PtzData> GetPtzDataAsync(string profToken)
        {
            var profiles = await GetProfilesAsync();
            var prof = profiles.FirstOrDefault(x => x.token == profToken);

            if (prof == null || prof.ptzConfiguration != null)
            {
                return new PtzData
                {
                    Profile = prof, 
                    Node = null, 
                    PtzPresets = null, 
                    Status = null
                };
            }
                
            PTZPreset[] presets = null;
            try
            {
                presets = await _session.GetPresets(profToken);
            }
            catch
            {
                // ignored
            }

            return new PtzData { Profile = prof, Node = await LoadPtzNodeAsync(prof.ptzConfiguration), PtzPresets = presets, Status = await LoadPtzStatusAsync(prof.token) }; 
        }

        public PtzData GetPtzData(string profToken)
        {
            var profiles = GetProfiles();
            var prof = profiles.FirstOrDefault(x => x.token == profToken);

            if (prof == null || prof.ptzConfiguration != null)
            {
                return new PtzData
                {
                    Profile = prof,
                    Node = null,
                    PtzPresets = null,
                    Status = null
                };
            }

            PTZPreset[] presets = null;
            try
            {
                presets = _session.GetPresets(profToken).StartAsTask().Result;
            }
            catch
            {
                // ignored
            }

            return new PtzData { Profile = prof, Node = LoadPtzNode(prof.ptzConfiguration), PtzPresets = presets, Status = LoadPtzStatus(prof.token) };
        }

        public async Task<PTZNode> LoadPtzNodeAsync(PTZConfiguration cfg)
        {
            try
            {
                //FIX: D-Link DSC-2230 doesn't support GetNode request
                return await _session.GetNode(cfg.nodeToken);
            }
            catch
            {
                // ignored
            }
            return CreateStandartPtzNode(cfg.nodeToken);
        }

        public PTZNode LoadPtzNode(PTZConfiguration cfg)
        {
            try
            {
                //FIX: D-Link DSC-2230 doesn't support GetNode request
                return _session.GetNode(cfg.nodeToken).StartAsTask().Result;
            }
            catch
            {
                // ignored
            }
            return CreateStandartPtzNode(cfg.nodeToken);
        }

        public async Task<PTZStatus> LoadPtzStatusAsync(string token)
        {
            try
            {
                return await ((IPtzAsync) _session).GetStatus(token);
            }
            catch
            {
                // ignored
            }
            return null;
        }

        public PTZStatus LoadPtzStatus(string token)
        {
            try
            {
                return  ((IPtzAsync)_session).GetStatus(token).StartAsTask().Result;
            }
            catch
            {
                // ignored
            }
            return null;
        }
            
        public PTZNode CreateStandartPtzNode(string nodeToken)
        {
            return new PTZNode
            {
                token = nodeToken,
                name = nodeToken,
                supportedPTZSpaces = new PTZSpaces
                {
                    absolutePanTiltPositionSpace = new[]
                    {
                        new Space2DDescription
                        {
                            uri = "http://www.onvif.org/ver10/tptz/PanTiltSpaces/PositionGenericSpace",
                            xRange = new FloatRange {min = -1.0f, max = 1.0f},
                            yRange = new FloatRange {min = -1.0f, max = 1.0f}
                        }
                    },
                    absoluteZoomPositionSpace = new[]
                    {
                        new Space1DDescription
                        {
                            uri = "http://www.onvif.org/ver10/tptz/ZoomSpaces/PositionGenericSpace",
                            xRange = new FloatRange {min = 0.0f, max = 1.0f}
                        }
                    },
                    relativePanTiltTranslationSpace = new[]
                    {
                        new Space2DDescription
                        {
                            uri = "http://www.onvif.org/ver10/tptz/PanTiltSpaces/TranslationGenericSpace",
                            xRange = new FloatRange {min = -1.0f, max = 1.0f},
                            yRange = new FloatRange {min = -1.0f, max = 1.0f}
                        }
                    },
                    relativeZoomTranslationSpace = new[]
                    {
                        new Space1DDescription
                        {
                            uri = "http://www.onvif.org/ver10/tptz/ZoomSpaces/TranslationGenericSpace",
                            xRange = new FloatRange {min = -1.0f, max = 1.0f}
                        }
                    },
                    continuousPanTiltVelocitySpace = new[]
                    {
                        new Space2DDescription
                        {
                            uri = "http://www.onvif.org/ver10/tptz/PanTiltSpaces/VelocityGenericSpace",
                            xRange = new FloatRange {min = -1.0f, max = 1.0f},
                            yRange = new FloatRange {min = -1.0f, max = 1.0f}
                        }

                    },
                    continuousZoomVelocitySpace = new[]
                    {
                        new Space1DDescription
                        {
                            uri = "http://www.onvif.org/ver10/tptz/ZoomSpaces/VelocityGenericSpace",
                            xRange = new FloatRange {min = -1.0f, max = 1.0f}
                        }
                    },
                    panTiltSpeedSpace = new[]
                    {
                        new Space1DDescription
                        {
                            uri = "http://www.onvif.org/ver10/tptz/PanTiltSpaces/GenericSpeedSpace",
                            xRange = new FloatRange {min = 0.0f, max = 1.0f}
                        }
                    },

                    zoomSpeedSpace = new[]
                    {
                        new Space1DDescription
                        {
                            uri = "http://www.onvif.org/ver10/tptz/ZoomSpaces/ZoomGenericSpeedSpace",
                            xRange = new FloatRange {min = 0.0f, max = 1.0f}
                        }
                    }
                },
                homeSupported = false,
                maximumNumberOfPresets = 0,
                auxiliaryCommands = null,
                extension = null,
                fixedHomePosition = false,
                fixedHomePositionSpecified = false
            };
        }
        #endregion

        #region Imaging

        public async Task SetImagingSettingsAsync(string profToken, ImagingSettings20 settings)
        {
            var profiles = await GetProfilesAsync();
            var profile = profiles.FirstOrDefault(x => x.token == profToken);
            if (profile != null)
            {
                var videoSourceToken = profile.videoSourceConfiguration.sourceToken;
                await Session.SetImagingSettings(videoSourceToken, settings, true); 
            }
        }

        public void SetImagingSettings(string profToken, ImagingSettings20 settings)
        {
            var profiles = GetProfiles();
            var profile = profiles.FirstOrDefault(x => x.token == profToken);
            if (profile != null)
            {
                var videoSourceToken = profile.videoSourceConfiguration.sourceToken;
                Session.SetImagingSettings(videoSourceToken, settings, true);
            }
        }

        public async Task<ImagingSettings20> GetImagingSettingsAsync(string profToken)
        {
            var profiles = await GetProfilesAsync();
            var profile = profiles.FirstOrDefault(x => x.token == profToken);
            if (profile != null)
            {
                var videoSourceToken = profile.videoSourceConfiguration.sourceToken;
                return await Session.GetImagingSettings(videoSourceToken); 
            }
            return null;
        }

        public ImagingSettings20 GetImagingSettings(string profToken)
        {
            var profiles = GetProfiles();
            var profile = profiles.FirstOrDefault(x => x.token == profToken);
            if (profile != null)
            {
                var videoSourceToken = profile.videoSourceConfiguration.sourceToken;
                return Session.GetImagingSettings(videoSourceToken).StartAsTask().Result;
            }
            return null;
        }

        public async Task<ImagingOptions20> GetOptionsAsync(string profToken)
        {
            var profiles = await GetProfilesAsync();
            var profile = profiles.FirstOrDefault(x => x.token == profToken);
            if (profile != null)
            {
                var videoSourceToken = profile.videoSourceConfiguration.sourceToken;
                return await Session.GetOptions(videoSourceToken); 
            }
            return null;
        }

        public ImagingOptions20 GetOptions(string profToken)
        {
            var profiles = GetProfiles();
            var profile = profiles.FirstOrDefault(x => x.token == profToken);
            if (profile != null)
            {
                var videoSourceToken = profile.videoSourceConfiguration.sourceToken;
                return Session.GetOptions(videoSourceToken).StartAsTask().Result;
            }
            return null;
        }

        public async Task MoveAsync(string profToken, FocusMove move)
        {
            var profiles = await GetProfilesAsync();
            var profile = profiles.FirstOrDefault(x => x.token == profToken);
            if (profile != null)
            {
                var videoSourceToken = profile.videoSourceConfiguration.sourceToken;
                await Session.Move(videoSourceToken, move);
            }
        }

        public void Move(string profToken, FocusMove move)
        {
            var profiles = GetProfiles();
            var profile = profiles.FirstOrDefault(x => x.token == profToken);
            if (profile != null)
            {
                var videoSourceToken = profile.videoSourceConfiguration.sourceToken;
                Session.Move(videoSourceToken, move).RunSynchronously();
            }
        }

        public async Task<MoveOptions20> GetMoveOptionsAsync(string profToken)
        {
            var profiles = await GetProfilesAsync();
            var profile = profiles.FirstOrDefault(x => x.token == profToken);
            if (profile != null)
            {
                var videoSourceToken = profile.videoSourceConfiguration.sourceToken;
                return await Session.GetMoveOptions(videoSourceToken);
            }
            return null;
        }

        public MoveOptions20 GetMoveOptions(string profToken)
        {
            var profiles = GetProfiles();
            var profile = profiles.FirstOrDefault(x => x.token == profToken);
            if (profile != null)
            {
                var videoSourceToken = profile.videoSourceConfiguration.sourceToken;
                return Session.GetMoveOptions(videoSourceToken).StartAsTask().Result;
            }
            return null;
        }

        public async Task<ImagingStatus20> GetImagingStatusAsync(string profToken)
        {
            var profiles = await GetProfilesAsync();
            var profile = profiles.FirstOrDefault(x => x.token == profToken);
            if (profile != null)
            {
                var videoSourceToken = profile.videoSourceConfiguration.sourceToken;
                return await ((IImagingAsync)Session).GetStatus(videoSourceToken);
            }
            return null;
        }

        public ImagingStatus20 GetImagingStatus(string profToken)
        {
            var profiles = GetProfiles();
            var profile = profiles.FirstOrDefault(x => x.token == profToken);
            if (profile != null)
            {
                var videoSourceToken = profile.videoSourceConfiguration.sourceToken;
                return ((IImagingAsync)Session).GetStatus(videoSourceToken).StartAsTask().Result;
            }
            return null;
        }

        #endregion

        #region Receivers

        public async Task<Receiver[]> GetReceiversAsync()
        {
            return await Session.GetReceivers(); 
        }

        public Receiver[] GetReceivers()
        {
            return Session.GetReceivers().StartAsTask().Result;
        }

        public async Task<Receiver> GetReceiverAsync(string receiverToken)
        {
            return await Session.GetReceiver(receiverToken);
        }

        public Receiver GetReceiver(string receiverToken)
        {
            return Session.GetReceiver(receiverToken).StartAsTask().Result;
        }

        public async Task<Receiver> CreateReceiverAsync(ReceiverConfiguration configuration)
        {
            return await Session.CreateReceiver(configuration);
        }

        public Receiver CreateReceiver(ReceiverConfiguration configuration)
        {
            return Session.CreateReceiver(configuration).StartAsTask().Result;
        }

        public async Task DeleteReceiverAsync(string receiverToken)
        {
            await Session.DeleteReceiver(receiverToken);
        }

        public void DeleteReceiver(string receiverToken)
        {
            Session.DeleteReceiver(receiverToken).RunSynchronously();
        }

        public async Task SetReceiverModeAsync(string receiverToken, ReceiverMode receiverMode)
        {
            await Session.SetReceiverMode(receiverToken, receiverMode);
        }

        public void SetReceiverMode(string receiverToken, ReceiverMode receiverMode)
        {
            Session.SetReceiverMode(receiverToken, receiverMode).RunSynchronously();
        }

        public async Task<ReceiverStateInformation> GetReceiverStateAsync(string receiverToken)
        {
            return await Session.GetReceiverState(receiverToken);
        }

        public ReceiverStateInformation GetReceiverState(string receiverToken)
        {
            return Session.GetReceiverState(receiverToken).StartAsTask().Result;
        }

        #endregion

        #region Replay
        public async Task<string> GetReplayUriAsync(string recordingToken, StreamSetup setup)
        {
            return await _session.GetReplayUri(recordingToken, setup);
        }

        public string GetReplayUri(string recordingToken, StreamSetup setup)
        {
            return _session.GetReplayUri(recordingToken, setup).StartAsTask().Result;
        }

        public async Task<ReplayConfiguration> GetReplayConfigurationAsync()
        {
           return await _session.GetReplayConfiguration();
        }

        public ReplayConfiguration GetReplayConfiguration()
        {
            return _session.GetReplayConfiguration().StartAsTask().Result;
        }

        public async Task SetReplayConfigurationAsync(ReplayConfiguration config)
        {
            await _session.SetReplayConfiguration(config);
        }

        public void SetReplayConfiguration(ReplayConfiguration config)
        {
            _session.SetReplayConfiguration(config).RunSynchronously();
        }
        #endregion

        #region Recordings
        public async Task<GetRecordingsResponseItem[]> GetRecordingsAsync()
        {
            return await ((IRecordingAsync)_session).GetRecordings();
        }

        public GetRecordingsResponseItem[] GetRecordings()
        {
            return ((IRecordingAsync)_session).GetRecordings().StartAsTask().Result;
        }

        public async Task<string> CreateRecordingAsync(RecordingConfiguration configuration)
        {
            return await ((IRecordingAsync)_session).CreateRecording(configuration);
        }

        public string CreateRecording(RecordingConfiguration configuration)
        {
            return ((IRecordingAsync)_session).CreateRecording(configuration).StartAsTask().Result;
        }

        public async Task DeleteRecordingAsync(string recordingToken)
        {
            await ((IRecordingAsync)_session).DeleteRecording(recordingToken);
        }

        public void DeleteRecording(string recordingToken)
        {
            ((IRecordingAsync)_session).DeleteRecording(recordingToken).RunSynchronously();
        }

        public async Task<RecordingConfiguration> GetRecordingConfigurationAsync(string recordingToken)
        {
            return await((IRecordingAsync)_session).GetRecordingConfiguration(recordingToken);
        }

        public RecordingConfiguration GetRecordingConfiguration(string recordingToken)
        {
            return ((IRecordingAsync)_session).GetRecordingConfiguration(recordingToken).StartAsTask().Result;
        }

        public async Task SetRecordingConfigurationAsync(string recordingToken, RecordingConfiguration config)
        {
            await ((IRecordingAsync)_session).SetRecordingConfiguration(recordingToken, config);
        }

        public void SetRecordingConfiguration(string recordingToken, RecordingConfiguration config)
        {
            ((IRecordingAsync)_session).SetRecordingConfiguration(recordingToken, config).RunSynchronously();
        }

        public async Task DeleteTrackAsync(string recordingToken, string trackToken)
        {
            await ((IRecordingAsync)_session).DeleteTrack(recordingToken, trackToken);
        }

        public void DeleteTrack(string recordingToken, string trackToken)
        {
            ((IRecordingAsync)_session).DeleteTrack(recordingToken, trackToken).RunSynchronously();
        }

        public async Task<TrackConfiguration> GetTrackConfigurationAsync(string recordingToken, string trackToken)
        {
            return await((IRecordingAsync)_session).GetTrackConfiguration(recordingToken, trackToken);
        }

        public TrackConfiguration GetTrackConfiguration(string recordingToken, string trackToken)
        {
            return ((IRecordingAsync)_session).GetTrackConfiguration(recordingToken, trackToken).StartAsTask().Result;
        }

        public async Task SetTrackConfigurationAsync(string recordingToken, string trackToken, TrackConfiguration config)
        {
            await ((IRecordingAsync)_session).SetTrackConfiguration(recordingToken, trackToken, config);
        }

        public void SetTrackConfiguration(string recordingToken, string trackToken, TrackConfiguration config)
        {
            ((IRecordingAsync)_session).SetTrackConfiguration(recordingToken, trackToken, config).RunSynchronously();
        }

        public async Task<Tuple<string, RecordingJobConfiguration>> CreateRecordingJobAsync(RecordingJobConfiguration config)
        {
            return await((IRecordingAsync)_session).CreateRecordingJob(config);
        }

        public Tuple<string, RecordingJobConfiguration> CreateRecordingJob(RecordingJobConfiguration config)
        {
            return ((IRecordingAsync)_session).CreateRecordingJob(config).StartAsTask().Result;
        }

        public async Task DeleteRecordingJobAsync(string jobToken)
        {
            await ((IRecordingAsync)_session).DeleteRecordingJob(jobToken);
        }

        public void DeleteRecordingJob(string jobToken)
        {
           ((IRecordingAsync)_session).DeleteRecordingJob(jobToken).RunSynchronously();
        }

        public async Task<GetRecordingJobsResponseItem[]> GetRecordingJobsAsync()
        {
            return await((IRecordingAsync)_session).GetRecordingJobs();
        }

        public GetRecordingJobsResponseItem[] GetRecordingJobs()
        {
            return ((IRecordingAsync)_session).GetRecordingJobs().StartAsTask().Result;
        }

        public async Task<RecordingJobConfiguration> SetRecordingJobConfigurationAsync(string jobToken, RecordingJobConfiguration config)
        {
            return await ((IRecordingAsync)_session).SetRecordingJobConfiguration(jobToken, config);
        }

        public RecordingJobConfiguration SetRecordingJobConfiguration(string jobToken, RecordingJobConfiguration config)
        {
            return ((IRecordingAsync)_session).SetRecordingJobConfiguration(jobToken, config).StartAsTask().Result;
        }

        public async Task<RecordingJobConfiguration> GetRecordingJobConfigurationAsync(string jobToken)
        {
            return await ((IRecordingAsync)_session).GetRecordingJobConfiguration(jobToken);
        }

        public RecordingJobConfiguration GetRecordingJobConfiguration(string jobToken)
        {
            return ((IRecordingAsync)_session).GetRecordingJobConfiguration(jobToken).StartAsTask().Result;
        }

        public async Task SetRecordingJobModeAsync(string jobToken, string mode)
        {
            await ((IRecordingAsync)_session).SetRecordingJobMode(jobToken, mode);
        }

        public void SetRecordingJobMode(string jobToken, string mode)
        {
            ((IRecordingAsync)_session).SetRecordingJobMode(jobToken, mode).RunSynchronously();
        }

        public async Task<RecordingJobStateInformation> GetRecordingJobStateAsync(string jobToken)
        {
            return await((IRecordingAsync)_session).GetRecordingJobState(jobToken);
        }

        public RecordingJobStateInformation GetRecordingJobState(string jobToken)
        {
            return ((IRecordingAsync)_session).GetRecordingJobState(jobToken).RunSynchronously();
        }
        #endregion

        private static bool NotNull(object current)
        {
            return current != null;
        }

        public void Dispose()
        {
            ExecWrappedIgnore(() =>
            {
                if (_facade != null)
                {
                    _facade.Dispose();
                }
                if (_factory != null)
                {
                    _factory.Dispose();
                }
                if (_session != null)
                {
                    _session.Dispose();
                }
            });
            ExecWrappedIgnore(() => _facade = null);
            ExecWrappedIgnore(() => _session = null);
            ExecWrappedIgnore(() => _factory = null);
        }

        public void DisposeChannels()
        {
            if (_factory != null)
            {
                _factory.DisposeChannels();
            }    
        }

        public void DisposeEventChannels()
        {
            if (_factory != null)
            {
                _factory.DisposeEventChannels();
            }

            if (_session != null)
            {
                _session.Dispose();
            }
        }

        private void ExecWrappedIgnore(Action func)
        {
            try
            {
                func();
            }
            catch
            {
                // ignored
            }
        }
    }
}
