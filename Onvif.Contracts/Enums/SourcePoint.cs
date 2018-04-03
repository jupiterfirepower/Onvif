namespace Onvif.Contracts.Enums
{
    public enum SourcePoint
    {
        FromDecisionMakerActor,
        FromMethodSubscribePullPointCameraEvents,
        FromMethodSubscribeEventsStartStop,
        FromNetworkChange,
        FromGetEventPropertiesTimeout,
        FromRxIntervalObservable,
        FromMethodPostRestart
    }
}
