namespace Onvif.Contracts.Messages.Onvif.Events
{
    public class EnableMotionEvents : OnvifBase
    {
        public string Manufacturer { get; private set; }

        public EnableMotionEvents(string uri, string userName, string password,string manufacturer) : base(uri, userName, password)
        {
            Manufacturer = manufacturer;
        }
    }
}
