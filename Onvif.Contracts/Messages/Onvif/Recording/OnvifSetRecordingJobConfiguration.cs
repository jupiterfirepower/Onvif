using onvif.services;

namespace Onvif.Contracts.Messages.Onvif.Recording
{
    public class OnvifSetRecordingJobConfiguration : OnvifBase
    {
        public string JobToken { get; private set; }
        public RecordingJobConfiguration Config { get; private set; }

        public OnvifSetRecordingJobConfiguration(string uri, string userName, string password, string jobToken, RecordingJobConfiguration config)
            : base(uri, userName, password)
        {
            JobToken = jobToken;
            Config = config;
        }
    }
}
