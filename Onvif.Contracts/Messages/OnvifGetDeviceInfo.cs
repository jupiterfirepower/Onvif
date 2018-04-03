using Onvif.Contracts.Messages.Onvif;

namespace Onvif.Contracts.Messages
{
    public class OnvifGetDeviceInfo : OnvifBase
    {
        public OnvifGetDeviceInfo(string uri, string userName, string password) : base(uri, userName, password)
        {
        }
    }
}
