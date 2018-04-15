using System.Threading.Tasks;
using onvif.services;
using Onvif.Contracts.Messages.Onvif;

namespace Onvif.Camera.Client
{
    public interface IOnvifClient :
        IOnvifClientAsync,
        IOnvifClientSync
    {
        Task<OnvifResult> SetMetadataConfigurationAsync(MetadataConfiguration metaCfg);
        OnvifResult SetMetadataConfiguration(MetadataConfiguration metaCfg);
    }
}
