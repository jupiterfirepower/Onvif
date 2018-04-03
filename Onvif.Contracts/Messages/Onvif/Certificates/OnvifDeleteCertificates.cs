namespace Onvif.Contracts.Messages.Onvif.Certificates
{
    public class OnvifDeleteCertificates : OnvifBase
    {
        public string[] CertificateIds { get; private set; }

        public OnvifDeleteCertificates(string uri, string userName, string password, string[] certificateIds)
            : base(uri, userName, password)
        {
            CertificateIds = certificateIds;
        }
    }
}
