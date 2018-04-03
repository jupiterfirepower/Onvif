using System.Threading.Tasks;
using onvif.services;

namespace Onvif.Proxy.Contracts.Contract
{
    public interface IOnvifAnalytics
    {
        Task<SupportedAnalyticsModules> GetSupportedAnalyticsModules(string vacToken);
        Task CreateAnalyticsModulesAsync(string vacToken, Config[] analytycsModules);

        Task DeleteAnalyticsModulesAsync(string vacToken, string[] analytycModuleNames);

        Task<Config[]> GetAnalyticsModulesAsync(string vacToken);

        Task ModifyAnalyticsModulesAsync(string vacToken, Config[] analytycsModules);

        Task<AnalyticsEngineControl[]> GetAnalyticsEngineControlsAsync();

        Task<AnalyticsEngineControl> GetAnalyticsEngineControlAsync(string configurationToken);

        Task<AnalyticsEngine[]> GetAnalyticsEnginesAsync();

        Task<AnalyticsEngine> GetAnalyticsEngineAsync(string configurationToken);

        Task SetAnalyticsEngineControlAsync(AnalyticsEngineControl configuration, bool forcePersitent);

        Task DeleteAnalyticsEngineControlAsync(string configurationToken);

        Task<AnalyticsEngineInput[]> GetAnalyticsEngineInputsAsync();

        Task SetAnalyticsEngineInputAsync(AnalyticsEngineInput configuration, bool forcePersitent);

        Task SetVideoAnalyticsConfigurationAsync(VideoAnalyticsConfiguration configuration, bool forcePersitent);

        Task<string> GetAnalyticsDeviceStreamUriAsync(StreamSetup setup, string analyticsEngineControlToken);

        Task<VideoAnalyticsConfiguration> GetVideoAnalyticsConfigurationAsync(string configurationToken);

        Task<AnalyticsEngineInput[]> CreateAnalyticsEngineInputsAsync(AnalyticsEngineInput[] configuration, bool[] forcePersistent);

        Task DeleteAnalyticsEngineInputsAsync(string[] configurationToken);

        Task<AnalyticsStateInformation> GetAnalyticsStateAsync(string analyticsEngineControlToken);

        void CreateAnalyticsModules(string vacToken, Config[] analytycsModules);
        void DeleteAnalyticsModules(string vacToken, string[] analytycModuleNames);
        Config[] GetAnalyticsModules(string vacToken);
        void ModifyAnalyticsModules(string vacToken, Config[] analytycsModules);
        AnalyticsEngineControl[] GetAnalyticsEngineControls();
        AnalyticsEngineControl GetAnalyticsEngineControl(string configurationToken);
        AnalyticsEngine[] GetAnalyticsEngines();
        AnalyticsEngine GetAnalyticsEngine(string configurationToken);
        AnalyticsEngineInput[] CreateAnalyticsEngineControl(AnalyticsEngineControl configuration);
        void SetAnalyticsEngineControl(AnalyticsEngineControl configuration, bool forcePersitent);
        void DeleteAnalyticsEngineControl(string configurationToken);
        AnalyticsEngineInput[] GetAnalyticsEngineInputs();
        void SetAnalyticsEngineInput(AnalyticsEngineInput configuration, bool forcePersitent);
        void SetVideoAnalyticsConfiguration(VideoAnalyticsConfiguration configuration, bool forcePersitent);
        string GetAnalyticsDeviceStreamUri(StreamSetup setup, string analyticsEngineControlToken);
        VideoAnalyticsConfiguration GetVideoAnalyticsConfiguration(string configurationToken);
        AnalyticsEngineInput[] CreateAnalyticsEngineInputs(AnalyticsEngineInput[] configuration, bool[] forcePersistent);
        void DeleteAnalyticsEngineInputs(string[] configurationToken);
        AnalyticsStateInformation GetAnalyticsState(string analyticsEngineControlToken);
    }
}
