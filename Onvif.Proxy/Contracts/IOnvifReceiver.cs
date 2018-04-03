using System.Threading.Tasks;
using onvif.services;

namespace Onvif.Proxy.Contracts
{
    public interface IOnvifReceiver
    {
        Task<Receiver[]> GetReceivers();

        Task<Receiver> GetReceiver(string receiverToken);

        Task<Receiver> CreateReceiver(ReceiverConfiguration configuration);

        Task DeleteReceiver(string receiverToken);

        Task SetReceiverMode(string receiverToken, ReceiverMode receiverMode);

        Task<ReceiverStateInformation> GetReceiverState(string receiverToken);
    }
}
