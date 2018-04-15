using System;
using Onvif.Camera.Client.Contracts;

namespace Onvif.Camera.Client
{
    public interface IOnvifClientSync :
        IOnvifClientNetworkSync,
        IOnvifClientVideoSync,
        IOnvifClientUsersSync,
        IOnvifClientDeviceSync,
        IOnvifClientSystemDateTimeSync,
        IOnvifClientCertificatesSync,
        IOnvifClientProfilesSync,
        IOnvifClientEvent,
        IOnvifClientSystemLogSync,
        IOnvifClientActionsSync,
        IOnvifClientPtzSync,
        IOnvifClientAnalyticsSync,
        IOnvifClientPropertySync,
        IOnvifClientReceiverSync,
        IOnvifClientImagingSync,
        IOnvifClientRecordingSync,
        IOnvifClientRelaySync,
        IOnvifClientAudioSync,
        IDisposable
    {
    }
}
