using System.Threading.Tasks;
using onvif.services;

namespace Onvif.Proxy.Contracts.Contract
{
    public interface IOnvifAction
    {
        Task<SupportedActions> GetSupportedActionsAsync();

        Task<Action1[]> GetActionsAsync();

        Task<ActionTrigger[]> GetActionTriggersAsync();

        Task<Action1[]> CreateActionsAsync(ActionConfiguration[] actConf);

        Task DeleteActionsAsync(string[] actions);

        Task ModifyActionsAsync(Action1[] actions);

        Task<ActionTrigger[]> CreateActionTriggersAsync(ActionTriggerConfiguration[] configurations);

        Task DeleteActionTriggersAsync(string[] triggers);

        Task ModifyActionTriggersAsync(ActionTrigger[] triggers);

        SupportedActions GetSupportedActions();
        Action1[] GetActions();
        ActionTrigger[] GetActionTriggers();
        Action1[] CreateActions(ActionConfiguration[] actConf);
        void DeleteActions(string[] actions);
        void ModifyActions(Action1[] actions);
        ActionTrigger[] CreateActionTriggers(ActionTriggerConfiguration[] configurations);
        void DeleteActionTriggers(string[] triggers);
        void ModifyActionTriggers(ActionTrigger[] triggers);
    }
}
