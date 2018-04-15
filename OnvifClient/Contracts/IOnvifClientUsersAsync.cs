using System.Threading.Tasks;
using onvif.services;
using Onvif.Camera.Client.Model;
using Onvif.Contracts.Messages.Onvif;

namespace Onvif.Camera.Client.Contracts
{
    public interface IOnvifClientUsersAsync
    {
        Task<OnvifClientResult<User[]>> GetUsersAsync();
        Task<OnvifResult> CreateUsersAsync(User[] users);
        Task<OnvifResult> CreateUserAsync(User user);
        Task<OnvifResult> DeleteUsersAsync(string[] userNames);
        Task<OnvifResult> DeleteUserAsync(User user);
        Task<OnvifResult> ModifyUserAsync(User user);
    }
}
