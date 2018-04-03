using System;

namespace Onvif.Contracts.Messages
{
    public class UnSubscribeEventsForProcessing : IHashKey
    {
        /// <summary>
        /// Uri on camera
        /// </summary>
        public string Uri { get; private set; }
        public int HashCode { get{ return !string.IsNullOrEmpty(Uri) ? Uri.GetHashCode() : 0; } }
        public Guid Stamp { get; private set; }
        public string SecurityToken { get; set; }

        public UnSubscribeEventsForProcessing(string onvifCameraUri, int cameraId, Guid stamp)
        {
            Uri = onvifCameraUri;
            CameraId = cameraId;
            Stamp = stamp;
        }

        public int CameraId { get; private set; }

        public override string ToString()
        {
            return string.Format("CameraUri - {0}, CameraId - {1}", Uri, CameraId);
        }

        public string Key { get { return Convert.ToString(CameraId); } }
    }
}
