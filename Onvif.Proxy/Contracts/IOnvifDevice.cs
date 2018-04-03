using System.Threading.Tasks;
using Onvif.Contracts.Model;

namespace Onvif.Proxy.Contracts
{
    public interface IOnvifDevice
    {
        Task<DeviceInfo> GetDeviceInformation();
        Task SetDeviceIdentification(DeviceInfo devInfo);

        Task SetDeviceName(string name);

        Task SetDeviceLocation(string location);

        Task SetNameLocation(string name, string location);
    }
}
