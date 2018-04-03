using onvif.services;

namespace Onvif.Contracts.Messages.Onvif.Analytics
{
    public class OnvifGetAnalyticsDeviceStreamUri : OnvifBase
    {
        public StreamSetup Setup { get; private set; }
        public string AnalyticsEngineControlToken { get; private set; }

        public OnvifGetAnalyticsDeviceStreamUri(string uri, string userName, string password, StreamSetup setup, string analyticsEngineControlToken)
            : base(uri, userName, password)
        {
            Setup = setup;
            AnalyticsEngineControlToken = analyticsEngineControlToken;
        }
    }
}
