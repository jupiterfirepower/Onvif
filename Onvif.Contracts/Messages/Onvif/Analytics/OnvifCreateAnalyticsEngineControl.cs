using onvif.services;

namespace Onvif.Contracts.Messages.Onvif.Analytics
{
    public class OnvifCreateAnalyticsEngineControl : OnvifBase
    {
        public AnalyticsEngineControl Configuration { get; private set; }

        public OnvifCreateAnalyticsEngineControl(string uri, string userName, string password, AnalyticsEngineControl config)
            : base(uri, userName, password)
        {
            Configuration = config;
        }
    }
}
