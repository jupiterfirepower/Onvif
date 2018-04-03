namespace Onvif.Contracts.Messages.Onvif.Ptz
{
    public class OnvifPtzGetConfiguration : OnvifBase
    {
        public string ConfigurationToken { get; private set; }

        public OnvifPtzGetConfiguration(string uri, string userName, string password, string configurationToken)
            : base(uri, userName, password)
        {
            ConfigurationToken = configurationToken;
        }
    }
}
