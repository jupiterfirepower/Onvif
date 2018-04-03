using onvif.services;

namespace Onvif.Contracts.Messages.Onvif.Recording
{
    public class OnvifSetTrackConfiguration : OnvifBase
    {
        public string RecordingToken { get; private set; }
        public string TrackToken { get; private set; }
        public TrackConfiguration Config { get; private set; }

        public OnvifSetTrackConfiguration(string uri, string userName, string password, string recordingToken, string trackToken, TrackConfiguration config)
            : base(uri, userName, password)
        {
            RecordingToken = recordingToken;
            TrackToken = trackToken;
            Config = config;
        }
    }
}
