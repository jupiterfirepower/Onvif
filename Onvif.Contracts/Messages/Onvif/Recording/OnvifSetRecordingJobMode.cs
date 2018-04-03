namespace Onvif.Contracts.Messages.Onvif.Recording
{
    public class OnvifSetRecordingJobMode : OnvifBase
    {
        public string JobToken { get; set; }
        public string Mode { get; set; }

        public OnvifSetRecordingJobMode(string uri, string userName, string password, string jobToken, string mode)
            : base(uri, userName, password)
        {
            JobToken = jobToken;
            Mode = mode;
        }
    }
}
