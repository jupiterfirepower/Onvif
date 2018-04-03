using Onvif.Contracts.Messages.Onvif;

namespace Onvif.Contracts.Messages
{
    public class OnvifGetProfileManagement : OnvifBase
    {
        public OnvifGetProfileManagement(string uri, string userName, string password) : base(uri, userName, password)
        {
        }
    }
}
