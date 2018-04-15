using System.Threading.Tasks;
using Akka.Actor;
using onvif.services;
using Onvif.Camera.Client.Model;
using Onvif.Contracts.Messages.Onvif;
using Onvif.Contracts.Messages.Onvif.Certificates;
using Onvif.Contracts.Model;

namespace Onvif.Camera.Client
{
    public partial class OnvifClient
    {
        public async Task<OnvifResult> SetCertificatesStatusAsync(CertificateStatus[] statuses)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifSetCertificatesStatus(_url, _userName, _password, statuses));
        }

        public OnvifResult SetCertificatesStatus(CertificateStatus[] statuses)
        {
            return SetCertificatesStatus(_url, _userName, _password, statuses);
        }

        public OnvifResult SetCertificatesStatus(string url, string userName, string password, CertificateStatus[] statuses)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifSetCertificatesStatus(url, userName, password, statuses)).Result;
        }

        public async Task<OnvifResult> DeleteCertificatesAsync(string[] certificateIds)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifDeleteCertificates(_url, _userName, _password, certificateIds));
        }
        public OnvifResult DeleteCertificates(string[] certificateIds)
        {
            return DeleteCertificates(_url, _userName, _password, certificateIds);
        }

        public OnvifResult DeleteCertificates(string url, string userName, string password, string[] certificateIds)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifDeleteCertificates(url, userName, password, certificateIds)).Result;
        }

        public async Task<OnvifClientResult<Certificate[]>> GetCertificatesAsync()
        {
            var result = await _proxyActor.Ask<Container<Certificate[]>>(new OnvifGetCertificates(_url, _userName, _password));
            return result.Success ? (OnvifClientResult<Certificate[]>)new OnvifClientResultData<Certificate[]>(result.WorkItem)
                : new OnvifClientResultEmpty<Certificate[]>(new Certificate[0]);
        }

        public OnvifClientResult<Certificate[]> GetCertificates()
        {
            return GetCertificates(_url, _userName, _password);
        }

        public OnvifClientResult<Certificate[]> GetCertificates(string url, string userName, string password)
        {
            var result = _proxyActor.Ask<Container<Certificate[]>>(new OnvifGetCertificates(url, userName, password)).Result;
            return result.Success ? (OnvifClientResult<Certificate[]>)new OnvifClientResultData<Certificate[]>(result.WorkItem)
                : new OnvifClientResultEmpty<Certificate[]>(new Certificate[0]);
        }

        public async Task<OnvifClientResult<CertificateStatus[]>> GetCertificatesStatusAsync()
        {
            var result = await _proxyActor.Ask<Container<CertificateStatus[]>>(new OnvifGetCertificatesStatus(_url, _userName, _password));
            return result.Success ? (OnvifClientResult<CertificateStatus[]>)new OnvifClientResultData<CertificateStatus[]>(result.WorkItem)
                : new OnvifClientResultEmpty<CertificateStatus[]>(new CertificateStatus[0]);
        }

        public OnvifClientResult<CertificateStatus[]> GetCertificatesStatus()
        {
            return GetCertificatesStatus(_url, _userName, _password);
        }

        public OnvifClientResult<CertificateStatus[]> GetCertificatesStatus(string url, string userName, string password)
        {
            var result = _proxyActor.Ask<Container<CertificateStatus[]>>(new OnvifGetCertificatesStatus(url, userName, password)).Result;
            return result.Success ? (OnvifClientResult<CertificateStatus[]>)new OnvifClientResultData<CertificateStatus[]>(result.WorkItem)
                : new OnvifClientResultEmpty<CertificateStatus[]>(new CertificateStatus[0]);
        }

        public async Task<OnvifResult> LoadCertificatesAsync(Certificate[] certs)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifLoadCertificates(_url, _userName, _password, certs));
        }

        public OnvifResult LoadCertificates(Certificate[] certs)
        {
            return LoadCertificates(_url, _userName, _password, certs);
        }

        public OnvifResult LoadCertificates(string url, string userName, string password, Certificate[] certs)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifLoadCertificates(url, userName, password, certs)).Result;
        }

    }
}
