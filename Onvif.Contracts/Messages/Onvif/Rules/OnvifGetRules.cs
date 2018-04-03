namespace Onvif.Contracts.Messages.Onvif.Rules
{
    public class OnvifGetRules : OnvifBase
    {
        public string VacToken { get; private set; }

        public OnvifGetRules(string uri, string userName, string password, string vacToken)
            : base(uri, userName, password)
        {
            VacToken = vacToken;
        }
    }
}
