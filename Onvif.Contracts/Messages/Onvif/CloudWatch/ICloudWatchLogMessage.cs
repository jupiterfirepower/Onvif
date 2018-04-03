namespace Onvif.Contracts.Messages.Onvif.CloudWatch
{
    public interface ICloudWatchLogMessage
    {
        string CameraUri { get; }
        int CameraId { get; }
    }
}
