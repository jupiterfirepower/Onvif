namespace Onvif.Contracts.Messages.Monitoring
{
    public class OnvifCameraErrorEvent : OnvifCameraBase
    {
        public OnvifCameraErrorEvent(string cameraId, string uri, string[] addreses, string serverAlias, Error err)
            : base(cameraId, uri, addreses, serverAlias, err)
        {
        }
    }
}
