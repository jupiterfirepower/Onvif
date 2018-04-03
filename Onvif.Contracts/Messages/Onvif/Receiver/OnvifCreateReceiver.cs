using onvif.services;

namespace Onvif.Contracts.Messages.Onvif.Receiver
{
    public class OnvifCreateReceiver : OnvifBase
    {
        public ReceiverConfiguration Configuration { get; private set; }

        public OnvifCreateReceiver(string uri, string userName, string password, ReceiverConfiguration configuration)
            : base(uri, userName, password)
        {
            Configuration = configuration;
        }
    }
}
