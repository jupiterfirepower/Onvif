using onvif.services;

namespace Onvif.Contracts.Messages.Onvif.Certificates
{
    public class OnvifLoadCertificates : OnvifBase
    {
        public Certificate[] Certificates { get; private set; }

        public OnvifLoadCertificates(string uri, string userName, string password, Certificate[] certificates)
            : base(uri, userName, password)
        {
            Certificates = certificates;
        }
    }
}
