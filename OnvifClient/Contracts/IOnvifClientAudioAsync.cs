using System.Threading.Tasks;
using Onvif.Contracts.Messages.Onvif;

namespace Onvif.Camera.Client.Contracts
{
    public interface IOnvifClientAudioAsync
    {
        Task<OnvifResult> AddAudioEncoderConfigurationAsync(string profileToken, string configurationToken);
        Task<OnvifResult> RemoveAudioEncoderConfigurationAsync(string profileToken);
        Task<OnvifResult> AddAudioSourceConfigurationAsync(string profileToken, string configurationToken);
        Task<OnvifResult> RemoveAudioSourceConfigurationAsync(string profileToken);
    }
}
