using onvif.services;
using Onvif.Camera.Client.Model;
using Onvif.Contracts.Messages.Onvif;

namespace Onvif.Camera.Client.Contracts
{
    public interface IOnvifClientUsersSync
    {
        OnvifClientResult<User[]> GetUsers();
        OnvifResult CreateUsers(User[] users);
        OnvifResult CreateUser(User user);
        OnvifResult DeleteUsers(string[] userNames);
        OnvifResult DeleteUser(User user);
        OnvifResult ModifyUser(User user);

        OnvifClientResult<User[]> GetUsers(string url, string userName, string password);
        OnvifResult CreateUsers(string url, string userName, string password, User[] users);
        OnvifResult CreateUser(string url, string userName, string password, User user);
        OnvifResult DeleteUsers(string url, string userName, string password, string[] userNames);
        OnvifResult DeleteUser(string url, string userName, string password, User user);
        OnvifResult ModifyUser(string url, string userName, string password, User user);
    }
}
