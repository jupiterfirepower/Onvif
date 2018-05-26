using System;
using Onvif.Client.Contracts;

namespace Onvif.Client
{
    public interface IOnvifClientSync :
        /*IOnvifClientNetworkSync,
         IOnvifClientVideoSync,
         IOnvifClientUsersSync,
         IOnvifClientDeviceSync,
         IOnvifClientSystemDateTimeSync,
         IOnvifClientCertificatesSync,
         IOnvifClientProfilesSync,
         IOnvifClientEvent,
         IOnvifClientSystemLogSync,*/
         IOnvifClientActionsSync
        /*IOnvifClientPtzSync,
        IOnvifClientAnalyticsSync,
        IOnvifClientPropertySync,
        IOnvifClientReceiverSync,
        IOnvifClientImagingSync,
        IOnvifClientRecordingSync,
        IOnvifClientRelaySync,
        IOnvifClientAudioSync,
        IDisposable*/
    {
    }
}
