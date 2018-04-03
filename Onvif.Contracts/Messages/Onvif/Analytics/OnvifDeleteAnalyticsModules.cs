namespace Onvif.Contracts.Messages.Onvif.Analytics
{
    public class OnvifDeleteAnalyticsModules : OnvifBase
    {
        public string VacToken { get; private set; }
        public string[] AnalytycModuleNames { get; private set; }

        public OnvifDeleteAnalyticsModules(string uri, string userName, string password, string vacToken, string[] analytycModuleNames)
            : base(uri, userName, password)
        {
            VacToken = vacToken;
            AnalytycModuleNames = analytycModuleNames;
        }
    }
}
