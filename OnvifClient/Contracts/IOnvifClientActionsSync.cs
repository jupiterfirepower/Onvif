using onvif.services;

namespace Onvif.Client.Contracts
{
    public interface IOnvifClientActionsSync
    {
        SupportedActions GetSupportedActions();
        /*Action1[] GetActions();
        ActionTrigger[] GetActionTriggers();
        Action1[] CreateActions(ActionConfiguration[] actConf);
        void DeleteActions(string[] actions);
        void ModifyActions(Action1[] actions);
        ActionTrigger[] CreateActionTriggers(ActionTriggerConfiguration[] configurations);
        void DeleteActionTriggers(string[] triggers);
        void ModifyActionTriggers(ActionTrigger[] triggers);

        SupportedActions GetSupportedActions(string url, string userName, string password);
        Action1[] GetActions(string url, string userName, string password);
        ActionTrigger[] GetActionTriggers(string url, string userName, string password);
        Action1[] CreateActions(string url, string userName, string password, ActionConfiguration[] actConf);
        ActionTrigger[] CreateActionTriggers(string url, string userName, string password, ActionTriggerConfiguration[] configurations);
        void DeleteActions(string url, string userName, string password, string[] actions);
        void ModifyActions(string url, string userName, string password, Action1[] actions);
        void DeleteActionTriggers(string url, string userName, string password, string[] triggers);
        void ModifyActionTriggers(string url, string userName, string password, ActionTrigger[] triggers);*/
    }
}
