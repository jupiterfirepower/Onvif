using odm.core;
using onvif.utils;

namespace Onvif.Proxy.Contracts
{
    public interface IOnvifSession
    {
        INvtSession GetNvtSession();

        OdmSession OdmSession { get; }
    }
}
