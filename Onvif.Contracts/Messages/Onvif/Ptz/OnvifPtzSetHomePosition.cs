namespace Onvif.Contracts.Messages.Onvif.Ptz
{
    public class OnvifPtzSetHomePosition : OnvifBase
    {
        public string ProfileToken { get; private set; }

        public OnvifPtzSetHomePosition(string uri, string userName, string password, string profileToken)
            : base(uri, userName, password)
        {
            ProfileToken = profileToken;
        }
    }
}
