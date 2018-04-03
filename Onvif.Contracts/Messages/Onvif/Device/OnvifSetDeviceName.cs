namespace Onvif.Contracts.Messages.Onvif.Device
{
    public class OnvifSetDeviceName : OnvifBase
    {
        public string DeviceName { get; private set; }

        public OnvifSetDeviceName(string uri, string userName, string password, string deviceName)
            : base(uri, userName, password)
        {
            DeviceName = deviceName;
        }
    }
}
