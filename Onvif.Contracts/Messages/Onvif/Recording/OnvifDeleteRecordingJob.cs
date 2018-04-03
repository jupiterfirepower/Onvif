namespace Onvif.Contracts.Messages.Onvif.Recording
{
    public class OnvifDeleteRecordingJob : OnvifBase
    {
        public string JobToken { get; private set; }

        public OnvifDeleteRecordingJob(string uri, string userName, string password, string jobToken)
            : base(uri, userName, password)
        {
            JobToken = jobToken;
        }
    }
}
