namespace Onvif.Contracts.Messages.Onvif.Recording
{
    public class OnvifGetRecordingJobs : OnvifBase
    {
        public OnvifGetRecordingJobs(string uri, string userName, string password) : base(uri, userName, password)
        {
        }
    }
}
