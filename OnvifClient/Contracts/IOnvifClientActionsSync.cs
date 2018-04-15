using onvif.services;
using Onvif.Camera.Client.Model;
using Onvif.Contracts.Messages.Onvif;

namespace Onvif.Camera.Client.Contracts
{
    public interface IOnvifClientActionsSync
    {
        OnvifClientResult<SupportedActions> GetSupportedActions();
        OnvifClientResult<Action1[]> GetActions();
        OnvifClientResult<ActionTrigger[]> GetActionTriggers();
        OnvifClientResult<Action1[]> CreateActions(ActionConfiguration[] actConf);
        OnvifResult DeleteActions(string[] actions);
        OnvifResult ModifyActions(Action1[] actions);
        OnvifClientResult<ActionTrigger[]> CreateActionTriggers(ActionTriggerConfiguration[] configurations);
        OnvifResult DeleteActionTriggers(string[] triggers);
        OnvifResult ModifyActionTriggers(ActionTrigger[] triggers);

        OnvifClientResult<SupportedActions> GetSupportedActions(string url, string userName, string password);
        OnvifClientResult<Action1[]> GetActions(string url, string userName, string password);
        OnvifClientResult<ActionTrigger[]> GetActionTriggers(string url, string userName, string password);
        OnvifClientResult<Action1[]> CreateActions(string url, string userName, string password, ActionConfiguration[] actConf);
        OnvifClientResult<ActionTrigger[]> CreateActionTriggers(string url, string userName, string password, ActionTriggerConfiguration[] configurations);
        OnvifResult DeleteActions(string url, string userName, string password, string[] actions);
        OnvifResult ModifyActions(string url, string userName, string password, Action1[] actions);
        OnvifResult DeleteActionTriggers(string url, string userName, string password, string[] triggers);
        OnvifResult ModifyActionTriggers(string url, string userName, string password, ActionTrigger[] triggers);
    }
}
