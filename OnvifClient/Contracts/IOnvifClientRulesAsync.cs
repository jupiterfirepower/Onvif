using System.Threading.Tasks;
using onvif.services;
using Onvif.Camera.Client.Model;
using Onvif.Contracts.Messages.Onvif;

namespace Onvif.Camera.Client.Contracts
{
    public interface IOnvifClientRulesAsync
    {
        Task<OnvifResult> CreateRulesAsync(string vacToken, Config[] rules);
        Task<OnvifResult> DeleteRulesAsync(string vacToken, string[] ruleNames);
        Task<OnvifClientResult<Config[]>> GetRulesAsync(string vacToken);
        Task<OnvifResult> ModifyRulesAsync(string vacToken, Config[] rules);
    }
}
