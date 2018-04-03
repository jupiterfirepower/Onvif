namespace Onvif.Contracts.Messages.Onvif.Recording
{
    public class OnvifGetRecordingJobConfiguration : OnvifBase
    {
        public string JobToken { get; private set; }

        public OnvifGetRecordingJobConfiguration(string uri, string userName, string password, string jobToken)
            : base(uri, userName, password)
        {
            JobToken = jobToken;
        }
    }
}
