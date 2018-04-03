using System;

namespace Onvif.Contracts.Model
{
    [Serializable]
    public class CameraInfo
    {
        public int CameraId { get; set; }
        public int CustomerId { get; set; }
        public int HttpPort { get; set; }

        public string DeviceUserName { get; set; }

        public string DevicePassword { get; set; }

        public string CameraUrl { get; set; }

        public string MasterUrl { get; set; }

        public bool StreamMe { get; set; }

        public bool EnableMotionDetection { get; set; }

        public int MinMotionDuration { get; set; }

        public int MaxMotionDuration { get; set; }

        public byte[] RecordVersion { get; set; }

        public string DeviceBrand { get; set; }

        public string ModelNum { get; set; }


        public override string ToString()
        {
            return
                string.Format(
                    "customerId - {0}, cameraId - {1}, masterUrl - {2}, deviceUserName - {3}, devicePassword - {4}, streamMe - {5}, enableMotionDetection - {6}, deviceBrand - {7}, modelNum - {8}, minMotionDuration - {9}, maxMotionDuration - {10}, httpPort - {11}",
                    CustomerId, CameraId, MasterUrl ?? string.Empty, DeviceUserName ?? string.Empty, DevicePassword ?? string.Empty, StreamMe, EnableMotionDetection,
                    DeviceBrand ?? string.Empty, ModelNum ?? string.Empty, MinMotionDuration, MaxMotionDuration, HttpPort);
        }
    }
}
