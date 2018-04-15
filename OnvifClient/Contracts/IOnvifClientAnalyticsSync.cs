using onvif.services;
using Onvif.Camera.Client.Model;
using Onvif.Contracts.Messages.Onvif;

namespace Onvif.Camera.Client.Contracts
{
    public interface IOnvifClientAnalyticsSync
    {
        OnvifClientResult<VideoAnalyticsConfiguration> GetVideoAnalyticsConfiguration(string configurationToken);
        OnvifClientResult<AnalyticsEngineInput[]> CreateAnalyticsEngineInputs(AnalyticsEngineInput[] configuration, bool[] forcePersistent);
        OnvifResult SetVideoAnalyticsConfiguration(VideoAnalyticsConfiguration configuration, bool forcePersitent);
        OnvifClientResult<string> GetAnalyticsDeviceStreamUri(StreamSetup setup, string analyticsEngineControlToken);
        OnvifResult DeleteAnalyticsEngineInputs(string[] configurationToken);
        OnvifClientResult<AnalyticsStateInformation> GetAnalyticsState(string analyticsEngineControlToken);
        OnvifResult CreateAnalyticsModules(string vacToken, Config[] analytycsModules);
        OnvifResult DeleteAnalyticsModules(string vacToken, string[] analytycModuleNames);
        OnvifClientResult<Config[]> GetAnalyticsModules(string vacToken);
        OnvifResult ModifyAnalyticsModules(string vacToken, Config[] analytycsModules);
        OnvifClientResult<AnalyticsEngineControl[]> GetAnalyticsEngineControls();
        OnvifClientResult<AnalyticsEngine[]> GetAnalyticsEngines();
        OnvifClientResult<AnalyticsEngine> GetAnalyticsEngine(string configurationToken);
        OnvifClientResult<AnalyticsEngineInput[]> CreateAnalyticsEngineControl(AnalyticsEngineControl configuration);
        OnvifResult SetAnalyticsEngineControl(AnalyticsEngineControl configuration, bool forcePersitent);
        OnvifResult DeleteAnalyticsEngineControl(string configurationToken);
        OnvifClientResult<AnalyticsEngineInput[]> GetAnalyticsEngineInputs();
        OnvifResult SetAnalyticsEngineInput(AnalyticsEngineInput configuration, bool forcePersitent);

        OnvifResult SetVideoAnalyticsConfiguration(string url, string userName, string password, VideoAnalyticsConfiguration configuration, bool forcePersitent);
        OnvifClientResult<string> GetAnalyticsDeviceStreamUri(string url, string userName, string password, StreamSetup setup, string analyticsEngineControlToken);
        OnvifClientResult<VideoAnalyticsConfiguration> GetVideoAnalyticsConfiguration(string url, string userName, string password, string configurationToken);
        OnvifClientResult<AnalyticsEngineInput[]> CreateAnalyticsEngineInputs(string url, string userName, string password, AnalyticsEngineInput[] configuration, bool[] forcePersistent);
        OnvifResult DeleteAnalyticsEngineInputs(string url, string userName, string password, string[] configurationToken);
        OnvifClientResult<AnalyticsStateInformation> GetAnalyticsState(string url, string userName, string password, string analyticsEngineControlToken);
        OnvifResult CreateAnalyticsModules(string url, string userName, string password, string vacToken, Config[] analytycsModules);
        OnvifResult DeleteAnalyticsModules(string url, string userName, string password, string vacToken, string[] analytycModuleNames);
        OnvifClientResult<Config[]> GetAnalyticsModules(string url, string userName, string password, string vacToken);
        OnvifResult ModifyAnalyticsModules(string url, string userName, string password, string vacToken, Config[] analytycsModules);
        OnvifClientResult<AnalyticsEngineControl[]> GetAnalyticsEngineControls(string url, string userName, string password);
        OnvifClientResult<AnalyticsEngine[]> GetAnalyticsEngines(string url, string userName, string password);
        OnvifClientResult<AnalyticsEngine> GetAnalyticsEngine(string url, string userName, string password, string configurationToken);
        OnvifClientResult<AnalyticsEngineInput[]> CreateAnalyticsEngineControl(string url, string userName, string password, AnalyticsEngineControl configuration);
        OnvifResult SetAnalyticsEngineControl(string url, string userName, string password, AnalyticsEngineControl configuration, bool forcePersitent);
        OnvifResult DeleteAnalyticsEngineControl(string url, string userName, string password, string configurationToken);
        OnvifClientResult<AnalyticsEngineControl> GetAnalyticsEngineControl(string url, string userName, string password, string configurationToken);
        OnvifClientResult<AnalyticsEngineInput[]> GetAnalyticsEngineInputs(string url, string userName, string password);
        OnvifResult SetAnalyticsEngineInput(string url, string userName, string password, AnalyticsEngineInput configuration, bool forcePersitent);
    }
}
