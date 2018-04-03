using onvif.services;

namespace Onvif.Contracts.Messages.Onvif.Recording
{
    public class OnvifSetRecordingConfiguration : OnvifBase
    {
        public string RecordingToken { get; private set; }
        public RecordingConfiguration Configuration { get; private set; }

        public OnvifSetRecordingConfiguration(string uri, string userName, string password, string recordingToken, RecordingConfiguration configuration)
            : base(uri, userName, password)
        {
            RecordingToken = recordingToken;
            Configuration = configuration;
        }
    }
}
