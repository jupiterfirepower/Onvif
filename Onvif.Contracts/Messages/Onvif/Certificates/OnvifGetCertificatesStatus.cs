namespace Onvif.Contracts.Messages.Onvif.Certificates
{
    public class OnvifGetCertificatesStatus : OnvifBase
    {
        public OnvifGetCertificatesStatus(string uri, string userName, string password) : base(uri, userName, password)
        {
        }
    }
}
