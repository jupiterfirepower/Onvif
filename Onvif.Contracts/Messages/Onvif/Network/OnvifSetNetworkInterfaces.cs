using onvif.services;

namespace Onvif.Contracts.Messages.Onvif.Network
{
    public class OnvifSetNetworkInterfaces : OnvifBase
    {
       public string Token { get; private set; }
       public NetworkInterfaceSetConfiguration NetworkConfiguration { get; private set; }

       public OnvifSetNetworkInterfaces(string uri, string userName, string password, string token, NetworkInterfaceSetConfiguration networkConfiguration)
           : base(uri, userName, password)
       {
           Token = token;
           NetworkConfiguration = networkConfiguration;
       }
    }
}
