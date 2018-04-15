using onvif.services;
using Onvif.Camera.Client.Model;
using Onvif.Contracts.Messages.Onvif;

namespace Onvif.Camera.Client.Contracts
{
    public interface IOnvifClientProfilesSync
    {
        OnvifClientResult<Profile[]> GetProfiles();
        OnvifClientResult<Profile> GetProfile(string profileToken);
        OnvifClientResult<Profile> CreateProfile(string name, string token);
        OnvifResult DeleteProfile(string profileToken);

        OnvifClientResult<Profile[]> GetProfiles(string url, string userName, string password);
        OnvifClientResult<Profile> GetProfile(string url, string userName, string password, string profileToken);
        OnvifClientResult<Profile> CreateProfile(string url, string userName, string password, string name, string token);
        OnvifResult DeleteProfile(string url, string userName, string password, string profileToken);
    }
}
