namespace Onvif.Contracts.Messages.Onvif.Ptz
{
    public class OnvifPtzGetStatus : OnvifBase
    {
        public string ProfileToken { get; private set; }

        public OnvifPtzGetStatus(string uri, string userName, string password, string profileToken)
            : base(uri, userName, password)
        {
            ProfileToken = profileToken;
        }
    }
}
