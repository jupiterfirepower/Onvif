using onvif.services;
using Onvif.Camera.Client.Model;
using Onvif.Contracts.Messages.Onvif;

namespace Onvif.Camera.Client.Contracts
{
    public interface IOnvifClientCertificatesSync
    {
        OnvifResult SetCertificatesStatus(CertificateStatus[] statuses);
        OnvifResult DeleteCertificates(string[] certificateIds);
        OnvifClientResult<Certificate[]> GetCertificates();
        OnvifClientResult<CertificateStatus[]> GetCertificatesStatus();
        OnvifResult LoadCertificates(Certificate[] certs);

        OnvifResult SetCertificatesStatus(string url, string userName, string password, CertificateStatus[] statuses);
        OnvifResult DeleteCertificates(string url, string userName, string password, string[] certificateIds);
        OnvifClientResult<Certificate[]> GetCertificates(string url, string userName, string password);
        OnvifClientResult<CertificateStatus[]> GetCertificatesStatus(string url, string userName, string password);
        OnvifResult LoadCertificates(string url, string userName, string password, Certificate[] certs);
    }
}
