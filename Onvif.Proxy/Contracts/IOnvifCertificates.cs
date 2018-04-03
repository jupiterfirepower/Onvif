using System.Threading.Tasks;
using onvif.services;

namespace Onvif.Proxy.Contracts
{
    public interface IOnvifCertificates
    {
        Task<Certificate[]> GetCertificates();

        Task<CertificateStatus[]> GetCertificatesStatus();

        Task SetCertificatesStatus(CertificateStatus[] statuses);

        Task DeleteCertificates(string[] certificateIds);

        Task LoadCertificates(Certificate[] certs);

        Task UploadCertificates(string filePath);
    }
}
