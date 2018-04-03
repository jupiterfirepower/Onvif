namespace Onvif.Contracts.Messages.Onvif.Certificates
{
    public class OnvifGetCertificates : OnvifBase
    {
        public OnvifGetCertificates(string uri, string userName, string password) : base(uri, userName, password)
        {
        }
    }
}
