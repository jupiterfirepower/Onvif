namespace Onvif.Contracts.Messages.Onvif.Analytics
{
    public class OnvifGetVideoAnalyticsConfiguration : OnvifBase
    {
        public string ConfigurationToken { get; private set; }

        public OnvifGetVideoAnalyticsConfiguration(string uri, string userName, string password, string configurationToken)
            : base(uri, userName, password)
        {
            ConfigurationToken = configurationToken;
        }
    }
}
