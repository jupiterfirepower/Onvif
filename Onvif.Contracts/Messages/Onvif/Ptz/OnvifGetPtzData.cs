namespace Onvif.Contracts.Messages.Onvif.Ptz
{
    public class OnvifGetPtzData : OnvifBase
    {
        public string ProfileToken { get; private set; }

        public OnvifGetPtzData(string uri, string userName, string password, string profileToken)
            : base(uri, userName, password)
        {
            ProfileToken = profileToken;
        }
    }
}
