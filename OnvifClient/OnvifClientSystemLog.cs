using System.Threading.Tasks;
using Akka.Actor;
using onvif.services;
using Onvif.Camera.Client.Model;
using Onvif.Contracts.Messages.Onvif.SystemLog;
using Onvif.Contracts.Model;

namespace Onvif.Camera.Client
{
    public partial class OnvifClient
    {
        public async Task<OnvifClientResult<SystemLog>> GetSystemLogAsync(SystemLogType logType)
        {
            var result = await _proxyActor.Ask<Container<SystemLog>>(new OnvifGetSystemLog(_url, _userName, _password, logType));
            return result.Success ? (OnvifClientResult<SystemLog>)new OnvifClientResultData<SystemLog>(result.WorkItem) :
                new OnvifClientResultEmpty<SystemLog>(new SystemLog());
        }

        public OnvifClientResult<SystemLog> GetSystemLog(SystemLogType logType)
        {
            var result = _proxyActor.Ask<Container<SystemLog>>(new OnvifGetSystemLog(_url, _userName, _password, logType)).Result;
            return result.Success ? (OnvifClientResult<SystemLog>)new OnvifClientResultData<SystemLog>(result.WorkItem) :
                new OnvifClientResultEmpty<SystemLog>(new SystemLog());
        }

        public OnvifClientResult<SystemLog> GetSystemLog(string url, string userName, string password, SystemLogType logType)
        {
            var result = _proxyActor.Ask<Container<SystemLog>>(new OnvifGetSystemLog(url, userName, password, logType)).Result;
            return result.Success ? (OnvifClientResult<SystemLog>)new OnvifClientResultData<SystemLog>(result.WorkItem) :
                new OnvifClientResultEmpty<SystemLog>(new SystemLog());
        }

        public async Task<OnvifClientResult<SystemLogType[]>> GetSystemLogTypesAsync()
        {
            var result = await _proxyActor.Ask<Container<SystemLogType[]>>(new OnvifGetSystemLogTypes(_url, _userName, _password));
            return result.Success ? (OnvifClientResult<SystemLogType[]>)new OnvifClientResultData<SystemLogType[]>(result.WorkItem) :
                new OnvifClientResultEmpty<SystemLogType[]>(new[] { SystemLogType.access, SystemLogType.system });
        }

        public OnvifClientResult<SystemLogType[]> GetSystemLogTypes()
        {
            var result = _proxyActor.Ask<Container<SystemLogType[]>>(new OnvifGetSystemLogTypes(_url, _userName, _password)).Result;
            return result.Success ? (OnvifClientResult<SystemLogType[]>)new OnvifClientResultData<SystemLogType[]>(result.WorkItem) :
                new OnvifClientResultEmpty<SystemLogType[]>(new[] { SystemLogType.access, SystemLogType.system });
        }

        public OnvifClientResult<SystemLogType[]> GetSystemLogTypes(string url, string userName, string password)
        {
            var result = _proxyActor.Ask<Container<SystemLogType[]>>(new OnvifGetSystemLogTypes(url, userName, password)).Result;
            return result.Success ? (OnvifClientResult<SystemLogType[]>)new OnvifClientResultData<SystemLogType[]>(result.WorkItem) :
                new OnvifClientResultEmpty<SystemLogType[]>(new[] { SystemLogType.access, SystemLogType.system });
        }
    }
}
