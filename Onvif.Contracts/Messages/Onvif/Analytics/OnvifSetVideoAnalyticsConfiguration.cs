using onvif.services;

namespace Onvif.Contracts.Messages.Onvif.Analytics
{
    public class OnvifSetVideoAnalyticsConfiguration : OnvifBase
    {
        public VideoAnalyticsConfiguration Configuration { get; private set; }
        public bool ForcePersitent { get; private set; }

        public OnvifSetVideoAnalyticsConfiguration(string uri, string userName, string password, VideoAnalyticsConfiguration configuration, bool forcePersitent)
            : base(uri, userName, password)
        {
            Configuration = configuration;
            ForcePersitent = forcePersitent;
        }
    }
}
