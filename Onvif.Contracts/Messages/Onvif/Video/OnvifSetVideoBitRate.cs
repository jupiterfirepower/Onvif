namespace Onvif.Contracts.Messages.Onvif.Video
{
    public class OnvifSetVideoBitRate : OnvifBase
    {
        public float BitRate { get; private set; }
        public string ProfileToken { get; private set; }

        public OnvifSetVideoBitRate(string uri, string userName, string password, float bitRate, string profileToken)
            : base(uri, userName, password)
        {
            BitRate = bitRate;
            ProfileToken = profileToken;
        }
    }
}
