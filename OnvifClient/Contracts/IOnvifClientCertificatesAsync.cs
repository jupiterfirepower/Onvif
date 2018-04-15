using System.Threading.Tasks;
using onvif.services;
using Onvif.Camera.Client.Model;
using Onvif.Contracts.Messages.Onvif;

namespace Onvif.Camera.Client.Contracts
{
    public interface IOnvifClientCertificatesAsync
    {
        Task<OnvifResult> SetCertificatesStatusAsync(CertificateStatus[] statuses);
        Task<OnvifResult> DeleteCertificatesAsync(string[] certificateIds);
        Task<OnvifClientResult<Certificate[]>> GetCertificatesAsync();
        Task<OnvifClientResult<CertificateStatus[]>> GetCertificatesStatusAsync();
        Task<OnvifResult> LoadCertificatesAsync(Certificate[] certs);

        

    }
}
