namespace Onvif.Contracts.Model
{
    public class DeviceInfo : ModelBase
    {
        public string FirmwareVersion { get; set;  }
        public string HardwareId { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public string Mac { get; set; }
        public string IpAddress { get; set; }

        public string OnvifVersion { get; set; }

        public string OriginName { get; set; }

        public string OriginLocation { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public DeviceInfo(): base(false)
        {
        }

        public DeviceInfo(bool result): base(result)
        {
        }
    }
}
