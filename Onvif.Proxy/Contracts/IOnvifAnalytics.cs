using System.Threading.Tasks;
using onvif.services;

namespace Onvif.Proxy.Contracts
{
    public interface IOnvifAnalytics
    {
        Task CreateAnalyticsModules(string vacToken, Config[] analytycsModules);

        Task DeleteAnalyticsModules(string vacToken, string[] analytycModuleNames);

        Task<Config[]> GetAnalyticsModules(string vacToken);

        Task ModifyAnalyticsModules(string vacToken, Config[] analytycsModules);

        Task<AnalyticsEngineControl[]> GetAnalyticsEngineControls();

        Task<AnalyticsEngineControl> GetAnalyticsEngineControl(string configurationToken);

        Task<AnalyticsEngine[]> GetAnalyticsEngines();

        Task<AnalyticsEngine> GetAnalyticsEngine(string configurationToken);

        Task SetAnalyticsEngineControl(AnalyticsEngineControl configuration, bool forcePersitent);

        Task DeleteAnalyticsEngineControl(string configurationToken);

        Task<AnalyticsEngineInput[]> GetAnalyticsEngineInputs();

        Task SetAnalyticsEngineInput(AnalyticsEngineInput configuration, bool forcePersitent);

        Task SetVideoAnalyticsConfiguration(VideoAnalyticsConfiguration configuration, bool forcePersitent);

        Task<string> GetAnalyticsDeviceStreamUri(StreamSetup setup, string analyticsEngineControlToken);

        Task<VideoAnalyticsConfiguration> GetVideoAnalyticsConfiguration(string configurationToken);

        Task<AnalyticsEngineInput[]> CreateAnalyticsEngineInputs(AnalyticsEngineInput[] configuration, bool[] forcePersistent);

        Task DeleteAnalyticsEngineInputs(string[] configurationToken);

        Task<AnalyticsStateInformation> GetAnalyticsState(string analyticsEngineControlToken);
    }
}
