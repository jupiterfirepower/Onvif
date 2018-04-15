using System.Threading.Tasks;
using onvif.services;
using Onvif.Camera.Client.Model;
using Onvif.Contracts.Messages.Onvif;
using Onvif.Contracts.Model;

namespace Onvif.Camera.Client.Contracts
{
    public interface IOnvifClientPtzAsync
    {
        Task<OnvifClientResult<bool>> IsAbsoluteMoveSupportedAsync();
        Task<OnvifClientResult<bool>> IsRelativeMoveSupportedAsync();
        Task<OnvifClientResult<bool>> IsContinuousMoveSupportedAsync();
        Task<OnvifClientResult<bool>> IsHomeSupportedAsync();
        Task<OnvifClientResult<bool>> IsFixedHomePositionAsync();
        Task<OnvifClientResult<bool>> IsFixedHomePositionSpecifiedAsync();
        Task<OnvifResult> AddPtzConfigurationAsync(string profileToken, string configToken);
        Task<OnvifResult> RemovePtzConfigurationAsync(string profileToken);
        Task<OnvifClientResult<PTZNode[]>> GetNodesAsync();
        Task<OnvifClientResult<PTZNode>> GetNodeAsync(string nodeToken);
        Task<OnvifClientResult<PTZConfiguration>> GetConfigurationAsync(string configurationToken);
        Task<OnvifClientResult<PTZConfiguration[]>> GetConfigurationsAsync();
        Task<OnvifResult> SetConfigurationAsync(PTZConfiguration config, bool forcePersistance);
        Task<OnvifClientResult<PTZConfigurationOptions>> GetConfigurationsOptionsAsync(string configurationToken);
        Task<OnvifClientResult<string>> SendAuxiliaryCommandAsync(string profileToken, string auxData);
        Task<OnvifClientResult<PTZPreset[]>> GetPresetsAsync(string profileToken);
        Task<OnvifClientResult<string>> SetPresetAsync(string profileToken, string presetName, string presetToken);
        Task<OnvifResult> RemovePresetAsync(string profileToken, string presetToken);
        Task<OnvifResult> GotoPresetAsync(string profileToken, string presetToken, PTZSpeed speed = null);
        Task<OnvifResult> GotoHomePositionAsync(string profileToken, PTZSpeed speed = null);
        Task<OnvifResult> SetHomePositionAsync(string profileToken);
        Task<OnvifResult> ContinuousMoveAsync(string profileToken, PTZSpeed velocity, XsDuration timeout = null);
        Task<OnvifResult> RelativeMoveAsync(string profileToken, PTZVector traslation, PTZSpeed speed = null);
        Task<OnvifResult> AbsoluteMoveAsync(string profileToken, PTZVector position, PTZSpeed speed = null);
        Task<OnvifResult> StopAsync(string profileToken, bool panTilt, bool zoom);
        Task<OnvifClientResult<PTZStatus>> GetStatusAsync(string profileToken);
        Task<OnvifClientResult<PtzData>> GetPtzDataAsync(string profToken);
        Task<OnvifClientResult<PTZNode>> LoadPtzNodeAsync(PTZConfiguration cfg);
        Task<OnvifClientResult<PTZStatus>> LoadPtzStatusAsync(string token);
        Task<OnvifClientResult<PTZNode>> CreateStandartPtzNodeAsync(string nodeToken);
    }
}
