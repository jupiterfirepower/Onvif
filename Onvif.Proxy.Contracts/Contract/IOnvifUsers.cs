using System.Threading.Tasks;
using onvif.services;

namespace Onvif.Proxy.Contracts.Contract
{
    public interface IOnvifUsers
    {
        Task<User[]> GetUsersAsync();
        Task CreateUserAsync(User user);
        Task DeleteUserAsync(string[] userNames);
        Task DeleteUserAsync(User user);
        Task ModifyUserAsync(User user);

        User[] GetUsers();
        void CreateUsers(User[] users);
        void CreateUser(User user);
        void DeleteUser(string[] userNames);
        void DeleteUser(User user);
        void ModifyUser(User user);
    }
}
