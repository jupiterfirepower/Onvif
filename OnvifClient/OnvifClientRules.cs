using System.Threading.Tasks;
using Akka.Actor;
using onvif.services;
using Onvif.Camera.Client.Model;
using Onvif.Contracts.Messages.Onvif;
using Onvif.Contracts.Messages.Onvif.Rules;
using Onvif.Contracts.Model;

namespace Onvif.Camera.Client
{
    public partial class OnvifClient
    {
        public async Task<OnvifResult> CreateRulesAsync(string vacToken, Config[] rules)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifCreateRules(_url, _userName, _password, vacToken, rules));
        }

        public OnvifResult CreateRules(string vacToken, Config[] rules)
        {
            return CreateRules(_url, _userName, _password, vacToken, rules);
        }

        public OnvifResult CreateRules(string url, string userName, string password, string vacToken, Config[] rules)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifCreateRules(url, userName, password, vacToken, rules)).Result;
        }

        public async Task<OnvifResult> DeleteRulesAsync(string vacToken, string[] ruleNames)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifDeleteRules(_url, _userName, _password, vacToken, ruleNames));
        }

        public OnvifResult DeleteRules(string vacToken, string[] ruleNames)
        {
            return DeleteRules(_url, _userName, _password, vacToken, ruleNames);
        }

        public OnvifResult DeleteRules(string url, string userName, string password, string vacToken, string[] ruleNames)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifDeleteRules(url, userName, password, vacToken, ruleNames)).Result;
        }

        public async Task<OnvifClientResult<Config[]>> GetRulesAsync(string vacToken)
        {
            var result = await _proxyActor.Ask<Container<Config[]>>(new OnvifGetRules(_url, _userName, _password, vacToken));
            return result.Success ? (OnvifClientResult<Config[]>)new OnvifClientResultData<Config[]>(result.WorkItem)
                : new OnvifClientResultEmpty<Config[]>(new Config[0]);
        }

        public OnvifClientResult<Config[]> GetRules(string vacToken)
        {
            return GetRules(_url, _userName, _password, vacToken);
        }

        public OnvifClientResult<Config[]> GetRules(string url, string userName, string password, string vacToken)
        {
            var result = _proxyActor.Ask<Container<Config[]>>(new OnvifGetRules(url, userName, password, vacToken)).Result;
            return result.Success ? (OnvifClientResult<Config[]>)new OnvifClientResultData<Config[]>(result.WorkItem)
                : new OnvifClientResultEmpty<Config[]>(new Config[0]);
        }

        public async Task<OnvifResult> ModifyRulesAsync(string vacToken, Config[] rules)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifModifyRules(_url, _userName, _password, vacToken, rules));
        }

        public OnvifResult ModifyRules(string vacToken, Config[] rules)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifModifyRules(_url, _userName, _password, vacToken, rules)).Result;
        }

        public OnvifResult ModifyRules(string url, string userName, string password, string vacToken, Config[] rules)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifModifyRules(url, userName, password, vacToken, rules)).Result;
        }
    }
}
