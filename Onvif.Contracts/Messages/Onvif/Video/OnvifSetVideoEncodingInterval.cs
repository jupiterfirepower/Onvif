namespace Onvif.Contracts.Messages.Onvif.Video
{
    public class OnvifSetVideoEncodingInterval : OnvifBase
    {
        public int EncodingInterval { get; private set; }
        public string ProfileToken { get; private set; }

        public OnvifSetVideoEncodingInterval(string uri, string userName, string password, int encodingInterval, string profileToken)
            : base(uri, userName, password)
        {
            EncodingInterval = encodingInterval;
            ProfileToken = profileToken;
        }
    }
}
