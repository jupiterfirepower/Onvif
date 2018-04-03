namespace Onvif.Contracts.Messages.Onvif.Receiver
{
    public class OnvifGetReceiverState : OnvifBase
    {
        public string ReceiverToken { get; private set; }

        public OnvifGetReceiverState(string uri, string userName, string password, string receiverToken)
            : base(uri, userName, password)
        {
            ReceiverToken = receiverToken;
        }
    }
}
