using System.Threading.Tasks;
using onvif.services;

namespace Onvif.Proxy.Contracts.Contract
{
    public interface IOnvifRules
    {
        Task CreateRulesAsync(string vacToken, Config[] rules);
        Task DeleteRulesAsync(string vacToken, string[] ruleNames);
        Task<Config[]> GetRulesAsync(string vacToken);
        Task ModifyRulesAsync(string vacToken, Config[] rules);

        void CreateRules(string vacToken, Config[] rules);
        void DeleteRules(string vacToken, string[] ruleNames);
        Config[] GetRules(string vacToken);
        void ModifyRules(string vacToken, Config[] rules);
    }
}
