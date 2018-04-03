namespace Onvif.Proxy.Contracts
{
    public interface IOnvifProperty
    {
        bool IsAnalyticsSupported { get; }
        bool IsFirmwareUpgradeSupported { get; }
        bool IsPtzSupported { get; }
    }
}
