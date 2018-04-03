namespace Onvif.Contracts.Messages.Onvif
{
    public class OnvifGetWebPageUri : OnvifBase
    {
        public OnvifGetWebPageUri(string uri, string userName, string password) : base(uri, userName, password)
        {
        }
    }
}
