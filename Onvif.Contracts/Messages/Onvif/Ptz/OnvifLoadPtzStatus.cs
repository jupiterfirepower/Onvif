namespace Onvif.Contracts.Messages.Onvif.Ptz
{
    public class OnvifLoadPtzStatus : OnvifBase
    {
        public string ProfileToken { get; private set; }

        public OnvifLoadPtzStatus(string uri, string userName, string password, string profileToken)
            : base(uri, userName, password)
        {
            ProfileToken = profileToken;
        }
    }
}
