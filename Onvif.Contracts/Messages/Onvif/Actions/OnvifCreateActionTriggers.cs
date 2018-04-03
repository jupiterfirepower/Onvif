using onvif.services;

namespace Onvif.Contracts.Messages.Onvif.Actions
{
    public class OnvifCreateActionTriggers : OnvifBase
    {
        public ActionTriggerConfiguration[] Configurations { get; private set; }

        public OnvifCreateActionTriggers(string uri, string userName, string password, ActionTriggerConfiguration[] configurations)
            : base(uri, userName, password)
        {
            Configurations = configurations;
        }
    }
}
