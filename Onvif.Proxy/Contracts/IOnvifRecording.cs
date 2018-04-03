using System;
using System.Threading.Tasks;
using onvif.services;

namespace Onvif.Proxy.Contracts
{
    public interface IOnvifRecording
    {
        Task<GetRecordingsResponseItem[]> GetRecordings();

        Task<string> CreateRecording(RecordingConfiguration configuration);

        Task DeleteRecording(string recordingToken);

        Task<RecordingConfiguration> GetRecordingConfiguration(string recordingToken);

        Task SetRecordingConfiguration(string recordingToken, RecordingConfiguration config);

        Task DeleteTrack(string recordingToken, string trackToken);

        Task<TrackConfiguration> GetTrackConfiguration(string recordingToken, string trackToken);

        Task SetTrackConfiguration(string recordingToken, string trackToken, TrackConfiguration config);

        Task<Tuple<string, RecordingJobConfiguration>> CreateRecordingJob(RecordingJobConfiguration config);

        Task DeleteRecordingJob(string jobToken);

        Task<GetRecordingJobsResponseItem[]> GetRecordingJobs();

        Task<RecordingJobConfiguration> SetRecordingJobConfiguration(string jobToken, RecordingJobConfiguration config);

        Task<RecordingJobConfiguration> GetRecordingJobConfiguration(string jobToken);

        Task SetRecordingJobMode(string jobToken, string mode);

        Task<RecordingJobStateInformation> GetRecordingJobState(string jobToken);
    }
}
