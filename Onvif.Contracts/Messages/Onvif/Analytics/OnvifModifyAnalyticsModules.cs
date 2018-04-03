using onvif.services;

namespace Onvif.Contracts.Messages.Onvif.Analytics
{
    public class OnvifModifyAnalyticsModules : OnvifBase
    {
        public string VacToken { get; private set; }
        public Config[] AnalytycsModules { get; private set; }

        public OnvifModifyAnalyticsModules(string uri, string userName, string password, string vacToken, Config[] analytycsModules)
            : base(uri, userName, password)
        {
            VacToken = vacToken;
            AnalytycsModules = analytycsModules;
        }
    }
}
