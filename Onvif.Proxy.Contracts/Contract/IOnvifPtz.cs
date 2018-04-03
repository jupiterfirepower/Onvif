using System.Threading.Tasks;
using onvif.services;
using Onvif.Contracts.Model;

namespace Onvif.Proxy.Contracts.Contract
{
    public interface IOnvifPtz
    {
        Task<bool> IsAbsoluteMoveSupportedAsync();
        Task<bool> IsRelativeMoveSupportedAsync();
        Task<bool> IsContinuousMoveSupportedAsync();
        Task<bool> IsHomeSupportedAsync();
        Task<bool> IsFixedHomePositionAsync();
        Task<bool> IsFixedHomePositionSpecifiedAsync();

        Task AddPtzConfigurationAsync(string profileToken, string configToken);
        Task RemovePtzConfigurationAsync(string profileToken);
        Task<PTZNode[]> GetNodesAsync();
        Task<PTZNode> GetNodeAsync(string nodeToken);
        Task<PTZConfiguration> GetConfigurationAsync(string configurationToken);
        Task<PTZConfiguration[]> GetConfigurationsAsync();
        Task SetConfigurationAsync(PTZConfiguration config, bool forcePersistance);
        Task<PTZConfigurationOptions> GetConfigurationsOptionsAsync(string configurationToken);
        Task<string> SendAuxiliaryCommandAsync(string profileToken, string auxData);
        Task<PTZPreset[]> GetPresetsAsync(string profileToken);
        Task<string> SetPresetAsync(string profileToken, string presetName, string presetToken);
        Task RemovePresetAsync(string profileToken, string presetToken);
        Task GotoPresetAsync(string profileToken, string presetToken, PTZSpeed speed = null);
        Task GotoHomePositionAsync(string profileToken, PTZSpeed speed = null);
        Task SetHomePositionAsync(string profileToken);
        Task ContinuousMoveAsync(string profileToken, PTZSpeed velocity, XsDuration timeout = null);
        Task RelativeMoveAsync(string profileToken, PTZVector traslation, PTZSpeed speed = null);
        Task<PTZStatus> GetStatusAsync(string profileToken);
        Task AbsoluteMoveAsync(string profileToken, PTZVector position, PTZSpeed speed = null);
        Task StopAsync(string profileToken, bool panTilt, bool zoom);
        Task<PtzData> GetPtzDataAsync(string profToken);
        Task<PTZNode> LoadPtzNodeAsync(PTZConfiguration cfg);
        Task<PTZStatus> LoadPtzStatusAsync(string token);
        PTZNode CreateStandartPtzNode(string nodeToken);

        bool IsHomeSupported();
        bool IsFixedHomePosition();
        bool IsFixedHomePositionSpecified();
        void AddPtzConfiguration(string profileToken, string configToken);
        void RemovePtzConfiguration(string profileToken);
        PTZNode[] GetNodes();
        PTZNode GetNode(string nodeToken);
        PTZConfiguration GetConfiguration(string configurationToken);
        PTZConfiguration[] GetConfigurations();
        void SetConfiguration(PTZConfiguration config, bool forcePersistance);
        PTZConfigurationOptions GetConfigurationsOptions(string configurationToken);
        string SendAuxiliaryCommand(string profileToken, string auxData);
        PTZPreset[] GetPresets(string profileToken);
        string SetPreset(string profileToken, string presetName, string presetToken);
        void RemovePreset(string profileToken, string presetToken);
        void GotoPreset(string profileToken, string presetToken, PTZSpeed speed = null);
        void GotoHomePosition(string profileToken, PTZSpeed speed = null);
        void SetHomePosition(string profileToken);
        void ContinuousMove(string profileToken, PTZSpeed velocity, XsDuration timeout = null);
        void RelativeMove(string profileToken, PTZVector traslation, PTZSpeed speed = null);
        void AbsoluteMove(string profileToken, PTZVector position, PTZSpeed speed = null);
        PTZStatus GetStatus(string profileToken);
        void Stop(string profileToken, bool panTilt, bool zoom);
        PtzData GetPtzData(string profToken);
        PTZNode LoadPtzNode(PTZConfiguration cfg);
        PTZStatus LoadPtzStatus(string token);
    }
}
