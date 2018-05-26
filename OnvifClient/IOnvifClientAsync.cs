using Onvif.Client.Contracts;

namespace Onvif.Client
{
    public interface IOnvifClientAsync :
       /* IOnvifClientNetworkAsync, 
        IOnvifClientVideoAsync, 
        IOnvifClientUsersAsync, 
        IOnvifClientDeviceAsync, 
        IOnvifClientSystemDateTimeAsync,
        IOnvifClientCertificatesAsync,
        IOnvifClientProfilesAsync,
        IOnvifClientEvent,
        IOnvifClientSystemLogAsync,*/
        IOnvifClientActionsAsync
        /*IOnvifClientPtzAsync,
        IOnvifClientAnalyticsAsync,
        IOnvifClientPropertyAsync,
        IOnvifClientReceiverAsync,
        IOnvifClientImagingAsync,
        IOnvifClientRecordingAsync,
        IOnvifClientRelayAsync,
        IOnvifClientAudioAsync,
        IDisposable*/
    {
    }
}
