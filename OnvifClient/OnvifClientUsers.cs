using System.Threading.Tasks;
using Akka.Actor;
using onvif.services;
using Onvif.Camera.Client.Model;
using Onvif.Contracts.Messages.Onvif;
using Onvif.Contracts.Messages.Onvif.Users;
using Onvif.Contracts.Model;

namespace Onvif.Camera.Client
{
    public partial class OnvifClient
    {
        public async Task<OnvifClientResult<User[]>> GetUsersAsync()
        {
            var result = await _proxyActor.Ask<Container<User[]>>(new OnvifGetUsers(_url, _userName, _password));
            return result.Success ? (OnvifClientResult<User[]>)new OnvifClientResultData<User[]>(result.WorkItem) :
                new OnvifClientResultEmpty<User[]>(new User[0]);
        }

        public OnvifClientResult<User[]> GetUsers()
        {
            return GetUsers(_url, _userName, _password);
        }

        public OnvifClientResult<User[]> GetUsers(string url, string userName, string password)
        {
            var result = _proxyActor.Ask<Container<User[]>>(new OnvifGetUsers(url, userName, password)).Result;
            return result.Success ? (OnvifClientResult<User[]>)new OnvifClientResultData<User[]>(result.WorkItem) :
                new OnvifClientResultEmpty<User[]>(new User[0]);
        }

        public async Task<OnvifResult> CreateUsersAsync(User[] users)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifCreateUsers(_url, _userName, _password, users));
        }

        public OnvifResult CreateUsers(User[] users)
        {
            return CreateUsers(_url, _userName, _password, users);
        }

        public OnvifResult CreateUsers(string url, string userName, string password, User[] users)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifCreateUsers(url, userName, password, users)).Result;
        }

        public async Task<OnvifResult> CreateUserAsync(User user)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifCreateUser(_url, _userName, _password, user));
        }

        public OnvifResult CreateUser(User user)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifCreateUser(_url, _userName, _password, user)).Result;
        }

        public OnvifResult CreateUser(string url, string userName, string password, User user)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifCreateUser(url, userName, password, user)).Result;
        }

        public async Task<OnvifResult> DeleteUsersAsync(string[] userNames)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifDeleteUsers(_url, _userName, _password, userNames));
        }

        public OnvifResult DeleteUsers(string[] userNames)
        {
            return DeleteUsers(_url, _userName, _password, userNames);
        }

        public OnvifResult DeleteUsers(string url, string userName, string password, string[] userNames)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifDeleteUsers(url, userName, password, userNames)).Result;
        }

        public async Task<OnvifResult> DeleteUserAsync(User user)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifDeleteUser(_url, _userName, _password, user));
        }

        public OnvifResult DeleteUser(User user)
        {
            return DeleteUser(_url, _userName, _password, user);
        }

        public OnvifResult DeleteUser(string url, string userName, string password, User user)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifDeleteUser(url, userName, password, user)).Result;
        }

        public async Task<OnvifResult> ModifyUserAsync(User user)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifModifyUser(_url, _userName, _password, user));
        }

        public OnvifResult ModifyUser(User user)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifModifyUser(_url, _userName, _password, user)).Result;
        }

        public OnvifResult ModifyUser(string url, string userName, string password, User user)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifModifyUser(url, userName, password, user)).Result;
        }
    }
}
