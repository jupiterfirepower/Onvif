using System.Threading.Tasks;
using Onvif.Contracts.Model;

namespace Onvif.Proxy.Contracts.Contract
{
    public interface IOnvifDevice
    {
        Task<DeviceInfo> GetDeviceInformationAsync();

        Task SetDeviceIdentificationAsync(DeviceInfo devInfo);

        Task SetDeviceNameAsync(string name);

        Task SetDeviceLocationAsync(string location);

        Task SetNameLocationAsync(string name, string location);

        DeviceInfo GetDeviceInformation();

        void SetDeviceName(string name);
        void SetDeviceLocation(string location);
        void SetDeviceIdentification(DeviceInfo devInfo);
        void SetScopes(string[] scopes);
        Task SetScopesAsync(string[] scopes);
    }
}
