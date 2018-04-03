namespace Onvif.Contracts.Messages.Onvif.Network
{
    public class OnvifSetZeroConfiguration : OnvifBase
    {
        public string ZeroConfInterfaceToken { get; private set; }
        public bool ZeroConfEnabled { get; private set; }

        public OnvifSetZeroConfiguration(string uri, string userName, string password, string zeroConfInterfaceToken, bool zeroConfEnabled)
            : base(uri, userName, password)
        {
            ZeroConfInterfaceToken = zeroConfInterfaceToken;
            ZeroConfEnabled = zeroConfEnabled;
        }
    }
}
