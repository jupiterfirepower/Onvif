using System.Threading.Tasks;
using onvif.services;

namespace Onvif.Proxy.Contracts.Contract
{
    public interface IOnvifSystemLog
    {
        Task<SystemLogType[]> GetSystemLogTypesAsync();
        Task<SystemLog> GetSystemLogAsync(SystemLogType logType);

        SystemLogType[] GetSystemLogTypes();
        SystemLog GetSystemLog(SystemLogType logType);
    }
}
