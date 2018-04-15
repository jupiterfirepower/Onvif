using System.Threading.Tasks;
using Akka.Actor;
using onvif.services;
using Onvif.Camera.Client.Model;
using Onvif.Contracts.Messages.Onvif;
using Onvif.Contracts.Messages.Onvif.Actions;
using Onvif.Contracts.Model;

namespace Onvif.Camera.Client
{
    public partial class OnvifClient
    {
        public async Task<OnvifClientResult<SupportedActions>> GetSupportedActionsAsync()
        {
            var result = await _proxyActor.Ask<Container<SupportedActions>>(new OnvifGetSupportedActions(_url, _userName, _password));
            return result.Success ? (OnvifClientResult<SupportedActions>)new OnvifClientResultData<SupportedActions>(result.WorkItem) :
                new OnvifClientResultEmpty<SupportedActions>(new SupportedActions());
        }

        public OnvifClientResult<SupportedActions> GetSupportedActions()
        {
            return GetSupportedActions(_url, _userName, _password);
        }

        public OnvifClientResult<SupportedActions> GetSupportedActions(string url, string userName, string password)
        {
            var result = _proxyActor.Ask<Container<SupportedActions>>(new OnvifGetSupportedActions(url, userName, password)).Result;
            return result.Success ? (OnvifClientResult<SupportedActions>)new OnvifClientResultData<SupportedActions>(result.WorkItem) :
                new OnvifClientResultEmpty<SupportedActions>(new SupportedActions());
        }

        public async Task<OnvifClientResult<Action1[]>> GetActionsAsync()
        {
            var result = await _proxyActor.Ask<Container<Action1[]>>(new OnvifGetActions(_url, _userName, _password));
            return result.Success ? (OnvifClientResult<Action1[]>)new OnvifClientResultData<Action1[]>(result.WorkItem) :
                new OnvifClientResultEmpty<Action1[]>(new Action1[0]);
        }

        public OnvifClientResult<Action1[]> GetActions()
        {
            return GetActions(_url, _userName, _password);
        }

        public OnvifClientResult<Action1[]> GetActions(string url, string userName, string password)
        {
            var result = _proxyActor.Ask<Container<Action1[]>>(new OnvifGetActions(url, userName, password)).Result;
            return result.Success ? (OnvifClientResult<Action1[]>)new OnvifClientResultData<Action1[]>(result.WorkItem) :
                new OnvifClientResultEmpty<Action1[]>(new Action1[0]);
        }

        public async Task<OnvifClientResult<ActionTrigger[]>> GetActionTriggersAsync()
        {
            var result = await _proxyActor.Ask<Container<ActionTrigger[]>>(new OnvifGetActionTriggers(_url, _userName, _password));
            return result.Success ? (OnvifClientResult<ActionTrigger[]>)new OnvifClientResultData<ActionTrigger[]>(result.WorkItem) :
                new OnvifClientResultEmpty<ActionTrigger[]>(new ActionTrigger[0]);
        }

        public OnvifClientResult<ActionTrigger[]> GetActionTriggers()
        {
            return GetActionTriggers(_url, _userName, _password);
        }

        public OnvifClientResult<ActionTrigger[]> GetActionTriggers(string url, string userName, string password)
        {
            var result = _proxyActor.Ask<Container<ActionTrigger[]>>(new OnvifGetActionTriggers(url, userName, password)).Result;
            return result.Success ? (OnvifClientResult<ActionTrigger[]>)new OnvifClientResultData<ActionTrigger[]>(result.WorkItem) :
                new OnvifClientResultEmpty<ActionTrigger[]>(new ActionTrigger[0]);
        }

        public async Task<OnvifClientResult<Action1[]>> CreateActionsAsync(ActionConfiguration[] actConf)
        {
            var result = await _proxyActor.Ask<Container<Action1[]>>(new OnvifCreateActions(_url, _userName, _password, actConf));
            return result.Success ? (OnvifClientResult<Action1[]>)new OnvifClientResultData<Action1[]>(result.WorkItem) :
                new OnvifClientResultEmpty<Action1[]>(new Action1[0]);
        }

