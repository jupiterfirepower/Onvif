using System.Threading.Tasks;
using Akka.Actor;
using Onvif.Contracts.Messages.Onvif;
using Onvif.Contracts.Messages.Onvif.Audio;

namespace Onvif.Camera.Client
{
    public partial class OnvifClient
    {
        public async Task<OnvifResult> AddAudioEncoderConfigurationAsync(string profileToken, string configurationToken)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifAddAudioEncoderConfiguration(_url, _userName, _password, profileToken, configurationToken));
        }

        public OnvifResult AddAudioEncoderConfiguration(string profileToken, string configurationToken)
        {
            return AddAudioEncoderConfiguration(_url, _userName, _password, profileToken, configurationToken);
        }

        public OnvifResult AddAudioEncoderConfiguration(string url, string userName, string password, string profileToken, string configurationToken)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifAddAudioEncoderConfiguration(url, userName, password, profileToken, configurationToken)).Result;
        }

        public async Task<OnvifResult> RemoveAudioEncoderConfigurationAsync(string profileToken)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifRemoveAudioEncoderConfiguration(_url, _userName, _password, profileToken));
        }

        public OnvifResult RemoveAudioEncoderConfiguration(string profileToken)
        {
            return RemoveAudioEncoderConfiguration(_url, _userName, _password, profileToken);
        }

        public OnvifResult RemoveAudioEncoderConfiguration(string url, string userName, string password, string profileToken)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifRemoveAudioEncoderConfiguration(url, userName, password, profileToken)).Result;
        }

        public async Task<OnvifResult> AddAudioSourceConfigurationAsync(string profileToken, string configurationToken)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifAddAudioSourceConfiguration(_url, _userName, _password, profileToken, configurationToken));
        }

        public OnvifResult AddAudioSourceConfiguration(string profileToken, string configurationToken)
        {
            return AddAudioSourceConfiguration(_url, _userName, _password, profileToken, configurationToken);
        }

        public OnvifResult AddAudioSourceConfiguration(string url, string userName, string password, string profileToken, string configurationToken)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifAddAudioSourceConfiguration(url, userName, password, profileToken, configurationToken)).Result;
        }

        public async Task<OnvifResult> RemoveAudioSourceConfigurationAsync(string profileToken)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifRemoveAudioSourceConfiguration(_url, _userName, _password, profileToken));
        }

        public OnvifResult RemoveAudioSourceConfiguration(string profileToken)
        {
            return RemoveAudioSourceConfiguration(_url, _userName, _password, profileToken);
        }

        public OnvifResult RemoveAudioSourceConfiguration(string url, string userName, string password, string profileToken)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifRemoveAudioSourceConfiguration(url, userName, password, profileToken)).Result;
        }
    }
}
