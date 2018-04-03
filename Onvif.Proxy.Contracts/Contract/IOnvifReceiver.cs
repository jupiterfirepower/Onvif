using System.Threading.Tasks;
using onvif.services;

namespace Onvif.Proxy.Contracts.Contract
{
    public interface IOnvifReceiver
    {
        Task<Receiver[]> GetReceiversAsync();

        Task<Receiver> GetReceiverAsync(string receiverToken);

        Task<Receiver> CreateReceiverAsync(ReceiverConfiguration configuration);

        Task DeleteReceiverAsync(string receiverToken);

        Task SetReceiverModeAsync(string receiverToken, ReceiverMode receiverMode);

        Task<ReceiverStateInformation> GetReceiverStateAsync(string receiverToken);

        Receiver[] GetReceivers();
        Receiver GetReceiver(string receiverToken);
        Receiver CreateReceiver(ReceiverConfiguration configuration);
        void DeleteReceiver(string receiverToken);
        void SetReceiverMode(string receiverToken, ReceiverMode receiverMode);
        ReceiverStateInformation GetReceiverState(string receiverToken);
    }
}
