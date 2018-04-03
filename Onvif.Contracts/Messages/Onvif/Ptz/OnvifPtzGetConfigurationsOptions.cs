namespace Onvif.Contracts.Messages.Onvif.Ptz
{
    public class OnvifPtzGetConfigurationsOptions : OnvifBase
    {
        public string ConfigurationToken { get; private set; }

        public OnvifPtzGetConfigurationsOptions(string uri, string userName, string password, string configurationToken)
            : base(uri, userName, password)
        {
            ConfigurationToken = configurationToken;
        }
    }
}
