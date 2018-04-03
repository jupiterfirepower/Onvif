namespace Onvif.Contracts.Messages.Onvif.Device
{
    public class OnvifSetDeviceLocation : OnvifBase
    {
        public string DeviceLocation { get; private set; }

        public OnvifSetDeviceLocation(string uri, string userName, string password, string deviceLocation)
            : base(uri, userName, password)
        {
            DeviceLocation = deviceLocation;
        }
    }
}
