using onvif.services;
using Onvif.Camera.Client.Model;
using Onvif.Contracts.Messages.Onvif;

namespace Onvif.Camera.Client.Contracts
{
    public interface IOnvifClientReceiverSync
    {
        OnvifClientResult<Receiver[]> GetReceivers();
        OnvifClientResult<Receiver> GetReceiver(string receiverToken);
        OnvifClientResult<Receiver> CreateReceiver(ReceiverConfiguration configuration);
        OnvifResult DeleteReceiver(string receiverToken);
        OnvifResult SetReceiverMode(string receiverToken, ReceiverMode receiverMode);
        OnvifClientResult<ReceiverStateInformation> GetReceiverState(string receiverToken);

        OnvifClientResult<Receiver[]> GetReceivers(string url, string userName, string password);
        OnvifClientResult<Receiver> GetReceiver(string url, string userName, string password, string receiverToken);
        OnvifClientResult<Receiver> CreateReceiver(string url, string userName, string password, ReceiverConfiguration configuration);
        OnvifResult DeleteReceiver(string url, string userName, string password, string receiverToken);
        OnvifResult SetReceiverMode(string url, string userName, string password, string receiverToken, ReceiverMode receiverMode);
        OnvifClientResult<ReceiverStateInformation> GetReceiverState(string url, string userName, string password, string receiverToken);
    }
}
