using System.Threading.Tasks;
using onvif.services;
using Onvif.Camera.Client.Model;
using Onvif.Contracts.Messages.Onvif;

namespace Onvif.Camera.Client.Contracts
{
    public interface IOnvifClientReceiverAsync
    {
        Task<OnvifClientResult<Receiver[]>> GetReceiversAsync();
        Task<OnvifClientResult<Receiver>> GetReceiverAsync(string receiverToken);
        Task<OnvifClientResult<Receiver>> CreateReceiverAsync(ReceiverConfiguration configuration);
        Task<OnvifResult> DeleteReceiverAsync(string receiverToken);
        Task<OnvifResult> SetReceiverModeAsync(string receiverToken, ReceiverMode receiverMode);
        Task<OnvifClientResult<ReceiverStateInformation>> GetReceiverStateAsync(string receiverToken);

        
    }
}
