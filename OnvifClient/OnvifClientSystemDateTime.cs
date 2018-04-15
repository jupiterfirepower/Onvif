using System.Threading.Tasks;
using Akka.Actor;
using onvif.services;
using Onvif.Camera.Client.Model;
using Onvif.Contracts.Messages.Onvif;
using Onvif.Contracts.Messages.Onvif.SystemDate;
using Onvif.Contracts.Model;

namespace Onvif.Camera.Client
{
    public partial class OnvifClient
    {
        public async Task<OnvifClientResult<SystemDateTime>> GetCameraSystemDateTimeAsync()
        {
            var result = await _proxyActor.Ask<Container<SystemDateTime>>(new OnvifGetSystemDateTime(_url, _userName, _password));
            return result.Success ? (OnvifClientResult<SystemDateTime>)new OnvifClientResultData<SystemDateTime>(result.WorkItem) :
                new OnvifClientResultEmpty<SystemDateTime>(new SystemDateTime());
        }

        public OnvifClientResult<SystemDateTime> GetCameraSystemDateTime()
        {
            return GetCameraSystemDateTime(_url, _userName, _password);
        }

        public OnvifClientResult<SystemDateTime> GetCameraSystemDateTime(string url, string userName, string password)
        {
            var result = _proxyActor.Ask<Container<SystemDateTime>>(new OnvifGetSystemDateTime(url, userName, password)).Result;
            return result.Success ? (OnvifClientResult<SystemDateTime>)new OnvifClientResultData<SystemDateTime>(result.WorkItem) :
                new OnvifClientResultEmpty<SystemDateTime>(new SystemDateTime());
        }

        public async Task<OnvifResult> SyncCameraSystemDateTimeWithNtpAsync()
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifSyncSystemDateTimeWithNtp(_url, _userName, _password));
        }

        public OnvifResult SyncCameraSystemDateTimeWithNtp()
        {
            return SyncCameraSystemDateTimeWithNtp(_url, _userName, _password);
        }

        public OnvifResult SyncCameraSystemDateTimeWithNtp(string url, string userName, string password)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifSyncSystemDateTimeWithNtp(url, userName, password)).Result;
        }

        public async Task<OnvifResult> SyncCameraSystemDateTimeWithLocalSystemAsync()
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifSyncWithSystem(_url, _userName, _password));
        }

        public OnvifResult SyncCameraSystemDateTimeWithLocalSystem()
        {
            return SyncCameraSystemDateTimeWithLocalSystem(_url, _userName, _password);
        }

        public OnvifResult SyncCameraSystemDateTimeWithLocalSystem(string url, string userName, string password)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifSyncWithSystem(url, userName, password)).Result;
        }
    }
}
