using System;
using onvif.services;
using Onvif.Camera.Client.Model;
using Onvif.Contracts.Messages.Onvif;
using Onvif.Contracts.Model;

namespace Onvif.Camera.Client.Contracts
{
    public interface IOnvifClientDeviceSync
    {
        OnvifResult Reset(FactoryDefaultType resetType);
        OnvifResult Reboot();
        OnvifClientResult<Uri> GetCameraWebPageUri();
        OnvifClientResult<DeviceInfo> GetCameraDeviceInfo();
        OnvifResult SetDeviceIdentification(DeviceInfo devInfo);
        OnvifResult SetDeviceName(string name);
        OnvifResult SetDeviceLocation(string location);

        OnvifResult Reset(string url, string userName, string password, FactoryDefaultType resetType);
        OnvifResult Reboot(string url, string userName, string password);
        OnvifClientResult<Uri> GetCameraWebPageUri(string url, string userName, string password);
        OnvifClientResult<DeviceInfo> GetCameraDeviceInfo(string url, string userName, string password);
        OnvifResult SetDeviceIdentification(string url, string userName, string password, DeviceInfo devInfo);
        OnvifResult SetDeviceName(string url, string userName, string password, string name);
        OnvifResult SetDeviceLocation(string url, string userName, string password, string location);
    }
}
