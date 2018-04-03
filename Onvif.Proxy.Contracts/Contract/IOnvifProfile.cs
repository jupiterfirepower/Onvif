using System.Threading.Tasks;
using onvif.services;
using Onvif.Contracts.Model;

namespace Onvif.Proxy.Contracts.Contract
{
    public interface IOnvifProfile
    {
        Task<ProfileManagement> GetProfileManagementAsync(string activeProfToken, string vsToken);
        Task<Profile[]> GetProfilesAsync();
        Task<Profile> GetProfileAsync(string profToken);
        Task<Profile> CreateProfileAsync(string name, string token);
        Task DeleteProfileAsync(string token);

        ProfileManagement GetProfileManagement(string activeProfToken, string vsToken);
        Profile[] GetProfiles();
        Profile GetProfile(string profToken);
        Profile CreateProfile(string name, string token);
        void DeleteProfile(string token);
    }
}
