using onvif.services;
using Onvif.Camera.Client.Model;
using Onvif.Contracts.Messages.Onvif;

namespace Onvif.Camera.Client.Contracts
{
    public interface IOnvifClientRulesSync
    {
        OnvifResult CreateRules(string vacToken, Config[] rules);
        OnvifResult DeleteRules(string vacToken, string[] ruleNames);
        OnvifClientResult<Config[]> GetRules(string vacToken);
        OnvifResult ModifyRules(string vacToken, Config[] rules);

        OnvifResult CreateRules(string url, string userName, string password, string vacToken, Config[] rules);
        OnvifResult DeleteRules(string url, string userName, string password, string vacToken, string[] ruleNames);
        OnvifClientResult<Config[]> GetRules(string url, string userName, string password, string vacToken);
        OnvifResult ModifyRules(string url, string userName, string password, string vacToken, Config[] rules);
    }
}
