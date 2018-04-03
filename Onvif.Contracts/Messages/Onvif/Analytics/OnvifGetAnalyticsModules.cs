namespace Onvif.Contracts.Messages.Onvif.Analytics
{
    public class OnvifGetAnalyticsModules : OnvifBase
    {
        public string VacToken { get; private set; }

        public OnvifGetAnalyticsModules(string uri, string userName, string password, string vacToken)
            : base(uri, userName, password)
        {
            VacToken = vacToken;
        }
    }
}
