using System.Threading.Tasks;
using onvif.services;
using Onvif.Camera.Client.Model;

namespace Onvif.Camera.Client.Contracts
{
    public interface IOnvifClientSystemLogAsync
    {
        Task<OnvifClientResult<SystemLog>> GetSystemLogAsync(SystemLogType logType);
        Task<OnvifClientResult<SystemLogType[]>> GetSystemLogTypesAsync();
    }
}
