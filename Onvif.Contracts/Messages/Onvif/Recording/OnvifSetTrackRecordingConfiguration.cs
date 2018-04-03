using onvif.services;

namespace Onvif.Contracts.Messages.Onvif.Recording
{
    public class OnvifSetTrackRecordingConfiguration : OnvifBase
    {
        public string RecordingToken { get; private set; }
        public TrackConfiguration TrackConfiguration { get; private set; }

        public OnvifSetTrackRecordingConfiguration(string uri, string userName, string password, string recordingToken, TrackConfiguration trackConfiguration)
            : base(uri, userName, password)
        {
            RecordingToken = recordingToken;
            TrackConfiguration = trackConfiguration;
        }
    }
}
