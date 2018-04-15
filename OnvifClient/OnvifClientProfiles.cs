using System.Threading.Tasks;
using Akka.Actor;
using onvif.services;
using Onvif.Camera.Client.Model;
using Onvif.Contracts.Messages.Onvif;
using Onvif.Contracts.Messages.Onvif.Profiles;
using Onvif.Contracts.Model;

namespace Onvif.Camera.Client
{
    public partial class OnvifClient
    {
        public async Task<OnvifClientResult<Profile[]>> GetProfilesAsync()
        {
            var result = await _proxyActor.Ask<Container<Profile[]>>(new OnvifGetProfiles(_url, _userName, _password));
            return result.Success ? (OnvifClientResult<Profile[]>)new OnvifClientResultData<Profile[]>(result.WorkItem) :
                new OnvifClientResultEmpty<Profile[]>(new Profile[0]);
        }

        public OnvifClientResult<Profile[]> GetProfiles()
        {
            return GetProfiles(_url, _userName, _password);
        }

        public OnvifClientResult<Profile[]> GetProfiles(string url, string userName, string password)
        {
            var result = _proxyActor.Ask<Container<Profile[]>>(new OnvifGetProfiles(url, userName, password)).Result;
            return result.Success ? (OnvifClientResult<Profile[]>)new OnvifClientResultData<Profile[]>(result.WorkItem) :
                new OnvifClientResultEmpty<Profile[]>(new Profile[0]);
        }

        public async Task<OnvifClientResult<Profile>> GetProfileAsync(string profileToken)
        {
            var result = await _proxyActor.Ask<Container<Profile>>(new OnvifGetProfile(_url, _userName, _password, profileToken));
            return result.Success ? (OnvifClientResult<Profile>)new OnvifClientResultData<Profile>(result.WorkItem) :
                new OnvifClientResultEmpty<Profile>(new Profile());
        }

        public OnvifClientResult<Profile> GetProfile(string profileToken)
        {
            return GetProfile(_url, _userName, _password, profileToken);
        }

        public OnvifClientResult<Profile> GetProfile(string url, string userName, string password, string profileToken)
        {
            var result = _proxyActor.Ask<Container<Profile>>(new OnvifGetProfile(url, userName, password, profileToken)).Result;
            return result.Success ? (OnvifClientResult<Profile>)new OnvifClientResultData<Profile>(result.WorkItem) :
                new OnvifClientResultEmpty<Profile>(new Profile());
        }

        public async Task<OnvifClientResult<Profile>> CreateProfileAsync(string name, string token)
        {
            var result = await _proxyActor.Ask<Container<Profile>>(new OnvifCreateProfile(_url, _userName, _password, name, token));
            return result.Success ? (OnvifClientResult<Profile>)new OnvifClientResultData<Profile>(result.WorkItem) :
                new OnvifClientResultEmpty<Profile>(new Profile());
        }

        public OnvifClientResult<Profile> CreateProfile(string name, string token)
        {
            return CreateProfile(_url, _userName, _password, name, token);
        }

        public OnvifClientResult<Profile> CreateProfile(string url, string userName, string password, string name, string token)
        {
            var result = _proxyActor.Ask<Container<Profile>>(new OnvifCreateProfile(url, userName, password, name, token)).Result;
            return result.Success ? (OnvifClientResult<Profile>)new OnvifClientResultData<Profile>(result.WorkItem) :
                new OnvifClientResultEmpty<Profile>(new Profile());
        }

        public async Task<OnvifResult> DeleteProfileAsync(string profileToken)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifDeleteProfile(_url, _userName, _password, profileToken));
        }

        public OnvifResult DeleteProfile(string profileToken)
        {
            return DeleteProfile(_url, _userName, _password, profileToken);
        }

        public OnvifResult DeleteProfile(string url, string userName, string password, string profileToken)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifDeleteProfile(url, userName, password, profileToken)).Result;
        }
    }
}
