using onvif.services;

namespace Onvif.Contracts.Messages.Onvif.Actions
{
    public class OnvifCreateActions : OnvifBase
    {
        public ActionConfiguration[] Configurations { get; private set; }

        public OnvifCreateActions(string uri, string userName, string password, ActionConfiguration[] configurations)
            : base(uri, userName, password)
        {
            Configurations = configurations;
        }
    }
}
