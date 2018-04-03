namespace Onvif.Contracts.Enums
{
    public enum MetricNames
    {
        OnvifCameraConnected,
        OnvifCameraConnectedFailed,
        SubscribeToCameraEvents,
        UnSubscribeToCameraEvents,
        OnvifCameraProcessingEvent,
        WebUrlResponse,
        WebUrlWebException,
        SubscribePullPointCameraEventsException,
        SubscribePullPointCameraEventsReconnectAfterException,
        OnvifCameraDisconnected,
        OnvifCameraReconnected,
        OnvifCameraTryConnect,
        NetworkAvailabilityNotAvailable,
        NetworkAvailabilityAvailable,
        GetChangesCameraListSqlException,
        OnvifProcessingServiceRecoveryRestart,
        OnvifCameraReconnectCycleError,
        ManagedPortsCriticalError,
        Unknown
    }
}
