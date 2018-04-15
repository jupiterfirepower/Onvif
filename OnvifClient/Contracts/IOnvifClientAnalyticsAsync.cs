using System.Threading.Tasks;
using onvif.services;
using Onvif.Camera.Client.Model;
using Onvif.Contracts.Messages.Onvif;

namespace Onvif.Camera.Client.Contracts
{
    public interface IOnvifClientAnalyticsAsync
    {
        Task<OnvifResult> CreateAnalyticsModulesAsync(string vacToken, Config[] analytycsModules);
        Task<OnvifResult> DeleteAnalyticsModulesAsync(string vacToken, string[] analytycModuleNames);
        Task<OnvifClientResult<Config[]>> GetAnalyticsModulesAsync(string vacToken);
        Task<OnvifResult> ModifyAnalyticsModulesAsync(string vacToken, Config[] analytycsModules);
        Task<OnvifClientResult<AnalyticsEngineControl[]>> GetAnalyticsEngineControlsAsync();
        Task<OnvifClientResult<AnalyticsEngineControl>> GetAnalyticsEngineControlAsync(string configurationToken);
        Task<OnvifClientResult<AnalyticsEngine[]>> GetAnalyticsEnginesAsync();
        Task<OnvifClientResult<AnalyticsEngine>> GetAnalyticsEngineAsync(string configurationToken);
        Task<OnvifClientResult<AnalyticsEngineInput[]>> CreateAnalyticsEngineControlAsync(AnalyticsEngineControl configuration);
        Task<OnvifResult> SetAnalyticsEngineControlAsync(AnalyticsEngineControl configuration, bool forcePersitent);
        Task<OnvifResult> DeleteAnalyticsEngineControlAsync(string configurationToken);
        Task<OnvifClientResult<AnalyticsEngineInput[]>> GetAnalyticsEngineInputsAsync();
        Task<OnvifResult> SetAnalyticsEngineInputAsync(AnalyticsEngineInput configuration, bool forcePersitent);
        Task<OnvifResult> SetVideoAnalyticsConfigurationAsync(VideoAnalyticsConfiguration configuration, bool forcePersitent);
        Task<OnvifClientResult<string>> GetAnalyticsDeviceStreamUriAsync(StreamSetup setup, string analyticsEngineControlToken);
        Task<OnvifClientResult<VideoAnalyticsConfiguration>> GetVideoAnalyticsConfigurationAsync(string configurationToken);
        Task<OnvifClientResult<AnalyticsEngineInput[]>> CreateAnalyticsEngineInputsAsync(AnalyticsEngineInput[] configuration, bool[] forcePersistent);
        Task<OnvifResult> DeleteAnalyticsEngineInputsAsync(string[] configurationToken);
        Task<OnvifClientResult<AnalyticsStateInformation>> GetAnalyticsStateAsync(string analyticsEngineControlToken);

        
    }
}
