namespace Onvif.Contracts.Messages.Onvif.Analytics
{
    public class OnvifGetAnalyticsEngine : OnvifBase
    {
        public string ConfigurationToken { get; private set; }

        public OnvifGetAnalyticsEngine(string uri, string userName, string password, string configurationToken)
            : base(uri, userName, password)
        {
            ConfigurationToken = configurationToken;
        }
    }
}
