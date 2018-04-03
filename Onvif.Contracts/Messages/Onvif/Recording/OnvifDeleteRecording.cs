namespace Onvif.Contracts.Messages.Onvif.Recording
{
    public class OnvifDeleteRecording : OnvifBase
    {
        public string RecordingToken { get; private set; }

        public OnvifDeleteRecording(string uri, string userName, string password, string recordingToken)
            : base(uri, userName, password)
        {
            RecordingToken = recordingToken;
        }
    }
}
