using odm.core;
using onvif.utils;

namespace Onvif.Proxy.Contracts.Contract
{
    public interface IOnvifSession
    {
        INvtSession GetNvtSession();
        OdmSession OdmSession { get; }
    }
}
