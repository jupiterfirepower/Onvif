using System.Threading.Tasks;
using onvif.services;
using Onvif.Camera.Client.Model;
using Onvif.Contracts.Messages.Onvif;

namespace Onvif.Camera.Client.Contracts
{
    public interface IOnvifClientProfilesAsync
    {
        Task<OnvifClientResult<Profile[]>> GetProfilesAsync();
        Task<OnvifClientResult<Profile>> GetProfileAsync(string profileToken);
        Task<OnvifClientResult<Profile>> CreateProfileAsync(string name, string token);
        Task<OnvifResult> DeleteProfileAsync(string name);
    }
}
