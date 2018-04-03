using System.Threading.Tasks;
using onvif.services;

namespace Onvif.Proxy.Contracts.Contract
{
    public interface IOnvifCertificates
    {
        Task<Certificate[]> GetCertificatesAsync();

        Task<CertificateStatus[]> GetCertificatesStatusAsync();

        Task SetCertificatesStatusAsync(CertificateStatus[] statuses);

        Task DeleteCertificatesAsync(string[] certificateIds);

        Task LoadCertificatesAsync(Certificate[] certs);

        Task UploadCertificatesAsync(string filePath);

        Certificate[] GetCertificates();
        CertificateStatus[] GetCertificatesStatus();
        void SetCertificatesStatus(CertificateStatus[] statuses);
        void DeleteCertificates(string[] certificateIds);
        void LoadCertificates(Certificate[] certs);
    }
}
