using onvif.services;

namespace Onvif.Contracts.Messages.Onvif.Recording
{
    public class OnvifCreateRecording : OnvifBase
    {
        public RecordingConfiguration Configuration { get; private set; }

        public OnvifCreateRecording(string uri, string userName, string password, RecordingConfiguration configuration)
            : base(uri, userName, password)
        {
            Configuration = configuration;
        }
    }
}
