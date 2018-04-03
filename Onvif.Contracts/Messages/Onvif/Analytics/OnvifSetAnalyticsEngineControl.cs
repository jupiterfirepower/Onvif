using onvif.services;

namespace Onvif.Contracts.Messages.Onvif.Analytics
{
    public class OnvifSetAnalyticsEngineControl : OnvifBase
    {
        public AnalyticsEngineControl Configuration { get; private set; }
        public bool ForcePersitent { get; private set; }

        public OnvifSetAnalyticsEngineControl(string uri, string userName, string password, AnalyticsEngineControl configuration, bool forcePersitent)
            : base(uri, userName, password)
        {
            Configuration = configuration;
            ForcePersitent = forcePersitent;
        }
    }
}
