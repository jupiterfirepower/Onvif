using System.Threading.Tasks;
using onvif.services;

namespace Onvif.Proxy.Contracts
{
    public interface IOnvifSystemLog
    {
        Task<SystemLogType[]> GetSystemLogTypes();
        Task<SystemLog> GetSystemLog(SystemLogType logType);
    }
}
