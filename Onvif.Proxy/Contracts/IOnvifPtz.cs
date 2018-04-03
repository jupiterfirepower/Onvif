using System.Threading.Tasks;
using onvif.services;
using Onvif.Contracts.Model;

namespace Onvif.Proxy.Contracts
{
    public interface IOnvifPtz
    {
        Task<bool> IsRelativeMoveSupported();
        Task<bool> IsContinuousMoveSupported();
        Task<bool> IsHomeSupported();
        Task AddPtzConfiguration(string profileToken, string configToken);
        Task RemovePtzConfiguration(string profileToken);
        Task<PTZNode[]> GetNodes();
        Task<PTZNode> GetNode(string nodeToken);
        Task<PTZConfiguration> GetConfiguration(string configurationToken);
        Task<PTZConfiguration[]> GetConfigurations();
        Task SetConfiguration(PTZConfiguration config, bool forcePersistance);
        Task<PTZConfigurationOptions> GetConfigurationsOptions(string configurationToken);
        Task<string> SendAuxiliaryCommand(string profileToken, string auxData);
        Task<PTZPreset[]> GetPresets(string profileToken);
        Task<string> SetPreset(string profileToken, string presetName, string presetToken);
        Task RemovePreset(string profileToken, string presetToken);
        Task GotoPreset(string profileToken, string presetToken, PTZSpeed speed = null);
        Task GotoHomePosition(string profileToken, PTZSpeed speed = null);
        Task SetHomePosition(string profileToken);
        Task ContinuousMove(string profileToken, PTZSpeed velocity, XsDuration timeout = null);
        Task RelativeMove(string profileToken, PTZVector traslation, PTZSpeed speed = null);
        Task<PTZStatus> GetStatus(string profileToken);
        Task AbsoluteMove(string profileToken, PTZVector position, PTZSpeed speed = null);
        Task Stop(string profileToken, bool panTilt, bool zoom);
        Task<PtzData> GetPtzData(string profToken);
        Task<PTZNode> LoadPtzNode(PTZConfiguration cfg);
        Task<PTZStatus> LoadPtzStatus(string token);

        PTZNode CreateStandartPtzNode(string nodeToken);
    }
}
