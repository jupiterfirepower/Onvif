namespace Onvif.Contracts.Messages.Onvif.Receiver
{
    public class OnvifGetReceiver : OnvifBase
    {
        public string ReceiverToken { get; private set; }

        public OnvifGetReceiver(string uri, string userName, string password, string receiverToken)
            : base(uri, userName, password)
        {
            ReceiverToken = receiverToken;
        }
    }
}
