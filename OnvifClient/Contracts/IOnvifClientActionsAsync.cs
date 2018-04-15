using System.Threading.Tasks;
using onvif.services;
using Onvif.Camera.Client.Model;
using Onvif.Contracts.Messages.Onvif;

namespace Onvif.Camera.Client.Contracts
{
    public interface IOnvifClientActionsAsync
    {
        Task<OnvifClientResult<SupportedActions>> GetSupportedActionsAsync();
        Task<OnvifClientResult<Action1[]>> GetActionsAsync();
        Task<OnvifClientResult<ActionTrigger[]>> GetActionTriggersAsync();
        Task<OnvifClientResult<Action1[]>> CreateActionsAsync(ActionConfiguration[] actConf);
        Task<OnvifResult> DeleteActionsAsync(string[] actions);
        Task<OnvifResult> ModifyActionsAsync(Action1[] actions);
        Task<OnvifClientResult<ActionTrigger[]>> CreateActionTriggersAsync(ActionTriggerConfiguration[] configurations);
        Task<OnvifResult> DeleteActionTriggersAsync(string[] triggers);
        Task<OnvifResult> ModifyActionTriggersAsync(ActionTrigger[] triggers);
    }
}
