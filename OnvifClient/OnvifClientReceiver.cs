using System.Threading.Tasks;
using Akka.Actor;
using onvif.services;
using Onvif.Camera.Client.Model;
using Onvif.Contracts.Messages.Onvif;
using Onvif.Contracts.Messages.Onvif.Receiver;
using Onvif.Contracts.Model;

namespace Onvif.Camera.Client
{
    public partial class OnvifClient
    {
        public async Task<OnvifClientResult<Receiver[]>> GetReceiversAsync()
        {
            var result = await _proxyActor.Ask<Container<Receiver[]>>(new OnvifGetReceivers(_url, _userName, _password));
            return result.Success ? (OnvifClientResult<Receiver[]>)new OnvifClientResultData<Receiver[]>(result.WorkItem)
                : new OnvifClientResultEmpty<Receiver[]>(new Receiver[0]);
        }

        public OnvifClientResult<Receiver[]> GetReceivers()
        {
            return GetReceivers(_url, _userName, _password);
        }

        public OnvifClientResult<Receiver[]> GetReceivers(string url, string userName, string password)
        {
            var result = _proxyActor.Ask<Container<Receiver[]>>(new OnvifGetReceivers(url, userName, password)).Result;
            return result.Success ? (OnvifClientResult<Receiver[]>)new OnvifClientResultData<Receiver[]>(result.WorkItem)
                : new OnvifClientResultEmpty<Receiver[]>(new Receiver[0]);
        }

        public async Task<OnvifClientResult<Receiver>> GetReceiverAsync(string receiverToken)
        {
            var result = await _proxyActor.Ask<Container<Receiver>>(new OnvifGetReceiver(_url, _userName, _password, receiverToken));
            return result.Success ? (OnvifClientResult<Receiver>)new OnvifClientResultData<Receiver>(result.WorkItem)
                : new OnvifClientResultEmpty<Receiver>(new Receiver());
        }

        public OnvifClientResult<Receiver> GetReceiver(string receiverToken)
        {
            return GetReceiver(_url, _userName, _password, receiverToken);
        }

        public OnvifClientResult<Receiver> GetReceiver(string url, string userName, string password, string receiverToken)
        {
            var result = _proxyActor.Ask<Container<Receiver>>(new OnvifGetReceiver(url, userName, password, receiverToken)).Result;
            return result.Success ? (OnvifClientResult<Receiver>)new OnvifClientResultData<Receiver>(result.WorkItem)
                : new OnvifClientResultEmpty<Receiver>(new Receiver());
        }

        public async Task<OnvifClientResult<Receiver>> CreateReceiverAsync(ReceiverConfiguration configuration)
        {
            var result = await _proxyActor.Ask<Container<Receiver>>(new OnvifCreateReceiver(_url, _userName, _password, configuration));
            return result.Success ? (OnvifClientResult<Receiver>)new OnvifClientResultData<Receiver>(result.WorkItem)
                : new OnvifClientResultEmpty<Receiver>(new Receiver());
        }

        public OnvifClientResult<Receiver> CreateReceiver(ReceiverConfiguration configuration)
        {
            return CreateReceiver(_url, _userName, _password, configuration);
        }

        public OnvifClientResult<Receiver> CreateReceiver(string url, string userName, string password, ReceiverConfiguration configuration)
        {
            var result = _proxyActor.Ask<Container<Receiver>>(new OnvifCreateReceiver(url, userName, password, configuration)).Result;
            return result.Success ? (OnvifClientResult<Receiver>)new OnvifClientResultData<Receiver>(result.WorkItem)
                : new OnvifClientResultEmpty<Receiver>(new Receiver());
        }

        public async Task<OnvifResult> DeleteReceiverAsync(string receiverToken)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifDeleteReceiver(_url, _userName, _password, receiverToken));
        }

        public OnvifResult DeleteReceiver(string receiverToken)
        {
            return DeleteReceiver(_url, _userName, _password, receiverToken);
        }

        public OnvifResult DeleteReceiver(string url, string userName, string password, string receiverToken)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifDeleteReceiver(url, userName, password, receiverToken)).Result;
        }

        public async Task<OnvifResult> SetReceiverModeAsync(string receiverToken, ReceiverMode receiverMode)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifSetReceiverMode(_url, _userName, _password, receiverToken, receiverMode));
        }

        public OnvifResult SetReceiverMode(string receiverToken, ReceiverMode receiverMode)
        {
            return SetReceiverMode(_url, _userName, _password, receiverToken, receiverMode);
        }

        public OnvifResult SetReceiverMode(string url, string userName, string password, string receiverToken, ReceiverMode receiverMode)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifSetReceiverMode(url, userName, password, receiverToken, receiverMode)).Result;
        }

        public async Task<OnvifClientResult<ReceiverStateInformation>> GetReceiverStateAsync(string receiverToken)
        {
            var result = await _proxyActor.Ask<Container<ReceiverStateInformation>>(new OnvifGetReceiverState(_url, _userName, _password, receiverToken));
            return result.Success ? (OnvifClientResult<ReceiverStateInformation>)new OnvifClientResultData<ReceiverStateInformation>(result.WorkItem)
                : new OnvifClientResultEmpty<ReceiverStateInformation>(new ReceiverStateInformation());
        }

        public OnvifClientResult<ReceiverStateInformation> GetReceiverState(string receiverToken)
        {
            return GetReceiverState(_url, _userName, _password, receiverToken);
        }

        public OnvifClientResult<ReceiverStateInformation> GetReceiverState(string url, string userName, string password, string receiverToken)
        {
            var result = _proxyActor.Ask<Container<ReceiverStateInformation>>(new OnvifGetReceiverState(url, userName, password, receiverToken)).Result;
            return result.Success ? (OnvifClientResult<ReceiverStateInformation>)new OnvifClientResultData<ReceiverStateInformation>(result.WorkItem)
                : new OnvifClientResultEmpty<ReceiverStateInformation>(new ReceiverStateInformation());
        }
    }
}
