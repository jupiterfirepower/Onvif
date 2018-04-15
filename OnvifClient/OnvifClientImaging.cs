using System.Threading.Tasks;
using Akka.Actor;
using onvif.services;
using Onvif.Camera.Client.Model;
using Onvif.Contracts.Messages.Onvif;
using Onvif.Contracts.Messages.Onvif.Imaging;
using Onvif.Contracts.Model;

namespace Onvif.Camera.Client
{
    public partial class OnvifClient
    {
        public async Task<OnvifClientResult<ImagingSettings20>> GetImagingSettingsAsync(string profToken)
        {
            var result = await _proxyActor.Ask<Container<ImagingSettings20>>(new OnvifGetImagingSettings(_url, _userName, _password, profToken));
            return result.Success ? (OnvifClientResult<ImagingSettings20>)new OnvifClientResultData<ImagingSettings20>(result.WorkItem)
                : new OnvifClientResultEmpty<ImagingSettings20>(new ImagingSettings20());
        }

        public OnvifClientResult<ImagingSettings20> GetImagingSettings(string profToken)
        {
            return GetImagingSettings(_url, _userName, _password, profToken);
        }

        public OnvifClientResult<ImagingSettings20> GetImagingSettings(string url, string userName, string password, string profToken)
        {
            var result = _proxyActor.Ask<Container<ImagingSettings20>>(new OnvifGetImagingSettings(url, userName, password, profToken)).Result;
            return result.Success ? (OnvifClientResult<ImagingSettings20>)new OnvifClientResultData<ImagingSettings20>(result.WorkItem)
                : new OnvifClientResultEmpty<ImagingSettings20>(new ImagingSettings20());
        }

        public async Task<OnvifResult> SetImagingSettingsAsync(string profToken, ImagingSettings20 settings)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifSetImagingSettings(_url, _userName, _password, profToken, settings));
        }

        public OnvifResult SetImagingSettings(string profToken, ImagingSettings20 settings)
        {
            return SetImagingSettings(_url, _userName, _password, profToken, settings);
        }

        public OnvifResult SetImagingSettings(string url, string userName, string password, string profToken, ImagingSettings20 settings)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifSetImagingSettings(url, userName, password, profToken, settings)).Result;
        }

        public async Task<OnvifClientResult<ImagingOptions20>> GetOptionsAsync(string profToken)
        {
            var result = await _proxyActor.Ask<Container<ImagingOptions20>>(new OnvifGetImagingOptions(_url, _userName, _password, profToken));
            return result.Success ? (OnvifClientResult<ImagingOptions20>)new OnvifClientResultData<ImagingOptions20>(result.WorkItem)
                : new OnvifClientResultEmpty<ImagingOptions20>(new ImagingOptions20());
        }

        public OnvifClientResult<ImagingOptions20> GetOptions(string profToken)
        {
            return GetOptions(_url, _userName, _password, profToken);
        }

        public OnvifClientResult<ImagingOptions20> GetOptions(string url, string userName, string password, string profToken)
        {
            var result = _proxyActor.Ask<Container<ImagingOptions20>>(new OnvifGetImagingOptions(url, userName, password, profToken)).Result;
            return result.Success ? (OnvifClientResult<ImagingOptions20>)new OnvifClientResultData<ImagingOptions20>(result.WorkItem)
                : new OnvifClientResultEmpty<ImagingOptions20>(new ImagingOptions20());
        }

        public async Task<OnvifResult> MoveAsync(string profToken, FocusMove move)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifImagingMove(_url, _userName, _password, profToken, move));
        }

        public OnvifResult Move(string profToken, FocusMove move)
        {
            return Move(_url, _userName, _password, profToken, move);
        }

        public OnvifResult Move(string url, string userName, string password, string profToken, FocusMove move)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifImagingMove(url, userName, password, profToken, move)).Result;
        }

        public async Task<OnvifClientResult<MoveOptions20>> GetMoveOptionsAsync(string profToken)
        {
            var result = await _proxyActor.Ask<Container<MoveOptions20>>(new OnvifGetImagingMoveOptions(_url, _userName, _password, profToken));
            return result.Success ? (OnvifClientResult<MoveOptions20>)new OnvifClientResultData<MoveOptions20>(result.WorkItem)
                : new OnvifClientResultEmpty<MoveOptions20>(new MoveOptions20());
        }

        public OnvifClientResult<MoveOptions20> GetMoveOptions(string profToken)
        {
            return GetMoveOptions(_url, _userName, _password, profToken);
        }

        public OnvifClientResult<MoveOptions20> GetMoveOptions(string url, string userName, string password, string profToken)
        {
            var result = _proxyActor.Ask<Container<MoveOptions20>>(new OnvifGetImagingMoveOptions(url, userName, password, profToken)).Result;
            return result.Success ? (OnvifClientResult<MoveOptions20>)new OnvifClientResultData<MoveOptions20>(result.WorkItem)
                : new OnvifClientResultEmpty<MoveOptions20>(new MoveOptions20());
        }

        public async Task<OnvifClientResult<ImagingStatus20>> GetImagingStatusAsync(string profToken)
        {
            var result = await _proxyActor.Ask<Container<ImagingStatus20>>(new OnvifGetImagingStatus(_url, _userName, _password, profToken));
            return result.Success ? (OnvifClientResult<ImagingStatus20>)new OnvifClientResultData<ImagingStatus20>(result.WorkItem)
                : new OnvifClientResultEmpty<ImagingStatus20>(new ImagingStatus20());
        }

        public OnvifClientResult<ImagingStatus20> GetImagingStatus(string profToken)
        {
            return GetImagingStatus(_url, _userName, _password, profToken);
        }

        public OnvifClientResult<ImagingStatus20> GetImagingStatus(string url, string userName, string password, string profToken)
        {
            var result = _proxyActor.Ask<Container<ImagingStatus20>>(new OnvifGetImagingStatus(url, userName, password, profToken)).Result;
            return result.Success ? (OnvifClientResult<ImagingStatus20>)new OnvifClientResultData<ImagingStatus20>(result.WorkItem)
                : new OnvifClientResultEmpty<ImagingStatus20>(new ImagingStatus20());
        }
    }
}
