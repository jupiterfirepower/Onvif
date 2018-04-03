using onvif.services;

namespace Onvif.Contracts.Messages.Onvif.Analytics
{
    public class OnvifCreateAnalyticsEngineInputs : OnvifBase
    {
        public AnalyticsEngineInput[] Configuration { get; private set; }
        public bool[] ForcePersistent { get; private set; }

        public OnvifCreateAnalyticsEngineInputs(string uri, string userName, string password, AnalyticsEngineInput[] configuration, bool[] forcePersistent)
            : base(uri, userName, password)
        {
            Configuration = configuration;
            ForcePersistent = forcePersistent;
        }
    }
}
