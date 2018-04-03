namespace Onvif.Contracts.Messages.Onvif.Receiver
{
    public class OnvifDeleteReceiver : OnvifBase
    {
        public string ReceiverToken { get; private set; }

        public OnvifDeleteReceiver(string uri, string userName, string password, string receiverToken)
            : base(uri, userName, password)
        {
            ReceiverToken = receiverToken;
        }
    }
}
