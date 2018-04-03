using onvif.services;

namespace Onvif.Contracts.Messages.Onvif.Ptz
{
    public class OnvifLoadPtzNode : OnvifBase
    {
        public PTZConfiguration Config { get; private set; }

        public OnvifLoadPtzNode(string uri, string userName, string password, PTZConfiguration config)
            : base(uri, userName, password)
        {
            Config = config;
        }
    }
}
