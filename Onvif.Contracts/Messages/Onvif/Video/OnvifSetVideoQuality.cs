namespace Onvif.Contracts.Messages.Onvif.Video
{
    public class OnvifSetVideoQuality : OnvifBase
    {
        public float Quality { get; private set; }
        public string ProfileToken { get; private set; }

        public OnvifSetVideoQuality(string uri, string userName, string password, float quality, string profileToken)
            : base(uri, userName, password)
        {
            Quality = quality;
            ProfileToken = profileToken;
        }
    }
}
