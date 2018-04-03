using onvif.services;

namespace Onvif.Contracts.Messages.Onvif.Actions
{
    public class OnvifModifyActionTriggers : OnvifBase
    {
        public ActionTrigger[] Triggers { get; private set; }

        public OnvifModifyActionTriggers(string uri, string userName, string password, ActionTrigger[] triggers)
            : base(uri, userName, password)
        {
            Triggers = triggers;
        }
    }
}
