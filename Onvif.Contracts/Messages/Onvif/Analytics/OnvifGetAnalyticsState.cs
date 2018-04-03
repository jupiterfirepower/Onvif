namespace Onvif.Contracts.Messages.Onvif.Analytics
{
    public class OnvifGetAnalyticsState : OnvifBase
    {
        public string AnalyticsEngineControlToken { get; private set; }

        public OnvifGetAnalyticsState(string uri, string userName, string password, string analyticsEngineControlToken)
            : base(uri, userName, password)
        {
            AnalyticsEngineControlToken = analyticsEngineControlToken;
        }
    }
}
