using System;
using Onvif.Camera.Client.Contracts;

namespace Onvif.Camera.Client
{
    public interface IOnvifClientAsync :
        IOnvifClientNetworkAsync, 
        IOnvifClientVideoAsync, 
        IOnvifClientUsersAsync, 
        IOnvifClientDeviceAsync, 
        IOnvifClientSystemDateTimeAsync,
        IOnvifClientCertificatesAsync,
        IOnvifClientProfilesAsync,
        IOnvifClientEvent,
        IOnvifClientSystemLogAsync,
        IOnvifClientActionsAsync,
        IOnvifClientPtzAsync,
        IOnvifClientAnalyticsAsync,
        IOnvifClientPropertyAsync,
        IOnvifClientReceiverAsync,
        IOnvifClientImagingAsync,
        IOnvifClientRecordingAsync,
        IOnvifClientRelayAsync,
        IOnvifClientAudioAsync,
        IDisposable
    {
    }
}
