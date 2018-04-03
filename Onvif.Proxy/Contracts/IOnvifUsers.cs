using System.Threading.Tasks;
using onvif.services;

namespace Onvif.Proxy.Contracts
{
    public interface IOnvifUsers
    {
        Task<User[]> GetUsers();
        Task CreateUser(User user);
        Task DeleteUser(string[] userNames);
        Task DeleteUser(User user);
        Task ModifyUser(User user);
    }
}
