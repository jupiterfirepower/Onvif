using onvif.services;

namespace Onvif.Contracts.Messages.Onvif.Receiver
{
    public class OnvifSetReceiverMode : OnvifBase
    {
       public string ReceiverToken { get; private set; }
       public ReceiverMode ReceiverMode { get; private set; }

       public OnvifSetReceiverMode(string uri, string userName, string password, string receiverToken, ReceiverMode receiverMode)
           : base(uri, userName, password)
       {
           ReceiverToken = receiverToken;
           ReceiverMode = receiverMode;
       }
    }
}
