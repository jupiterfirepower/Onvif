using onvif.services;

namespace Onvif.Contracts.Messages.Onvif.Recording
{
    public class OnvifCreateRecordingJob : OnvifBase
    {
        public RecordingJobConfiguration Config { get; private set; }

        public OnvifCreateRecordingJob(string uri, string userName, string password,RecordingJobConfiguration config) : base(uri, userName, password)
        {
            Config = config;
        }
    }
}
