using Onvif.Contracts.Enums;

namespace Onvif.Contracts.Messages.Onvif.CloudWatch
{
    public class CloudWatchLogMessage : ICloudWatchLogMessage
    {
        public string CameraUri { get; private set; }
        public int CameraId { get; private set; }

        public string LogMessage { get; private set; }

        public MetricNames MetricName { get; private set; }

        public CloudWatchLogMessage(string cameraUri, string logMessage, int cameraId = -1, MetricNames metricName = MetricNames.Unknown)
        {
            CameraUri = cameraUri;
            LogMessage = logMessage;
            CameraId = cameraId;
            MetricName = metricName;
        }

        public void SetLogMessage(string logMessage)
        {
            LogMessage = logMessage;
        }

        public override string ToString()
        {
            return string.Format("CameraId - {0}, CameraUri - {1}, MetricName - {2}, LogMessage - {3} ", CameraId,
                CameraUri, MetricName, LogMessage);
        }

        public string KeyForDictionary
        {
            get { return string.Format("{0}-{1}", MetricName, CameraUri); }
        }
    }
}
