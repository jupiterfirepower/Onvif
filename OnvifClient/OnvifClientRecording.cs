using System;
using System.Threading.Tasks;
using Akka.Actor;
using onvif.services;
using Onvif.Camera.Client.Model;
using Onvif.Contracts.Messages.Onvif;
using Onvif.Contracts.Messages.Onvif.Recording;
using Onvif.Contracts.Model;

namespace Onvif.Camera.Client
{
    public partial class OnvifClient
    {
        public async Task<OnvifClientResult<GetRecordingsResponseItem[]>> GetRecordingsAsync()
        {
            var result = await _proxyActor.Ask<Container<GetRecordingsResponseItem[]>>(new OnvifGetRecordings(_url, _userName, _password));
            return result.Success ? (OnvifClientResult<GetRecordingsResponseItem[]>)new OnvifClientResultData<GetRecordingsResponseItem[]>(result.WorkItem)
                : new OnvifClientResultEmpty<GetRecordingsResponseItem[]>(new GetRecordingsResponseItem[0]);
        }

        public OnvifClientResult<GetRecordingsResponseItem[]> GetRecordings()
        {
            return GetRecordings(_url, _userName, _password);
        }

        public OnvifClientResult<GetRecordingsResponseItem[]> GetRecordings(string url, string userName, string password)
        {
            var result = _proxyActor.Ask<Container<GetRecordingsResponseItem[]>>(new OnvifGetRecordings(url, userName, password)).Result;
            return result.Success ? (OnvifClientResult<GetRecordingsResponseItem[]>)new OnvifClientResultData<GetRecordingsResponseItem[]>(result.WorkItem)
                : new OnvifClientResultEmpty<GetRecordingsResponseItem[]>(new GetRecordingsResponseItem[0]);
        }

        public async Task<OnvifClientResult<string>> CreateRecordingAsync(RecordingConfiguration configuration)
        {
            var result = await _proxyActor.Ask<Container<string>>(new OnvifCreateRecording(_url, _userName, _password, configuration));
            return result.Success ? (OnvifClientResult<string>)new OnvifClientResultData<string>(result.WorkItem)
                : new OnvifClientResultEmpty<string>(string.Empty);
        }

        public OnvifClientResult<string> CreateRecording(RecordingConfiguration configuration)
        {
            return CreateRecording(_url, _userName, _password, configuration);
        }

        public OnvifClientResult<string> CreateRecording(string url, string userName, string password, RecordingConfiguration configuration)
        {
            var result = _proxyActor.Ask<Container<string>>(new OnvifCreateRecording(url, userName, password, configuration)).Result;
            return result.Success ? (OnvifClientResult<string>)new OnvifClientResultData<string>(result.WorkItem)
                : new OnvifClientResultEmpty<string>(string.Empty);
        }

