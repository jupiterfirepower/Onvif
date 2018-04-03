using onvif.services;

namespace Onvif.Contracts.Messages.Onvif.Actions
{
    public class OnvifModifyActions : OnvifBase
    {
        public Action1[] Actions { get; private set; }

        public OnvifModifyActions(string uri, string userName, string password, Action1[] actions)
            : base(uri, userName, password)
        {
            Actions = actions;
        }
    }
}
