namespace Onvif.Contracts.Messages.Onvif.Video
{
    public class OnvifSetVideoFrameRate : OnvifBase
    {
        public float FrameRate { get; private set; }
        public string ProfileToken { get; private set; }

        public OnvifSetVideoFrameRate(string uri, string userName, string password, float frameRate, string profileToken)
            : base(uri, userName, password)
        {
            FrameRate = frameRate;
            ProfileToken = profileToken;
        }
    }
}
