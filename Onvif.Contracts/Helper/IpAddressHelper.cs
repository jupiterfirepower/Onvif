using System;
using System.Net;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace Onvif.Contracts.Helper
{
    public class IpAddressHelper
    {
        static IPAddress FindGetGatewayAddress()
        {
            IPGlobalProperties ipGlobProps = IPGlobalProperties.GetIPGlobalProperties();

            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                IPInterfaceProperties ipInfProps = ni.GetIPProperties();
                foreach (GatewayIPAddressInformation gi in ipInfProps.GatewayAddresses)
                    return gi.Address;
            }
            return null;
        }

        public static IPAddress FindLanAddress()
        {
            IPAddress gateway = FindGetGatewayAddress();
            if (gateway == null)
                return null;

            IPAddress[] pIpAddress = Dns.GetHostAddresses(Dns.GetHostName());

            foreach (IPAddress address in pIpAddress)
            {
                if (IsAddressOfGateway(address, gateway))
                    return address;
                return null;
            }
            return null;
        }

        static bool IsAddressOfGateway(IPAddress address, IPAddress gateway)
        {
            if (address != null && gateway != null)
                return IsAddressOfGateway(address.GetAddressBytes(),gateway.GetAddressBytes());
            return false;
        }
        static bool IsAddressOfGateway(byte[] address, byte[] gateway)
        {
            if (address != null && gateway != null)
            {
                int gwLen = gateway.Length;
                if (gwLen > 0)
                {
                    if (address.Length == gateway.Length)
                    {
                        --gwLen;
                        int counter = 0;
                        for (int i = 0; i < gwLen; i++)
                        {
                            if (address[i] == gateway[i])
                                ++counter;
                        }
                        return (counter == gwLen);
                    }
                }
            }
            return false;

        }
        
        public static string GetExternalIpAddress()
        {
            try
            {
                using (var client = new WebClient())
                {
                    return client.DownloadString("http://icanhazip.com/").TrimEnd('\n').Trim();
                }
            }
            catch
            {
                // ignored
            }

            try
            {
                using (var client = new WebClient())
                {
                    return client.DownloadString("http://bot.whatismyipaddress.com").TrimEnd('\n').Trim();
                }
            }
            catch
            {
                // ignored
            }

            try
            {
                using (var client = new WebClient())
                {
                    return client.DownloadString("http://ipinfo.io/ip").TrimEnd('\n').Trim();
                }
            }
            catch
            {
                // ignored
            }

            try
            {
                using (var client = new WebClient())
                {
                    return client.DownloadString("https://api.ipify.org").TrimEnd('\n').Trim();
                }
            }
            catch
            {
                // ignored
            }

            try
            {
                string externalIp;
                using (var client = new WebClient())
                {
                    externalIp = client.DownloadString("http://checkip.dyndns.org/");
                    externalIp = new Regex(@"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}")
                                 .Matches(externalIp)[0].ToString();
                }
                return externalIp;
            }
            catch
            {
                // ignored
            }
            return null;
        }

        private static bool IsLocalIpAddress(string host)
        {
            try
            { // get host IP addresses
                IPAddress[] hostIPs = Dns.GetHostAddresses(host);
                // get local IP addresses
                IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());

                hostIPs.Any(hostIp => IPAddress.IsLoopback(hostIp) || localIPs.Contains(hostIp));
                // test if any host IP equals to any local IP or to localhost
            }
            catch
            {
                // ignored
            }
            return false;
        }

        public static bool IsLocalAddress(string ip)
        {
            var host = ip;
            IPAddress ipAddress;
            bool result = IPAddress.TryParse(ip, out ipAddress);
            return result ? IsPrivateIp(ipAddress) : IsLocalIpAddress(host);
        }

        /// <summary>
        /// The private address ranges are defined in RFC1918. They are:
        //10.0.0.0 - 10.255.255.255 (10/8 prefix)
        //172.16.0.0 - 172.31.255.255 (172.16/12 prefix)
        //192.168.0.0 - 192.168.255.255 (192.168/16 prefix)
        //You might also want to filter out link-local addresses (169.254/16) as defined in RFC3927.
        /// </summary>
        /// <param name="myIpAddress"></param>
        /// <returns></returns>
        private static bool IsPrivateIp(IPAddress myIpAddress)
        {
            if (myIpAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                byte[] ipBytes = myIpAddress.GetAddressBytes();

                // 10.0.0.0/24 
                if (ipBytes[0] == 10)
                {
                    return true;
                }
                // 172.16.0.0/16
                if (ipBytes[0] == 172 && ipBytes[1] == 16)
                {
                    return true;
                }
                // 192.168.0.0/16
                if (ipBytes[0] == 192 && ipBytes[1] == 168)
                {
                    return true;
                }
                // 169.254.0.0/16
                if (ipBytes[0] == 169 && ipBytes[1] == 254)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
