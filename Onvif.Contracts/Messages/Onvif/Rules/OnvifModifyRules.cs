using onvif.services;

namespace Onvif.Contracts.Messages.Onvif.Rules
{
    public class OnvifModifyRules : OnvifBase
    {
        public string VacToken { get; private set; }
        public Config[] Rules { get; private set; }

        public OnvifModifyRules(string uri, string userName, string password, string vacToken, Config[] rules)
            : base(uri, userName, password)
        {
            VacToken = vacToken;
            Rules = rules;
        }
    }
}