        public async Task<OnvifResult> DeleteRecordingAsync(string recordingToken)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifDeleteRecording(_url, _userName, _password, recordingToken));
        }

        public OnvifResult DeleteRecording(string recordingToken)
        {
            return DeleteRecording(_url, _userName, _password, recordingToken);
        }

        public OnvifResult DeleteRecording(string url, string userName, string password, string recordingToken)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifDeleteRecording(url, userName, password, recordingToken)).Result;
        }

        public async Task<OnvifClientResult<RecordingConfiguration>> GetRecordingConfigurationAsync(string recordingToken)
        {
            var result = await _proxyActor.Ask<Container<RecordingConfiguration>>(new OnvifGetRecordingConfiguration(_url, _userName, _password, recordingToken));
            return result.Success ? (OnvifClientResult<RecordingConfiguration>)new OnvifClientResultData<RecordingConfiguration>(result.WorkItem)
                : new OnvifClientResultEmpty<RecordingConfiguration>(new RecordingConfiguration());
        }

        public OnvifClientResult<RecordingConfiguration> GetRecordingConfiguration(string recordingToken)
        {
            return GetRecordingConfiguration(_url, _userName, _password, recordingToken);
        }

        public OnvifClientResult<RecordingConfiguration> GetRecordingConfiguration(string url, string userName, string password, string recordingToken)
        {
            var result = _proxyActor.Ask<Container<RecordingConfiguration>>(new OnvifGetRecordingConfiguration(url, userName, password, recordingToken)).Result;
            return result.Success ? (OnvifClientResult<RecordingConfiguration>)new OnvifClientResultData<RecordingConfiguration>(result.WorkItem)
                : new OnvifClientResultEmpty<RecordingConfiguration>(new RecordingConfiguration());
        }

        public async Task<OnvifResult> SetRecordingConfigurationAsync(string recordingToken, RecordingConfiguration config)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifSetRecordingConfiguration(_url, _userName, _password, recordingToken, config));
        }

        public OnvifResult SetRecordingConfiguration(string recordingToken, RecordingConfiguration config)
        {
            return SetRecordingConfiguration(_url, _userName, _password, recordingToken, config);
        }

        public OnvifResult SetRecordingConfiguration(string url, string userName, string password, string recordingToken, RecordingConfiguration config)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifSetRecordingConfiguration(url, userName, password, recordingToken, config)).Result;
        }

        public async Task<OnvifResult> DeleteTrackAsync(string recordingToken, string trackToken)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifDeleteTrack(_url, _userName, _password, recordingToken, trackToken));
        }

        public OnvifResult DeleteTrack(string recordingToken, string trackToken)
        {
            return DeleteTrack(_url, _userName, _password, recordingToken, trackToken);
        }

        public OnvifResult DeleteTrack(string url, string userName, string password, string recordingToken, string trackToken)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifDeleteTrack(url, userName, password, recordingToken, trackToken)).Result;
        }

        public async Task<OnvifClientResult<TrackConfiguration>> GetTrackConfigurationAsync(string recordingToken, string trackToken)
        {
            var result = await _proxyActor.Ask<Container<TrackConfiguration>>(new OnvifGetTrackConfiguration(_url, _userName, _password, recordingToken, trackToken));
            return result.Success ? (OnvifClientResult<TrackConfiguration>)new OnvifClientResultData<TrackConfiguration>(result.WorkItem)
                : new OnvifClientResultEmpty<TrackConfiguration>(new TrackConfiguration());
        }

        public OnvifClientResult<TrackConfiguration> GetTrackConfiguration(string recordingToken, string trackToken)
        {
            return GetTrackConfiguration(_url, _userName, _password, recordingToken, trackToken);
        }

        public OnvifClientResult<TrackConfiguration> GetTrackConfiguration(string url, string userName, string password, string recordingToken, string trackToken)
        {
            var result = _proxyActor.Ask<Container<TrackConfiguration>>(new OnvifGetTrackConfiguration(url, userName, password, recordingToken, trackToken)).Result;
            return result.Success ? (OnvifClientResult<TrackConfiguration>)new OnvifClientResultData<TrackConfiguration>(result.WorkItem)
                : new OnvifClientResultEmpty<TrackConfiguration>(new TrackConfiguration());
        }

        public async Task<OnvifResult> SetTrackConfigurationAsync(string recordingToken, string trackToken, TrackConfiguration config)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifSetTrackConfiguration(_url, _userName, _password, recordingToken, trackToken, config));
        }

        public OnvifResult SetTrackConfiguration(string recordingToken, string trackToken, TrackConfiguration config)
        {
            return SetTrackConfiguration(_url, _userName, _password, recordingToken, trackToken, config);
        }

        public OnvifResult SetTrackConfiguration(string url, string userName, string password, string recordingToken, string trackToken, TrackConfiguration config)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifSetTrackConfiguration(url, userName, password, recordingToken, trackToken, config)).Result;
        }

        public async Task<OnvifClientResult<Tuple<string, RecordingJobConfiguration>>> CreateRecordingJobAsync(RecordingJobConfiguration config)
        {
            var result = await _proxyActor.Ask<Container<Tuple<string, RecordingJobConfiguration>>>(new OnvifCreateRecordingJob(_url, _userName, _password, config));
            return result.Success ? (OnvifClientResult<Tuple<string, RecordingJobConfiguration>>)new OnvifClientResultData<Tuple<string, RecordingJobConfiguration>>(result.WorkItem)
                : new OnvifClientResultEmpty<Tuple<string, RecordingJobConfiguration>>(Tuple.Create(string.Empty, new RecordingJobConfiguration()));
        }

        public OnvifClientResult<Tuple<string, RecordingJobConfiguration>> CreateRecordingJob(RecordingJobConfiguration config)
        {
            return CreateRecordingJob(_url, _userName, _password, config);
        }

        public OnvifClientResult<Tuple<string, RecordingJobConfiguration>> CreateRecordingJob(string url, string userName, string password, RecordingJobConfiguration config)
        {
            var result = _proxyActor.Ask<Container<Tuple<string, RecordingJobConfiguration>>>(new OnvifCreateRecordingJob(url, userName, password, config)).Result;
            return result.Success ? (OnvifClientResult<Tuple<string, RecordingJobConfiguration>>)new OnvifClientResultData<Tuple<string, RecordingJobConfiguration>>(result.WorkItem)
                : new OnvifClientResultEmpty<Tuple<string, RecordingJobConfiguration>>(Tuple.Create(string.Empty, new RecordingJobConfiguration()));
        }

        public async Task<OnvifResult> DeleteRecordingJobAsync(string jobToken)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifDeleteRecordingJob(_url, _userName, _password, jobToken));
        }

        public OnvifResult DeleteRecordingJob(string jobToken)
        {
            return DeleteRecordingJob(_url, _userName, _password, jobToken);
        }

        public OnvifResult DeleteRecordingJob(string url, string userName, string password, string jobToken)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifDeleteRecordingJob(url, userName, password, jobToken)).Result;
        }

        public async Task<OnvifClientResult<GetRecordingJobsResponseItem[]>> GetRecordingJobsAsync()
        {
            var result = await _proxyActor.Ask<Container<GetRecordingJobsResponseItem[]>>(new OnvifGetRecordingJobs(_url, _userName, _password));
            return result.Success ? (OnvifClientResult<GetRecordingJobsResponseItem[]>)new OnvifClientResultData<GetRecordingJobsResponseItem[]>(result.WorkItem)
                : new OnvifClientResultEmpty<GetRecordingJobsResponseItem[]>(new GetRecordingJobsResponseItem[0]);
        }

        public OnvifClientResult<GetRecordingJobsResponseItem[]> GetRecordingJobs()
        {
            return GetRecordingJobs(_url, _userName, _password);
        }

        public OnvifClientResult<GetRecordingJobsResponseItem[]> GetRecordingJobs(string url, string userName, string password)
        {
            var result = _proxyActor.Ask<Container<GetRecordingJobsResponseItem[]>>(new OnvifGetRecordingJobs(url, userName, password)).Result;
            return result.Success ? (OnvifClientResult<GetRecordingJobsResponseItem[]>)new OnvifClientResultData<GetRecordingJobsResponseItem[]>(result.WorkItem)
                : new OnvifClientResultEmpty<GetRecordingJobsResponseItem[]>(new GetRecordingJobsResponseItem[0]);
        }

        public async Task<OnvifClientResult<RecordingJobConfiguration>> SetRecordingJobConfigurationAsync(string jobToken, RecordingJobConfiguration config)
        {
            var result = await _proxyActor.Ask<Container<RecordingJobConfiguration>>(new OnvifSetRecordingJobConfiguration(_url, _userName, _password, jobToken, config));
            return result.Success ? (OnvifClientResult<RecordingJobConfiguration>)new OnvifClientResultData<RecordingJobConfiguration>(result.WorkItem)
                : new OnvifClientResultEmpty<RecordingJobConfiguration>(new RecordingJobConfiguration());
        }

        public OnvifClientResult<RecordingJobConfiguration> SetRecordingJobConfiguration(string jobToken, RecordingJobConfiguration config)
        {
            return SetRecordingJobConfiguration(_url, _userName, _password, jobToken, config);
        }

        public OnvifClientResult<RecordingJobConfiguration> SetRecordingJobConfiguration(string url, string userName, string password, string jobToken, RecordingJobConfiguration config)
        {
            var result = _proxyActor.Ask<Container<RecordingJobConfiguration>>(new OnvifSetRecordingJobConfiguration(url, userName, password, jobToken, config)).Result;
            return result.Success ? (OnvifClientResult<RecordingJobConfiguration>)new OnvifClientResultData<RecordingJobConfiguration>(result.WorkItem)
                : new OnvifClientResultEmpty<RecordingJobConfiguration>(new RecordingJobConfiguration());
        }

        public async Task<OnvifClientResult<RecordingJobConfiguration>> GetRecordingJobConfigurationAsync(string jobToken)
        {
            var result = await _proxyActor.Ask<Container<RecordingJobConfiguration>>(new OnvifGetRecordingJobConfiguration(_url, _userName, _password, jobToken));
            return result.Success ? (OnvifClientResult<RecordingJobConfiguration>)new OnvifClientResultData<RecordingJobConfiguration>(result.WorkItem)
                : new OnvifClientResultEmpty<RecordingJobConfiguration>(new RecordingJobConfiguration());
        }

        public OnvifClientResult<RecordingJobConfiguration> GetRecordingJobConfiguration(string jobToken)
        {
            return GetRecordingJobConfiguration(_url, _userName, _password, jobToken);
        }

        public OnvifClientResult<RecordingJobConfiguration> GetRecordingJobConfiguration(string url, string userName, string password, string jobToken)
        {
            var result = _proxyActor.Ask<Container<RecordingJobConfiguration>>(new OnvifGetRecordingJobConfiguration(url, userName, password, jobToken)).Result;
            return result.Success ? (OnvifClientResult<RecordingJobConfiguration>)new OnvifClientResultData<RecordingJobConfiguration>(result.WorkItem)
                : new OnvifClientResultEmpty<RecordingJobConfiguration>(new RecordingJobConfiguration());
        }

        public async Task<OnvifResult> SetRecordingJobModeAsync(string jobToken, string mode)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifSetRecordingJobMode(_url, _userName, _password, jobToken, mode));
        }

        public OnvifResult SetRecordingJobMode(string jobToken, string mode)
        {
            return SetRecordingJobMode(_url, _userName, _password, jobToken, mode);
        }

        public OnvifResult SetRecordingJobMode(string url, string userName, string password, string jobToken, string mode)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifSetRecordingJobMode(url, userName, password, jobToken, mode)).Result;
        }

        public async Task<OnvifClientResult<RecordingJobStateInformation>> GetRecordingJobStateAsync(string jobToken)
        {
            var result = await _proxyActor.Ask<Container<RecordingJobStateInformation>>(new OnvifGetRecordingJobState(_url, _userName, _password, jobToken));
            return result.Success ? (OnvifClientResult<RecordingJobStateInformation>)new OnvifClientResultData<RecordingJobStateInformation>(result.WorkItem)
                : new OnvifClientResultEmpty<RecordingJobStateInformation>(new RecordingJobStateInformation());
        }

        public OnvifClientResult<RecordingJobStateInformation> GetRecordingJobState(string jobToken)
        {
            return GetRecordingJobState(_url, _userName, _password, jobToken);
        }

        public OnvifClientResult<RecordingJobStateInformation> GetRecordingJobState(string url, string userName, string password, string jobToken)
        {
            var result = _proxyActor.Ask<Container<RecordingJobStateInformation>>(new OnvifGetRecordingJobState(url, userName, password, jobToken)).Result;
            return result.Success ? (OnvifClientResult<RecordingJobStateInformation>)new OnvifClientResultData<RecordingJobStateInformation>(result.WorkItem)
                : new OnvifClientResultEmpty<RecordingJobStateInformation>(new RecordingJobStateInformation());
        }
    }
}
