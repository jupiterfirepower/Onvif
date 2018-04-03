using onvif.services;

namespace Onvif.Contracts.Messages.Onvif.Ptz
{
    public class OnvifPtzSetConfiguration : OnvifBase
    {
        public PTZConfiguration Config { get; private set; }
        public bool ForcePersistance { get; private set; }

        public OnvifPtzSetConfiguration(string uri, string userName, string password, PTZConfiguration config, bool forcePersistance)
            : base(uri, userName, password)
        {
            Config = config;
            ForcePersistance = forcePersistance;
        }
    }
}
