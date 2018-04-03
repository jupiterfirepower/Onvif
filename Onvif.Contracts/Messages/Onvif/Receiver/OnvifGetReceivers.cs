namespace Onvif.Contracts.Messages.Onvif.Receiver
{
    public class OnvifGetReceivers : OnvifBase
    {
        public OnvifGetReceivers(string uri, string userName, string password) : base(uri, userName, password)
        {
        }
    }
}
