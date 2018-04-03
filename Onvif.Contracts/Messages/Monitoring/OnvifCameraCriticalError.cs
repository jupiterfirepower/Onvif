namespace Onvif.Contracts.Messages.Monitoring
{
    public class OnvifCameraCriticalError : OnvifCameraBase
    {
        public OnvifCameraCriticalError(string cameraId, string uri, string[] addreses, string serverAlias, Error err) : 
            base(cameraId, uri, addreses, serverAlias, err)
        {
        }
    }
}
