using System.Threading.Tasks;
using onvif.services;

namespace Onvif.Client.Contracts
{
    public interface IOnvifClientActionsAsync
    {
        Task<SupportedActions> GetSupportedActionsAsync();
        Task<Action1[]> GetActionsAsync();
        /*Task<OnvifClientResult<ActionTrigger[]>> GetActionTriggersAsync();
        Task<OnvifClientResult<Action1[]>> CreateActionsAsync(ActionConfiguration[] actConf);
        Task<OnvifResult> DeleteActionsAsync(string[] actions);
        Task<OnvifResult> ModifyActionsAsync(Action1[] actions);
        Task<OnvifClientResult<ActionTrigger[]>> CreateActionTriggersAsync(ActionTriggerConfiguration[] configurations);
        Task<OnvifResult> DeleteActionTriggersAsync(string[] triggers);
        Task<OnvifResult> ModifyActionTriggersAsync(ActionTrigger[] triggers);*/
    }
}
