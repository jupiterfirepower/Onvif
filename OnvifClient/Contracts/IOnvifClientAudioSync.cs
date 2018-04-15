using Onvif.Contracts.Messages.Onvif;

namespace Onvif.Camera.Client.Contracts
{
    public interface IOnvifClientAudioSync
    {
        OnvifResult AddAudioEncoderConfiguration(string profileToken, string configurationToken);
        OnvifResult RemoveAudioEncoderConfiguration(string profileToken);
        OnvifResult AddAudioSourceConfiguration(string profileToken, string configurationToken);
        OnvifResult RemoveAudioSourceConfiguration(string profileToken);

        OnvifResult AddAudioEncoderConfiguration(string url, string userName, string password, string profileToken, string configurationToken);
        OnvifResult RemoveAudioEncoderConfiguration(string url, string userName, string password, string profileToken);
        OnvifResult AddAudioSourceConfiguration(string url, string userName, string password, string profileToken, string configurationToken);
        OnvifResult RemoveAudioSourceConfiguration(string url, string userName, string password, string profileToken);
    }
}
