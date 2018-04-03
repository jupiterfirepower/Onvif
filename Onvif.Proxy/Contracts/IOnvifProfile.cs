using System.Threading.Tasks;
using onvif.services;
using Onvif.Contracts.Model;

namespace Onvif.Proxy.Contracts
{
    public interface IOnvifProfile
    {
        Task<ProfileManagement> GetProfileManagement(string activeProfToken, string vsToken);
        Task<Profile[]> GetProfiles();
        Task<Profile> GetProfile(string profToken);
        Task<Profile> CreateProfile(string name, string token);
        
        Task DeleteProfile(string token);
    }
}
