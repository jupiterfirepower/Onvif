using System;
using System.Threading.Tasks;
using onvif.services;

namespace Onvif.Proxy.Contracts.Contract
{
    public interface IOnvifRecording
    {
        Task<GetRecordingsResponseItem[]> GetRecordingsAsync();
        Task<string> CreateRecordingAsync(RecordingConfiguration configuration);
        Task DeleteRecordingAsync(string recordingToken);
        Task<RecordingConfiguration> GetRecordingConfigurationAsync(string recordingToken);
        Task SetRecordingConfigurationAsync(string recordingToken, RecordingConfiguration config);
        Task DeleteTrackAsync(string recordingToken, string trackToken);
        Task<TrackConfiguration> GetTrackConfigurationAsync(string recordingToken, string trackToken);
        Task SetTrackConfigurationAsync(string recordingToken, string trackToken, TrackConfiguration config);
        Task<Tuple<string, RecordingJobConfiguration>> CreateRecordingJobAsync(RecordingJobConfiguration config);
        Task DeleteRecordingJobAsync(string jobToken);
        Task<GetRecordingJobsResponseItem[]> GetRecordingJobsAsync();
        Task<RecordingJobConfiguration> SetRecordingJobConfigurationAsync(string jobToken, RecordingJobConfiguration config);
        Task<RecordingJobConfiguration> GetRecordingJobConfigurationAsync(string jobToken);
        Task SetRecordingJobModeAsync(string jobToken, string mode);
        Task<RecordingJobStateInformation> GetRecordingJobStateAsync(string jobToken);

        GetRecordingsResponseItem[] GetRecordings();
        string CreateRecording(RecordingConfiguration configuration);
        void DeleteRecording(string recordingToken);
        RecordingConfiguration GetRecordingConfiguration(string recordingToken);
        void SetRecordingConfiguration(string recordingToken, RecordingConfiguration config);
        void DeleteTrack(string recordingToken, string trackToken);
        TrackConfiguration GetTrackConfiguration(string recordingToken, string trackToken);
        void SetTrackConfiguration(string recordingToken, string trackToken, TrackConfiguration config);
        Tuple<string, RecordingJobConfiguration> CreateRecordingJob(RecordingJobConfiguration config);
        void DeleteRecordingJob(string jobToken);
        GetRecordingJobsResponseItem[] GetRecordingJobs();
        RecordingJobConfiguration SetRecordingJobConfiguration(string jobToken, RecordingJobConfiguration config);
        RecordingJobConfiguration GetRecordingJobConfiguration(string jobToken);
        void SetRecordingJobMode(string jobToken, string mode);
        RecordingJobStateInformation GetRecordingJobState(string jobToken);
    }
}
