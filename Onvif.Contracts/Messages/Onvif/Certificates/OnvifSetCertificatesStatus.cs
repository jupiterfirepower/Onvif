using onvif.services;

namespace Onvif.Contracts.Messages.Onvif.Certificates
{
    public class OnvifSetCertificatesStatus : OnvifBase
    {
        public CertificateStatus[] CertificateStatuses { get; private set; }

        public OnvifSetCertificatesStatus(string uri, string userName, string password, CertificateStatus[] certificateStatuses)
            : base(uri, userName, password)
        {
            CertificateStatuses = certificateStatuses;
        }
    }
}
