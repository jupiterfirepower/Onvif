namespace Onvif.Contracts.Messages.Onvif
{
    public class OnvifGetIsFirmwareUpgradeSupported : OnvifBase
    {
        public OnvifGetIsFirmwareUpgradeSupported(string uri, string userName, string password) : base(uri, userName, password)
        {
        }
    }
}
