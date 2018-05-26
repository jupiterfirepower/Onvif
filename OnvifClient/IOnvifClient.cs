using System;
using System.Threading.Tasks;
using onvif.services;
using Onvif.Contracts.Messages.Onvif;

namespace Onvif.Client
{
    public interface IOnvifClient :
        IOnvifClientAsync,
        IOnvifClientSync,
        IDisposable
    {
       // Task<OnvifResult> SetMetadataConfigurationAsync(MetadataConfiguration metaCfg);
       // OnvifResult SetMetadataConfiguration(MetadataConfiguration metaCfg);
    }
}
