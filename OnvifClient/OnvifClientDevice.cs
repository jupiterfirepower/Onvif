using System;
using System.Threading.Tasks;
using Akka.Actor;
using onvif.services;
using Onvif.Camera.Client.Model;
using Onvif.Contracts.Messages;
using Onvif.Contracts.Messages.Onvif;
using Onvif.Contracts.Messages.Onvif.Control;
using Onvif.Contracts.Messages.Onvif.Device;
using Onvif.Contracts.Model;

namespace Onvif.Camera.Client
{
    public partial class OnvifClient
    {
        public async Task<OnvifResult> ResetAsync(FactoryDefaultType resetType)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifCameraReset(_url, _userName, _password, resetType));
        }

        public OnvifResult Reset(FactoryDefaultType resetType)
        {
            return Reset(_url, _userName, _password, resetType);
        }

        public OnvifResult Reset(string url, string userName, string password, FactoryDefaultType resetType)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifCameraReset(url, userName, password, resetType)).Result;
        }

        public async Task<OnvifResult> RebootAsync()
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifCameraReboot(_url, _userName, _password));
        }

        public OnvifResult Reboot()
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifCameraReboot(_url, _userName, _password)).Result;
        }

        public OnvifResult Reboot(string url, string userName, string password)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifCameraReboot(url, userName, password)).Result;
        }

        public async Task<OnvifClientResult<Uri>> GetCameraWebPageUriAsync()
        {
            var result = await _proxyActor.Ask<Container<string>>(new OnvifGetWebPageUri(_url, _userName, _password));
            return result.Success ? (OnvifClientResult<Uri>)new OnvifClientResultData<Uri>(new Uri(result.WorkItem)) :
                new OnvifClientResultEmpty<Uri>(new Uri(string.Empty));
        }

        public OnvifClientResult<Uri> GetCameraWebPageUri()
        {
            return GetCameraWebPageUri(_url, _userName, _password);
        }

        public OnvifClientResult<Uri> GetCameraWebPageUri(string url, string userName, string password)
        {
            var result = _proxyActor.Ask<Container<string>>(new OnvifGetWebPageUri(url, userName, password)).Result;
            return result.Success ? (OnvifClientResult<Uri>)new OnvifClientResultData<Uri>(new Uri(result.WorkItem)) :
                new OnvifClientResultEmpty<Uri>(new Uri(string.Empty));
        }

        public async Task<OnvifClientResult<DeviceInfo>> GetCameraDeviceInfoAsync()
        {
            var result = await _proxyActor.Ask<Container<DeviceInfo>>(new OnvifGetDeviceInfo(_url, _userName, _password));
            return result.Success ? (OnvifClientResult<DeviceInfo>)new OnvifClientResultData<DeviceInfo>(result.WorkItem)
                : new OnvifClientResultEmpty<DeviceInfo>(new DeviceInfo());
        }

        public OnvifClientResult<DeviceInfo> GetCameraDeviceInfo()
        {
            return GetCameraDeviceInfo(_url, _userName, _password);
        }

        public OnvifClientResult<DeviceInfo> GetCameraDeviceInfo(string url, string userName, string password)
        {
            var result = _proxyActor.Ask<Container<DeviceInfo>>(new OnvifGetDeviceInfo(url, userName, password)).Result;
            return result.Success ? (OnvifClientResult<DeviceInfo>)new OnvifClientResultData<DeviceInfo>(result.WorkItem)
                : new OnvifClientResultEmpty<DeviceInfo>(new DeviceInfo());
        }

        public async Task<OnvifResult> SetDeviceIdentificationAsync(DeviceInfo devInfo)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifSetDeviceIdentification(_url, _userName, _password, devInfo));
        }

        public OnvifResult SetDeviceIdentification(DeviceInfo devInfo)
        {
            return SetDeviceIdentification(_url, _userName, _password, devInfo);
        }

        public OnvifResult SetDeviceIdentification(string url, string userName, string password, DeviceInfo devInfo)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifSetDeviceIdentification(url, userName, password, devInfo)).Result;
        }

        public async Task<OnvifResult> SetDeviceNameAsync(string name)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifSetDeviceName(_url, _userName, _password, name));
        }

        public OnvifResult SetDeviceName(string name)
        {
            return SetDeviceName(_url, _userName, _password, name);
        }

        public OnvifResult SetDeviceName(string url, string userName, string password, string name)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifSetDeviceName(url, userName, password, name)).Result;
        }

        public async Task<OnvifResult> SetDeviceLocationAsync(string location)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifSetDeviceLocation(_url, _userName, _password, location));
        }

        public OnvifResult SetDeviceLocation(string location)
        {
            return SetDeviceLocation(_url, _userName, _password, location);
        }

        public OnvifResult SetDeviceLocation(string url, string userName, string password, string location)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifSetDeviceLocation(url, userName, password, location)).Result;
        }
    }
}
