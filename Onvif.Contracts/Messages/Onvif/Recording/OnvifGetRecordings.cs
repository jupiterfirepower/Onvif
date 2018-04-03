namespace Onvif.Contracts.Messages.Onvif.Recording
{
    public class OnvifGetRecordings : OnvifBase
    {
        public OnvifGetRecordings(string uri, string userName, string password) : base(uri, userName, password)
        {
        }
    }
}
