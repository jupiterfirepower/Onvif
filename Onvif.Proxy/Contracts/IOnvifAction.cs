using System.Threading.Tasks;
using onvif.services;

namespace Onvif.Proxy.Contracts
{
    public interface IOnvifAction
    {
        Task<SupportedActions> GetSupportedActions();
        Task<Action1[]> GetActions();
        Task<ActionTrigger[]> GetActionTriggers();

        Task<Action1[]> CreateActions(ActionConfiguration[] actConf);

        Task DeleteActions(string[] actions);

        Task ModifyActions(Action1[] actions);

        Task<ActionTrigger[]> CreateActionTriggers(ActionTriggerConfiguration[] configurations);

        Task DeleteActionTriggers(string[] triggers);

        Task ModifyActionTriggers(ActionTrigger[] triggers);
    }
}
