using Onvif.Contracts.Model;

namespace Onvif.Contracts.Messages.Onvif.Device
{
    public class OnvifSetDeviceIdentification : OnvifBase
    {
        public DeviceInfo Identification { get; private set; }

        public OnvifSetDeviceIdentification(string uri, string userName, string password, DeviceInfo identification)
            : base(uri, userName, password)
        {
            Identification = identification;
        }
    }
}
