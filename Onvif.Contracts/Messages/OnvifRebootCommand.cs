using System;

namespace Onvif.Contracts.Messages
{
    public class OnvifRebootCommand
    {
        public int CameraId { get; private set; }
        public Guid Stamp { get; private set; }

        public OnvifRebootCommand(int cameraId, Guid stamp)
        {
            CameraId = cameraId;
            Stamp = stamp;
        }
    }
}
