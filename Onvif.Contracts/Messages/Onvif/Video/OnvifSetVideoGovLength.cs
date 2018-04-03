namespace Onvif.Contracts.Messages.Onvif.Video
{
    public class OnvifSetVideoGovLength : OnvifBase
    {
        public int GovLength { get; private set; }
        public string ProfileToken { get; private set; }

        public OnvifSetVideoGovLength(string uri, string userName, string password, int govLength, string profileToken)
            : base(uri, userName, password)
        {
            GovLength = govLength;
            ProfileToken = profileToken;
        }
    }
}
