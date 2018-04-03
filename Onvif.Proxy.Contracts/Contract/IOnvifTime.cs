using System.Threading.Tasks;
using onvif.services;

namespace Onvif.Proxy.Contracts.Contract
{
    public interface IOnvifTime
    {
        Task<SystemDateTime> GetSystemDateTimeAsync();
        Task SyncWithSystemAsync();
        Task SyncWithNtpAsync();
        Task SetManualAsync(System.DateTime utcDateTime);

        SystemDateTime GetSystemDateTime();
        void SyncWithSystem();
        void SyncWithNtp();
        void SetManual(System.DateTime utcDateTime);
    }
}
