namespace Onvif.Contracts.Messages.Onvif.Video
{
    public class OnvifGetVideoSettings : OnvifBase
    {
        public string ProfileName { get; set; }

        public OnvifGetVideoSettings(string uri, string userName, string password, string profileName)
            : base(uri, userName, password)
        {
            ProfileName = profileName;
        }
    }
}
