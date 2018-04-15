using onvif.services;
using Onvif.Camera.Client.Model;
using Onvif.Contracts.Messages.Onvif;
using Onvif.Contracts.Model;

namespace Onvif.Camera.Client.Contracts
{
    public interface IOnvifClientPtzSync
    {
        OnvifClientResult<bool> IsHomeSupported();
        OnvifClientResult<bool> IsFixedHomePosition();
        OnvifClientResult<bool> IsFixedHomePositionSpecified();
        OnvifClientResult<bool> IsRelativeMoveSupported();
        OnvifClientResult<bool> IsContinuousMoveSupported();
        OnvifResult AddPtzConfiguration(string profileToken, string configToken);
        OnvifResult RemovePtzConfiguration(string profileToken);
        OnvifClientResult<PTZNode[]> GetNodes();
        OnvifClientResult<PTZNode> GetNode(string nodeToken);
        OnvifClientResult<PTZConfiguration> GetConfiguration(string configurationToken);
        OnvifClientResult<PTZConfiguration[]> GetConfigurations();
        OnvifResult SetConfiguration(PTZConfiguration config, bool forcePersistance);
        OnvifClientResult<PTZConfigurationOptions> GetConfigurationsOptions(string configurationToken);
        OnvifClientResult<string> SendAuxiliaryCommand(string profileToken, string auxData);
        OnvifClientResult<string> SetPreset(string profileToken, string presetName, string presetToken);
        OnvifClientResult<PTZPreset[]> GetPresets(string profileToken);
        OnvifResult RemovePreset(string profileToken, string presetToken);
        OnvifResult GotoPreset(string profileToken, string presetToken, PTZSpeed speed = null);
        OnvifResult GotoHomePosition(string profileToken, PTZSpeed speed = null);
        OnvifResult SetHomePosition(string profileToken);
        OnvifResult AbsoluteMove(string profileToken, PTZVector position, PTZSpeed speed = null);
        OnvifResult ContinuousMove(string profileToken, PTZSpeed velocity, XsDuration timeout = null);
        OnvifResult RelativeMove(string profileToken, PTZVector traslation, PTZSpeed speed = null);
        OnvifClientResult<PTZStatus> GetStatus(string profileToken);
        OnvifResult Stop(string profileToken, bool panTilt, bool zoom);
        OnvifClientResult<PtzData> GetPtzData(string profileToken);
        OnvifClientResult<PTZNode> LoadPtzNode(PTZConfiguration cfg);
        OnvifClientResult<PTZStatus> LoadPtzStatus(string profileToken);
        OnvifClientResult<PTZNode> CreateStandartPtzNode(string nodeToken);
        OnvifClientResult<bool> IsAbsoluteMoveSupported(string url, string userName, string password);
        OnvifClientResult<bool> IsFixedHomePosition(string url, string userName, string password);
        OnvifClientResult<bool> IsFixedHomePositionSpecified(string url, string userName, string password);
        OnvifClientResult<bool> IsRelativeMoveSupported(string url, string userName, string password);
        OnvifClientResult<bool> IsContinuousMoveSupported(string url, string userName, string password);
        OnvifClientResult<bool> IsHomeSupported(string url, string userName, string password);
        OnvifResult AddPtzConfiguration(string url, string userName, string password, string profileToken, string configToken);
        OnvifResult RemovePtzConfiguration(string url, string userName, string password, string profileToken);
        OnvifClientResult<PTZNode[]> GetNodes(string url, string userName, string password);
        OnvifClientResult<PTZNode> GetNode(string url, string userName, string password, string nodeToken);
        OnvifClientResult<PTZConfiguration> GetConfiguration(string url, string userName, string password, string configurationToken);
        OnvifClientResult<PTZConfiguration[]> GetConfigurations(string url, string userName, string password);
        OnvifResult SetConfiguration(string url, string userName, string password, PTZConfiguration config, bool forcePersistance);
        OnvifClientResult<PTZConfigurationOptions> GetConfigurationsOptions(string url, string userName, string password, string configurationToken);
        OnvifClientResult<string> SendAuxiliaryCommand(string url, string userName, string password, string profileToken, string auxData);
        OnvifClientResult<string> SetPreset(string url, string userName, string password, string profileToken, string presetName, string presetToken);
        OnvifClientResult<PTZPreset[]> GetPresets(string url, string userName, string password, string profileToken);
        OnvifResult RemovePreset(string url, string userName, string password, string profileToken, string presetToken);
        OnvifResult GotoPreset(string url, string userName, string password, string profileToken, string presetToken, PTZSpeed speed = null);
        OnvifResult GotoHomePosition(string url, string userName, string password, string profileToken, PTZSpeed speed = null);
        OnvifResult SetHomePosition(string url, string userName, string password, string profileToken);
        OnvifResult AbsoluteMove(string url, string userName, string password, string profileToken, PTZVector position, PTZSpeed speed = null);
        OnvifResult ContinuousMove(string url, string userName, string password, string profileToken, PTZSpeed velocity, XsDuration timeout = null);
        OnvifResult RelativeMove(string url, string userName, string password, string profileToken, PTZVector traslation, PTZSpeed speed = null);
        OnvifClientResult<PTZStatus> GetStatus(string url, string userName, string password, string profileToken);
        OnvifResult Stop(string url, string userName, string password, string profileToken, bool panTilt, bool zoom);
        OnvifClientResult<PtzData> GetPtzData(string url, string userName, string password, string profileToken);
        OnvifClientResult<PTZNode> LoadPtzNode(string url, string userName, string password, PTZConfiguration cfg);
        OnvifClientResult<PTZStatus> LoadPtzStatus(string url, string userName, string password, string profileToken);
        OnvifClientResult<PTZNode> CreateStandartPtzNode(string url, string userName, string password, string nodeToken);
    }
}
