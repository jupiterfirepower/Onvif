namespace Onvif.Contracts.Messages.Onvif.Replay
{
    public class OnvifGetReplayUri : OnvifBase
    {
        public OnvifGetReplayUri(string uri, string userName, string password) : base(uri, userName, password)
        {
        }
    }
}
