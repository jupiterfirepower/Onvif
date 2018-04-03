using System.Threading.Tasks;

namespace Onvif.Proxy.Contracts.Contract
{
    public interface IOnvifAudio
    {
       Task AddAudioEncoderConfigurationAsync(string profileToken, string configurationToken);
       Task RemoveAudioEncoderConfigurationAsync(string profileToken);
       Task AddAudioSourceConfigurationAsync(string profileToken, string configurationToken);
       Task RemoveAudioSourceConfigurationAsync(string profileToken);

       void AddAudioEncoderConfiguration(string profileToken, string configurationToken);
       void RemoveAudioEncoderConfiguration(string profileToken);
       void AddAudioSourceConfiguration(string profileToken, string configurationToken);
       void RemoveAudioSourceConfiguration(string profileToken);
    }
}
