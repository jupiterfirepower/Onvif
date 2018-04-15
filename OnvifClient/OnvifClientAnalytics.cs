using System.Threading.Tasks;
using Akka.Actor;
using onvif.services;
using Onvif.Camera.Client.Model;
using Onvif.Contracts.Messages.Onvif;
using Onvif.Contracts.Messages.Onvif.Analytics;
using Onvif.Contracts.Model;

namespace Onvif.Camera.Client
{
    public partial class OnvifClient
    {
        public async Task<OnvifResult> SetVideoAnalyticsConfigurationAsync(VideoAnalyticsConfiguration configuration, bool forcePersitent)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifSetVideoAnalyticsConfiguration(_url, _userName, _password, configuration, forcePersitent));
        }

        public OnvifResult SetVideoAnalyticsConfiguration(VideoAnalyticsConfiguration configuration, bool forcePersitent)
        {
            return SetVideoAnalyticsConfiguration(_url, _userName, _password, configuration, forcePersitent);
        }

        public OnvifResult SetVideoAnalyticsConfiguration(string url, string userName, string password, VideoAnalyticsConfiguration configuration, bool forcePersitent)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifSetVideoAnalyticsConfiguration(url, userName, password, configuration, forcePersitent)).Result;
        }

        public async Task<OnvifClientResult<string>> GetAnalyticsDeviceStreamUriAsync(StreamSetup setup, string analyticsEngineControlToken)
        {
            var result = await _proxyActor.Ask<Container<string>>(new OnvifGetAnalyticsDeviceStreamUri(_url, _userName, _password, setup, analyticsEngineControlToken));
            return result.Success ? (OnvifClientResult<string>)new OnvifClientResultData<string>(result.WorkItem)
                : new OnvifClientResultEmpty<string>(string.Empty);
        }

        public OnvifClientResult<string> GetAnalyticsDeviceStreamUri(StreamSetup setup, string analyticsEngineControlToken)
        {
            return GetAnalyticsDeviceStreamUri(_url, _userName, _password, setup, analyticsEngineControlToken);
        }

        public OnvifClientResult<string> GetAnalyticsDeviceStreamUri(string url, string userName, string password, StreamSetup setup, string analyticsEngineControlToken)
        {
            var result = _proxyActor.Ask<Container<string>>(new OnvifGetAnalyticsDeviceStreamUri(url, userName, password, setup, analyticsEngineControlToken)).Result;
            return result.Success ? (OnvifClientResult<string>)new OnvifClientResultData<string>(result.WorkItem)
                : new OnvifClientResultEmpty<string>(string.Empty);
        }

        public async Task<OnvifClientResult<VideoAnalyticsConfiguration>> GetVideoAnalyticsConfigurationAsync(string configurationToken)
        {
            var result = await _proxyActor.Ask<Container<VideoAnalyticsConfiguration>>(new OnvifGetVideoAnalyticsConfiguration(_url, _userName, _password, configurationToken));
            return result.Success ? (OnvifClientResult<VideoAnalyticsConfiguration>)new OnvifClientResultData<VideoAnalyticsConfiguration>(result.WorkItem)
                : new OnvifClientResultEmpty<VideoAnalyticsConfiguration>(new VideoAnalyticsConfiguration());
        }

        public OnvifClientResult<VideoAnalyticsConfiguration> GetVideoAnalyticsConfiguration(string configurationToken)
        {
            return GetVideoAnalyticsConfiguration(_url, _userName, _password, configurationToken);
        }

        public OnvifClientResult<VideoAnalyticsConfiguration> GetVideoAnalyticsConfiguration(string url, string userName, string password, string configurationToken)
        {
            var result = _proxyActor.Ask<Container<VideoAnalyticsConfiguration>>(new OnvifGetVideoAnalyticsConfiguration(url, userName, password, configurationToken)).Result;
            return result.Success ? (OnvifClientResult<VideoAnalyticsConfiguration>)new OnvifClientResultData<VideoAnalyticsConfiguration>(result.WorkItem)
                : new OnvifClientResultEmpty<VideoAnalyticsConfiguration>(new VideoAnalyticsConfiguration());
        }

        public async Task<OnvifClientResult<AnalyticsEngineInput[]>> CreateAnalyticsEngineInputsAsync(AnalyticsEngineInput[] configuration, bool[] forcePersistent)
        {
            var result = await _proxyActor.Ask<Container<AnalyticsEngineInput[]>>(new OnvifCreateAnalyticsEngineInputs(_url,
                        _userName, _password, configuration, forcePersistent));

            return result.Success ? (OnvifClientResult<AnalyticsEngineInput[]>)new OnvifClientResultData<AnalyticsEngineInput[]>(result.WorkItem)
                : new OnvifClientResultEmpty<AnalyticsEngineInput[]>(new AnalyticsEngineInput[0]);
        }

        public OnvifClientResult<AnalyticsEngineInput[]> CreateAnalyticsEngineInputs(AnalyticsEngineInput[] configuration, bool[] forcePersistent)
        {
            return CreateAnalyticsEngineInputs(_url, _userName, _password, configuration, forcePersistent);
        }

        public OnvifClientResult<AnalyticsEngineInput[]> CreateAnalyticsEngineInputs(string url, string userName, string password, AnalyticsEngineInput[] configuration, bool[] forcePersistent)
        {
            var result = _proxyActor.Ask<Container<AnalyticsEngineInput[]>>(new OnvifCreateAnalyticsEngineInputs(url, userName, password, configuration, forcePersistent)).Result;

            return result.Success ? (OnvifClientResult<AnalyticsEngineInput[]>)new OnvifClientResultData<AnalyticsEngineInput[]>(result.WorkItem)
                : new OnvifClientResultEmpty<AnalyticsEngineInput[]>(new AnalyticsEngineInput[0]);
        }

        public async Task<OnvifResult> DeleteAnalyticsEngineInputsAsync(string[] configurationToken)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifDeleteAnalyticsEngineInputs(_url, _userName, _password, configurationToken));
        }

        public OnvifResult DeleteAnalyticsEngineInputs(string[] configurationToken)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifDeleteAnalyticsEngineInputs(_url, _userName, _password, configurationToken)).Result;
        }

        public OnvifResult DeleteAnalyticsEngineInputs(string url, string userName, string password, string[] configurationToken)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifDeleteAnalyticsEngineInputs(url, userName, password, configurationToken)).Result;
        }

        public async Task<OnvifClientResult<AnalyticsStateInformation>> GetAnalyticsStateAsync(string analyticsEngineControlToken)
        {
            var result = await _proxyActor.Ask<Container<AnalyticsStateInformation>>(new OnvifGetAnalyticsState(_url, _userName, _password, analyticsEngineControlToken));
            return result.Success ? (OnvifClientResult<AnalyticsStateInformation>)new OnvifClientResultData<AnalyticsStateInformation>(result.WorkItem)
                : new OnvifClientResultEmpty<AnalyticsStateInformation>(new AnalyticsStateInformation());
        }

        public OnvifClientResult<AnalyticsStateInformation> GetAnalyticsState(string analyticsEngineControlToken)
        {
            return GetAnalyticsState(_url, _userName, _password, analyticsEngineControlToken);
        }

        public OnvifClientResult<AnalyticsStateInformation> GetAnalyticsState(string url, string userName, string password, string analyticsEngineControlToken)
        {
            var result = _proxyActor.Ask<Container<AnalyticsStateInformation>>(new OnvifGetAnalyticsState(url, userName, password, analyticsEngineControlToken)).Result;
            return result.Success ? (OnvifClientResult<AnalyticsStateInformation>)new OnvifClientResultData<AnalyticsStateInformation>(result.WorkItem)
                : new OnvifClientResultEmpty<AnalyticsStateInformation>(new AnalyticsStateInformation());
        }

        public async Task<OnvifResult> CreateAnalyticsModulesAsync(string vacToken, Config[] analytycsModules)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifCreateAnalyticsModules(_url, _userName, _password, vacToken, analytycsModules));
        }

        public OnvifResult CreateAnalyticsModules(string vacToken, Config[] analytycsModules)
        {
            return CreateAnalyticsModules(_url, _userName, _password, vacToken, analytycsModules);
        }

        public OnvifResult CreateAnalyticsModules(string url, string userName, string password, string vacToken, Config[] analytycsModules)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifCreateAnalyticsModules(url, userName, password, vacToken, analytycsModules)).Result;
        }

        public async Task<OnvifResult> DeleteAnalyticsModulesAsync(string vacToken, string[] analytycModuleNames)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifDeleteAnalyticsModules(_url, _userName, _password, vacToken, analytycModuleNames));
        }

        public OnvifResult DeleteAnalyticsModules(string vacToken, string[] analytycModuleNames)
        {
            return DeleteAnalyticsModules(_url, _userName, _password, vacToken, analytycModuleNames);
        }

        public OnvifResult DeleteAnalyticsModules(string url, string userName, string password, string vacToken, string[] analytycModuleNames)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifDeleteAnalyticsModules(url, userName, password, vacToken, analytycModuleNames)).Result;
        }

        public async Task<OnvifClientResult<Config[]>> GetAnalyticsModulesAsync(string vacToken)
        {
            var result = await _proxyActor.Ask<Container<Config[]>>(new OnvifGetAnalyticsModules(_url, _userName, _password, vacToken));
            return result.Success ? (OnvifClientResult<Config[]>)new OnvifClientResultData<Config[]>(result.WorkItem)
                : new OnvifClientResultEmpty<Config[]>(new Config[0]);
        }

        public OnvifClientResult<Config[]> GetAnalyticsModules(string vacToken)
        {
            return GetAnalyticsModules(_url, _userName, _password, vacToken);
        }

        public OnvifClientResult<Config[]> GetAnalyticsModules(string url, string userName, string password, string vacToken)
        {
            var result = _proxyActor.Ask<Container<Config[]>>(new OnvifGetAnalyticsModules(url, userName, password, vacToken)).Result;
            return result.Success ? (OnvifClientResult<Config[]>)new OnvifClientResultData<Config[]>(result.WorkItem)
                : new OnvifClientResultEmpty<Config[]>(new Config[0]);
        }

        public async Task<OnvifResult> ModifyAnalyticsModulesAsync(string vacToken, Config[] analytycsModules)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifModifyAnalyticsModules(_url, _userName, _password, vacToken, analytycsModules));
        }

        public OnvifResult ModifyAnalyticsModules(string vacToken, Config[] analytycsModules)
        {
            return ModifyAnalyticsModules(_url, _userName, _password, vacToken, analytycsModules);
        }

        public OnvifResult ModifyAnalyticsModules(string url, string userName, string password, string vacToken, Config[] analytycsModules)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifModifyAnalyticsModules(url, userName, password, vacToken, analytycsModules)).Result;
        }

        public async Task<OnvifClientResult<AnalyticsEngineControl[]>> GetAnalyticsEngineControlsAsync()
        {
            var result = await _proxyActor.Ask<Container<AnalyticsEngineControl[]>>(new OnvifGetAnalyticsEngineControls(_url, _userName, _password));
            return result.Success ? (OnvifClientResult<AnalyticsEngineControl[]>)new OnvifClientResultData<AnalyticsEngineControl[]>(result.WorkItem)
                : new OnvifClientResultEmpty<AnalyticsEngineControl[]>(new AnalyticsEngineControl[0]);
        }

        public OnvifClientResult<AnalyticsEngineControl[]> GetAnalyticsEngineControls()
        {
            return GetAnalyticsEngineControls(_url, _userName, _password);
        }

        public OnvifClientResult<AnalyticsEngineControl[]> GetAnalyticsEngineControls(string url, string userName, string password)
        {
            var result = _proxyActor.Ask<Container<AnalyticsEngineControl[]>>(new OnvifGetAnalyticsEngineControls(url, userName, password)).Result;
            return result.Success ? (OnvifClientResult<AnalyticsEngineControl[]>)new OnvifClientResultData<AnalyticsEngineControl[]>(result.WorkItem)
                : new OnvifClientResultEmpty<AnalyticsEngineControl[]>(new AnalyticsEngineControl[0]);
        }

        public async Task<OnvifClientResult<AnalyticsEngine[]>> GetAnalyticsEnginesAsync()
        {
            var result = await _proxyActor.Ask<Container<AnalyticsEngine[]>>(new OnvifGetAnalyticsEngines(_url, _userName, _password));
            return result.Success ? (OnvifClientResult<AnalyticsEngine[]>)new OnvifClientResultData<AnalyticsEngine[]>(result.WorkItem)
                : new OnvifClientResultEmpty<AnalyticsEngine[]>(new AnalyticsEngine[0]);
        }

        public OnvifClientResult<AnalyticsEngine[]> GetAnalyticsEngines()
        {
            return GetAnalyticsEngines(_url, _userName, _password);
        }

        public OnvifClientResult<AnalyticsEngine[]> GetAnalyticsEngines(string url, string userName, string password)
        {
            var result = _proxyActor.Ask<Container<AnalyticsEngine[]>>(new OnvifGetAnalyticsEngines(url, userName, password)).Result;
            return result.Success ? (OnvifClientResult<AnalyticsEngine[]>)new OnvifClientResultData<AnalyticsEngine[]>(result.WorkItem)
                : new OnvifClientResultEmpty<AnalyticsEngine[]>(new AnalyticsEngine[0]);
        }

        public async Task<OnvifClientResult<AnalyticsEngine>> GetAnalyticsEngineAsync(string configurationToken)
        {
            var result = await _proxyActor.Ask<Container<AnalyticsEngine>>(new OnvifGetAnalyticsEngine(_url, _userName, _password, configurationToken));
            return result.Success ? (OnvifClientResult<AnalyticsEngine>)new OnvifClientResultData<AnalyticsEngine>(result.WorkItem)
                : new OnvifClientResultEmpty<AnalyticsEngine>(new AnalyticsEngine());
        }

        public OnvifClientResult<AnalyticsEngine> GetAnalyticsEngine(string configurationToken)
        {
            return GetAnalyticsEngine(_url, _userName, _password, configurationToken);
        }

        public OnvifClientResult<AnalyticsEngine> GetAnalyticsEngine(string url, string userName, string password, string configurationToken)
        {
            var result = _proxyActor.Ask<Container<AnalyticsEngine>>(new OnvifGetAnalyticsEngine(url, userName, password, configurationToken)).Result;
            return result.Success ? (OnvifClientResult<AnalyticsEngine>)new OnvifClientResultData<AnalyticsEngine>(result.WorkItem)
                : new OnvifClientResultEmpty<AnalyticsEngine>(new AnalyticsEngine());
        }

        public async Task<OnvifClientResult<AnalyticsEngineInput[]>> CreateAnalyticsEngineControlAsync(AnalyticsEngineControl configuration)
        {
            var result = await _proxyActor.Ask<Container<AnalyticsEngineInput[]>>(new OnvifCreateAnalyticsEngineControl(_url, _userName, _password, configuration));

            return result.Success ? (OnvifClientResult<AnalyticsEngineInput[]>)new OnvifClientResultData<AnalyticsEngineInput[]>(result.WorkItem)
                : new OnvifClientResultEmpty<AnalyticsEngineInput[]>(new AnalyticsEngineInput[0]);
        }

        public OnvifClientResult<AnalyticsEngineInput[]> CreateAnalyticsEngineControl(AnalyticsEngineControl configuration)
        {
            return CreateAnalyticsEngineControl(_url, _userName, _password, configuration);
        }

        public OnvifClientResult<AnalyticsEngineInput[]> CreateAnalyticsEngineControl(string url, string userName, string password, AnalyticsEngineControl configuration)
        {
            var result = _proxyActor.Ask<Container<AnalyticsEngineInput[]>>(new OnvifCreateAnalyticsEngineControl(url, userName, password, configuration)).Result;

            return result.Success ? (OnvifClientResult<AnalyticsEngineInput[]>)new OnvifClientResultData<AnalyticsEngineInput[]>(result.WorkItem)
                : new OnvifClientResultEmpty<AnalyticsEngineInput[]>(new AnalyticsEngineInput[0]);
        }


        public async Task<OnvifResult> SetAnalyticsEngineControlAsync(AnalyticsEngineControl configuration, bool forcePersitent)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifSetAnalyticsEngineControl(_url, _userName, _password, configuration, forcePersitent));
        }

        public OnvifResult SetAnalyticsEngineControl(AnalyticsEngineControl configuration, bool forcePersitent)
        {
            return SetAnalyticsEngineControl(_url, _userName, _password, configuration, forcePersitent);
        }

        public OnvifResult SetAnalyticsEngineControl(string url, string userName, string password, AnalyticsEngineControl configuration, bool forcePersitent)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifSetAnalyticsEngineControl(url, userName, password, configuration, forcePersitent)).Result;
        }

        public async Task<OnvifResult> DeleteAnalyticsEngineControlAsync(string configurationToken)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifDeleteAnalyticsEngineControl(_url, _userName, _password, configurationToken));
        }

        public OnvifResult DeleteAnalyticsEngineControl(string configurationToken)
        {
            return DeleteAnalyticsEngineControl(_url, _userName, _password, configurationToken);
        }

        public OnvifResult DeleteAnalyticsEngineControl(string url, string userName, string password, string configurationToken)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifDeleteAnalyticsEngineControl(url, userName, password, configurationToken)).Result;
        }

        public async Task<OnvifClientResult<AnalyticsEngineControl>> GetAnalyticsEngineControlAsync(string configurationToken)
        {
            var result = await _proxyActor.Ask<Container<AnalyticsEngineControl>>(new OnvifGetAnalyticsEngineControl(_url, _userName, _password, configurationToken));
            return result.Success ? (OnvifClientResult<AnalyticsEngineControl>)new OnvifClientResultData<AnalyticsEngineControl>(result.WorkItem)
                : new OnvifClientResultEmpty<AnalyticsEngineControl>(new AnalyticsEngineControl());
        }

        public OnvifClientResult<AnalyticsEngineControl> GetAnalyticsEngineControl(string configurationToken)
        {
            return GetAnalyticsEngineControl(_url, _userName, _password, configurationToken);
        }

        public OnvifClientResult<AnalyticsEngineControl> GetAnalyticsEngineControl(string url, string userName, string password, string configurationToken)
        {
            var result = _proxyActor.Ask<Container<AnalyticsEngineControl>>(new OnvifGetAnalyticsEngineControl(url, userName, password, configurationToken)).Result;
            return result.Success ? (OnvifClientResult<AnalyticsEngineControl>)new OnvifClientResultData<AnalyticsEngineControl>(result.WorkItem)
                : new OnvifClientResultEmpty<AnalyticsEngineControl>(new AnalyticsEngineControl());
        }

        public async Task<OnvifClientResult<AnalyticsEngineInput[]>> GetAnalyticsEngineInputsAsync()
        {
            var result = await _proxyActor.Ask<Container<AnalyticsEngineInput[]>>(new OnvifGetAnalyticsEngineInputs(_url, _userName, _password));
            return result.Success ? (OnvifClientResult<AnalyticsEngineInput[]>)new OnvifClientResultData<AnalyticsEngineInput[]>(result.WorkItem)
                : new OnvifClientResultEmpty<AnalyticsEngineInput[]>(new AnalyticsEngineInput[0]);
        }

        public OnvifClientResult<AnalyticsEngineInput[]> GetAnalyticsEngineInputs()
        {
            return GetAnalyticsEngineInputs(_url, _userName, _password);
        }

        public OnvifClientResult<AnalyticsEngineInput[]> GetAnalyticsEngineInputs(string url, string userName, string password)
        {
            var result = _proxyActor.Ask<Container<AnalyticsEngineInput[]>>(new OnvifGetAnalyticsEngineInputs(url, userName, password)).Result;
            return result.Success ? (OnvifClientResult<AnalyticsEngineInput[]>)new OnvifClientResultData<AnalyticsEngineInput[]>(result.WorkItem)
                : new OnvifClientResultEmpty<AnalyticsEngineInput[]>(new AnalyticsEngineInput[0]);
        }

        public async Task<OnvifResult> SetAnalyticsEngineInputAsync(AnalyticsEngineInput configuration, bool forcePersitent)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifSetAnalyticsEngineInput(_url, _userName, _password, configuration, forcePersitent));
        }

        public OnvifResult SetAnalyticsEngineInput(AnalyticsEngineInput configuration, bool forcePersitent)
        {
            return SetAnalyticsEngineInput(_url, _userName, _password, configuration, forcePersitent);
        }

        public OnvifResult SetAnalyticsEngineInput(string url, string userName, string password, AnalyticsEngineInput configuration, bool forcePersitent)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifSetAnalyticsEngineInput(url, userName, password, configuration, forcePersitent)).Result;
        }
    }
}
