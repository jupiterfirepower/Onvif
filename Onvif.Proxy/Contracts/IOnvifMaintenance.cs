using System.Threading.Tasks;
using onvif.services;

namespace Onvif.Proxy.Contracts
{
    public interface IOnvifMaintenance
    {
        Task<bool> Reset(FactoryDefaultType resetType);

        Task<bool> Reboot();
    }
}
