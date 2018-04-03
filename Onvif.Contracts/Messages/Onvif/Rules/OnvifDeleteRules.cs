namespace Onvif.Contracts.Messages.Onvif.Rules
{
    public class OnvifDeleteRules : OnvifBase
    {
        public string VacToken { get; private set; }
        public string[] RuleNames { get; private set; }

        public OnvifDeleteRules(string uri, string userName, string password, string vacToken,string[] ruleNames)
            : base(uri, userName, password)
        {
            VacToken = vacToken;
            RuleNames = ruleNames;
        }
    }
}
