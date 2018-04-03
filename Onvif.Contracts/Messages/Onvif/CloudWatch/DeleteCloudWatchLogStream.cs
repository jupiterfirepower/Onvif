namespace Onvif.Contracts.Messages.Onvif.CloudWatch
{
    public class DeleteCloudWatchLogStream : ICloudWatchLogMessage
    {
        public string CameraUri { get; private set; }
        public int CameraId { get; private set; }

        public DeleteCloudWatchLogStream(string cameraUri, int cameraId)
        {
            CameraUri = cameraUri;
            CameraId = cameraId;
        }
    }
}
