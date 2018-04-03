using onvif.services;

namespace Onvif.Contracts.Messages.Onvif.Analytics
{
    public class OnvifSetAnalyticsEngineInput : OnvifBase
    {
        public AnalyticsEngineInput Configuration { get; private set; }
        public bool ForcePersitent { get; private set; }

        public OnvifSetAnalyticsEngineInput(string uri, string userName, string password, AnalyticsEngineInput configuration, bool forcePersitent)
            : base(uri, userName, password)
        {
            Configuration = configuration;
            ForcePersitent = forcePersitent;
        }
    }
}
