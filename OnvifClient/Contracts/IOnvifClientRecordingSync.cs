using System;
using onvif.services;
using Onvif.Camera.Client.Model;
using Onvif.Contracts.Messages.Onvif;

namespace Onvif.Camera.Client.Contracts
{
    public interface IOnvifClientRecordingSync
    {
        OnvifClientResult<GetRecordingsResponseItem[]> GetRecordings();
        OnvifClientResult<string> CreateRecording(RecordingConfiguration configuration);
        OnvifResult DeleteRecording(string recordingToken);
        OnvifClientResult<RecordingConfiguration> GetRecordingConfiguration(string recordingToken);
        OnvifResult SetRecordingConfiguration(string recordingToken, RecordingConfiguration config);
        OnvifResult DeleteTrack(string recordingToken, string trackToken);
        OnvifClientResult<TrackConfiguration> GetTrackConfiguration(string recordingToken, string trackToken);
        OnvifResult SetTrackConfiguration(string recordingToken, string trackToken, TrackConfiguration config);
        OnvifClientResult<Tuple<string, RecordingJobConfiguration>> CreateRecordingJob(RecordingJobConfiguration config);
        OnvifResult DeleteRecordingJob(string jobToken);
        OnvifClientResult<GetRecordingJobsResponseItem[]> GetRecordingJobs();
        OnvifClientResult<RecordingJobConfiguration> SetRecordingJobConfiguration(string jobToken, RecordingJobConfiguration config);
        OnvifClientResult<RecordingJobConfiguration> GetRecordingJobConfiguration(string jobToken);
        OnvifResult SetRecordingJobMode(string jobToken, string mode);
        OnvifClientResult<RecordingJobStateInformation> GetRecordingJobState(string jobToken);

        OnvifClientResult<GetRecordingsResponseItem[]> GetRecordings(string url, string userName, string password);
        OnvifClientResult<string> CreateRecording(string url, string userName, string password, RecordingConfiguration configuration);
        OnvifResult DeleteRecording(string url, string userName, string password, string recordingToken);
        OnvifClientResult<RecordingConfiguration> GetRecordingConfiguration(string url, string userName, string password, string recordingToken);
        OnvifResult SetRecordingConfiguration(string url, string userName, string password, string recordingToken, RecordingConfiguration config);
        OnvifResult DeleteTrack(string url, string userName, string password, string recordingToken, string trackToken);
        OnvifClientResult<TrackConfiguration> GetTrackConfiguration(string url, string userName, string password, string recordingToken, string trackToken);
        OnvifResult SetTrackConfiguration(string url, string userName, string password, string recordingToken, string trackToken, TrackConfiguration config);
        OnvifClientResult<Tuple<string, RecordingJobConfiguration>> CreateRecordingJob(string url, string userName, string password, RecordingJobConfiguration config);
        OnvifResult DeleteRecordingJob(string url, string userName, string password, string jobToken);
        OnvifClientResult<GetRecordingJobsResponseItem[]> GetRecordingJobs(string url, string userName, string password);
        OnvifClientResult<RecordingJobConfiguration> SetRecordingJobConfiguration(string url, string userName, string password, string jobToken, RecordingJobConfiguration config);
        OnvifClientResult<RecordingJobConfiguration> GetRecordingJobConfiguration(string url, string userName, string password, string jobToken);
        OnvifResult SetRecordingJobMode(string url, string userName, string password, string jobToken, string mode);
        OnvifClientResult<RecordingJobStateInformation> GetRecordingJobState(string url, string userName, string password, string jobToken);
    }
}
