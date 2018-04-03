namespace Onvif.Contracts.Messages.Onvif.Recording
{
    public class OnvifGetRecordingJobState : OnvifBase
    {
        public string JobToken { get; private set; }

        public OnvifGetRecordingJobState(string uri, string userName, string password, string jobToken)
            : base(uri, userName, password)
        {
            JobToken = jobToken;
        }
    }
}
