namespace Onvif.Contracts.Messages.Onvif.Analytics
{
    public class OnvifDeleteAnalyticsEngineInputs : OnvifBase
    {
        public string[] ConfigurationToken { get; private set; }

        public OnvifDeleteAnalyticsEngineInputs(string uri, string userName, string password, string[] configurationToken)
            : base(uri, userName, password)
        {
            ConfigurationToken = configurationToken;
        }
    }
}
