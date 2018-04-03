namespace Onvif.Contracts.Messages.Onvif.Analytics
{
    public class OnvifGetAnalyticsEngineControl : OnvifBase
    {
        public string ConfigurationToken { get; private set; }

        public OnvifGetAnalyticsEngineControl(string uri, string userName, string password, string configurationToken)
            : base(uri, userName, password)
        {
            ConfigurationToken = configurationToken;
        }
    }
}
