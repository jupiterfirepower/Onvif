using onvif.services;
using Onvif.Camera.Client.Model;

namespace Onvif.Camera.Client.Contracts
{
    public interface IOnvifClientSystemLogSync
    {
        OnvifClientResult<SystemLog> GetSystemLog(SystemLogType logType);
        OnvifClientResult<SystemLogType[]> GetSystemLogTypes();

        OnvifClientResult<SystemLog> GetSystemLog(string url, string userName, string password, SystemLogType logType);
        OnvifClientResult<SystemLogType[]> GetSystemLogTypes(string url, string userName, string password);
    }
}