        public OnvifClientResult<Action1[]> CreateActions(ActionConfiguration[] actConf)
        {
            return CreateActions(_url, _userName, _password, actConf);
        }

        public OnvifClientResult<Action1[]> CreateActions(string url, string userName, string password, ActionConfiguration[] actConf)
        {
            var result = _proxyActor.Ask<Container<Action1[]>>(new OnvifCreateActions(_url, _userName, _password, actConf)).Result;
            return result.Success ? (OnvifClientResult<Action1[]>)new OnvifClientResultData<Action1[]>(result.WorkItem) :
                new OnvifClientResultEmpty<Action1[]>(new Action1[0]);
        }

        public async Task<OnvifClientResult<ActionTrigger[]>> CreateActionTriggersAsync(ActionTriggerConfiguration[] configurations)
        {
            var result = await _proxyActor.Ask<Container<ActionTrigger[]>>(new OnvifCreateActionTriggers(_url, _userName, _password, configurations));
            return result.Success ? (OnvifClientResult<ActionTrigger[]>)new OnvifClientResultData<ActionTrigger[]>(result.WorkItem) :
                new OnvifClientResultEmpty<ActionTrigger[]>(new ActionTrigger[0]);
        }

        public OnvifClientResult<ActionTrigger[]> CreateActionTriggers(ActionTriggerConfiguration[] configurations)
        {
            return CreateActionTriggers(_url, _userName, _password, configurations);
        }

        public OnvifClientResult<ActionTrigger[]> CreateActionTriggers(string url, string userName, string password, ActionTriggerConfiguration[] configurations)
        {
            var result = _proxyActor.Ask<Container<ActionTrigger[]>>(new OnvifCreateActionTriggers(url, userName, password, configurations)).Result;
            return result.Success ? (OnvifClientResult<ActionTrigger[]>)new OnvifClientResultData<ActionTrigger[]>(result.WorkItem) :
                new OnvifClientResultEmpty<ActionTrigger[]>(new ActionTrigger[0]);
        }

        public async Task<OnvifResult> DeleteActionsAsync(string[] actions)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifDeleteActions(_url, _userName, _password, actions));
        }

        public OnvifResult DeleteActions(string[] actions)
        {
            return DeleteActions(_url, _userName, _password, actions);
        }

        public OnvifResult DeleteActions(string url, string userName, string password, string[] actions)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifDeleteActions(url, userName, password, actions)).Result;
        }

        public async Task<OnvifResult> ModifyActionsAsync(Action1[] actions)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifModifyActions(_url, _userName, _password, actions));
        }

        public OnvifResult ModifyActions(Action1[] actions)
        {
            return ModifyActions(_url, _userName, _password, actions);
        }

        public OnvifResult ModifyActions(string url, string userName, string password, Action1[] actions)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifModifyActions(url, userName, password, actions)).Result;
        }

        public async Task<OnvifResult> DeleteActionTriggersAsync(string[] triggers)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifDeleteActionTriggers(_url, _userName, _password, triggers));
        }

        public OnvifResult DeleteActionTriggers(string[] triggers)
        {
            return DeleteActionTriggers(_url, _userName, _password, triggers);
        }

        public OnvifResult DeleteActionTriggers(string url, string userName, string password, string[] triggers)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifDeleteActionTriggers(url, userName, password, triggers)).Result;
        }

        public async Task<OnvifResult> ModifyActionTriggersAsync(ActionTrigger[] triggers)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifModifyActionTriggers(_url, _userName, _password, triggers));
        }

        public OnvifResult ModifyActionTriggers(ActionTrigger[] triggers)
        {
            return ModifyActionTriggers(_url, _userName, _password, triggers);
        }

        public OnvifResult ModifyActionTriggers(string url, string userName, string password, ActionTrigger[] triggers)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifModifyActionTriggers(url, userName, password, triggers)).Result;
        }
    }
}
