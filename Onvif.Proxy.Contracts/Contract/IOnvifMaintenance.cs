using System.Threading.Tasks;
using onvif.services;

namespace Onvif.Proxy.Contracts.Contract
{
    public interface IOnvifMaintenance
    {
        Task<bool> ResetAsync(FactoryDefaultType resetType);
        bool Reset(FactoryDefaultType resetType);

        Task<string> RebootAsync();
        string Reboot();
    }
}
