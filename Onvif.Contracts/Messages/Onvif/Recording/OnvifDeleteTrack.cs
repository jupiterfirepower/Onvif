namespace Onvif.Contracts.Messages.Onvif.Recording
{
    public class OnvifDeleteTrack : OnvifBase
    {
        public string RecordingToken { get; private set; }
        public string TrackToken { get; private set; }

        public OnvifDeleteTrack(string uri, string userName, string password, string recordingToken, string trackToken)
            : base(uri, userName, password)
        {
            RecordingToken = recordingToken;
            TrackToken = trackToken;
        }
    }
}
