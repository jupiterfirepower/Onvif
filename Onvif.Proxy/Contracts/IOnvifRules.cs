using System.Threading.Tasks;
using onvif.services;

namespace Onvif.Proxy.Contracts
{
    public interface IOnvifRules
    {
        Task CreateRules(string vacToken, Config[] rules);
        Task DeleteRules(string vacToken, string[] ruleNames);

        Task<Config[]> GetRules(string vacToken);
        Task ModifyRules(string vacToken, Config[] rules);
    }
}
