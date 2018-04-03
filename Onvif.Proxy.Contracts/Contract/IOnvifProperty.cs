namespace Onvif.Proxy.Contracts.Contract
{
    public interface IOnvifProperty
    {
        bool IsAnalyticsSupported { get; }
        bool IsFirmwareUpgradeSupported { get; }
        bool IsPtzSupported { get; }
    }
}
