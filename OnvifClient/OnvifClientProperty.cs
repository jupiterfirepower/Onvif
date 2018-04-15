using System.Threading.Tasks;
using Akka.Actor;
using Onvif.Camera.Client.Model;
using Onvif.Contracts.Messages.Onvif;
using Onvif.Contracts.Model;

namespace Onvif.Camera.Client
{
    public partial class OnvifClient
    {
        public async Task<OnvifClientResult<bool>> IsAnalyticsSupportedAsync()
        {
            var result = await _proxyActor.Ask<Container<bool>>(new OnvifGetIsAnalyticsSupported(_url, _userName, _password));
            return result.Success ? (OnvifClientResult<bool>)new OnvifClientResultData<bool>(result.WorkItem)
                : new OnvifClientResultEmpty<bool>(false);
        }

        public OnvifClientResult<bool> IsAnalyticsSupported()
        {
            return IsAnalyticsSupported(_url, _userName, _password);
        }

        public OnvifClientResult<bool> IsAnalyticsSupported(string url, string userName, string password)
        {
            var result = _proxyActor.Ask<Container<bool>>(new OnvifGetIsAnalyticsSupported(_url, _userName, _password)).Result;
            return result.Success ? (OnvifClientResult<bool>)new OnvifClientResultData<bool>(result.WorkItem)
                : new OnvifClientResultEmpty<bool>(false);
        }

        public async Task<OnvifClientResult<bool>> IsEventsSupportedAsync()
        {
            var result = await _proxyActor.Ask<Container<bool>>(new OnvifGetIsEventsSupported(_url, _userName, _password));
            return result.Success ? (OnvifClientResult<bool>)new OnvifClientResultData<bool>(result.WorkItem)
                : new OnvifClientResultEmpty<bool>(false);
        }

        public OnvifClientResult<bool> IsEventsSupported()
        {
            return IsEventsSupported(_url, _userName, _password);
        }

        public OnvifClientResult<bool> IsEventsSupported(string url, string userName, string password)
        {
            var result = _proxyActor.Ask<Container<bool>>(new OnvifGetIsEventsSupported(url, userName, password)).Result;
            return result.Success ? (OnvifClientResult<bool>)new OnvifClientResultData<bool>(result.WorkItem)
                : new OnvifClientResultEmpty<bool>(false);
        }

        public async Task<OnvifClientResult<bool>> IsFirmwareUpgradeSupportedAsync()
        {
            var result = await _proxyActor.Ask<Container<bool>>(new OnvifGetIsFirmwareUpgradeSupported(_url, _userName, _password));
            return result.Success ? (OnvifClientResult<bool>)new OnvifClientResultData<bool>(result.WorkItem)
                : new OnvifClientResultEmpty<bool>(false);
        }

        public OnvifClientResult<bool> IsFirmwareUpgradeSupported()
        {
            return IsFirmwareUpgradeSupported(_url, _userName, _password);
        }

        public OnvifClientResult<bool> IsFirmwareUpgradeSupported(string url, string userName, string password)
        {
            var result = _proxyActor.Ask<Container<bool>>(new OnvifGetIsFirmwareUpgradeSupported(url, userName, password)).Result;
            return result.Success ? (OnvifClientResult<bool>)new OnvifClientResultData<bool>(result.WorkItem)
                : new OnvifClientResultEmpty<bool>(false);
        }

        public async Task<OnvifClientResult<bool>> IsPtzSupportedAsync()
        {
            var result = await _proxyActor.Ask<Container<bool>>(new OnvifGetIsPtzSupported(_url, _userName, _password));
            return result.Success ? (OnvifClientResult<bool>)new OnvifClientResultData<bool>(result.WorkItem)
                : new OnvifClientResultEmpty<bool>(false);
        }

        public OnvifClientResult<bool> IsPtzSupported()
        {
            return IsPtzSupported(_url, _userName, _password);
        }

        public OnvifClientResult<bool> IsPtzSupported(string url, string userName, string password)
        {
            var result = _proxyActor.Ask<Container<bool>>(new OnvifGetIsPtzSupported(url, userName, password)).Result;
            return result.Success ? (OnvifClientResult<bool>)new OnvifClientResultData<bool>(result.WorkItem)
                : new OnvifClientResultEmpty<bool>(false);
        }

        public async Task<OnvifClientResult<bool>> IsZeroConfigurationSupportedAsync()
        {
            var result = await _proxyActor.Ask<Container<bool>>(new OnvifGetIsZeroConfigurationSupported(_url, _userName, _password));
            return result.Success ? (OnvifClientResult<bool>)new OnvifClientResultData<bool>(result.WorkItem)
                : new OnvifClientResultEmpty<bool>(false);
        }

        public OnvifClientResult<bool> IsZeroConfigurationSupported()
        {
            return IsZeroConfigurationSupported(_url, _userName, _password);
        }

        public OnvifClientResult<bool> IsZeroConfigurationSupported(string url, string userName, string password)
        {
            var result = _proxyActor.Ask<Container<bool>>(new OnvifGetIsZeroConfigurationSupported(url, userName, password)).Result;
            return result.Success ? (OnvifClientResult<bool>)new OnvifClientResultData<bool>(result.WorkItem)
                : new OnvifClientResultEmpty<bool>(false);
        }
    }
}
