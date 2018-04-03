namespace Onvif.Contracts.Messages.Monitoring
{
    public abstract class OnvifCameraBase
    {
        public string CameraId { get; private set; }
        public string Uri { get; private set; }

        public string[] Addreses { get; private set; }

        public string ServerAlias { get; private set; }

        public Error Err { get; private set; }

        protected OnvifCameraBase(string cameraId, string uri, string[] addreses, string serverAlias, Error err)
        {
            CameraId = cameraId;
            Uri = uri;
            Addreses = addreses;
            ServerAlias = serverAlias;
            Err = err;
        }
    }
}
