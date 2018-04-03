namespace Onvif.Contracts.Messages.Onvif.Recording
{
    public class OnvifGetRecordingConfiguration : OnvifBase
    {
        public string RecordingToken { get; private set; }

        public OnvifGetRecordingConfiguration(string uri, string userName, string password, string recordingToken)
            : base(uri, userName, password)
        {
            RecordingToken = recordingToken;
        }
    }
}
