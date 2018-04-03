using onvif.services;

namespace Onvif.Contracts.Messages.Onvif.Rules
{
    public class OnvifCreateRules : OnvifBase
    {
        public string VacToken { get; private set; }
        public Config[] Rules { get; private set; }

        public OnvifCreateRules(string uri, string userName, string password, string vacToken, Config[] rules)
            : base(uri, userName, password)
        {
            VacToken = vacToken;
            Rules = rules;
        }
    }
}
