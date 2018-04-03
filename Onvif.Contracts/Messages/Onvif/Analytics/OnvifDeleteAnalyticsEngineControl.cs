namespace Onvif.Contracts.Messages.Onvif.Analytics
{
    public class OnvifDeleteAnalyticsEngineControl : OnvifBase
    {
        public string ConfigurationToken { get; private set; }

        public OnvifDeleteAnalyticsEngineControl(string uri, string userName, string password, string configurationToken)
            : base(uri, userName, password)
        {
            ConfigurationToken = configurationToken;
        }
    }
}
