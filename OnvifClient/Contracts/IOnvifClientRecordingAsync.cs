using System;
using System.Threading.Tasks;
using onvif.services;
using Onvif.Camera.Client.Model;
using Onvif.Contracts.Messages.Onvif;

namespace Onvif.Camera.Client.Contracts
{
    public interface IOnvifClientRecordingAsync
    {
        Task<OnvifClientResult<GetRecordingsResponseItem[]>> GetRecordingsAsync();
        Task<OnvifClientResult<string>> CreateRecordingAsync(RecordingConfiguration configuration);
        Task<OnvifResult> DeleteRecordingAsync(string recordingToken);
        Task<OnvifClientResult<RecordingConfiguration>> GetRecordingConfigurationAsync(string recordingToken);
        Task<OnvifResult> SetRecordingConfigurationAsync(string recordingToken, RecordingConfiguration config);
        Task<OnvifResult> DeleteTrackAsync(string recordingToken, string trackToken);
        Task<OnvifClientResult<TrackConfiguration>> GetTrackConfigurationAsync(string recordingToken, string trackToken);
        Task<OnvifResult> SetTrackConfigurationAsync(string recordingToken, string trackToken, TrackConfiguration config);
        Task<OnvifClientResult<Tuple<string, RecordingJobConfiguration>>> CreateRecordingJobAsync(RecordingJobConfiguration config);
        Task<OnvifResult> DeleteRecordingJobAsync(string jobToken);
        Task<OnvifClientResult<GetRecordingJobsResponseItem[]>> GetRecordingJobsAsync();
        Task<OnvifClientResult<RecordingJobConfiguration>> SetRecordingJobConfigurationAsync(string jobToken, RecordingJobConfiguration config);
        Task<OnvifClientResult<RecordingJobConfiguration>> GetRecordingJobConfigurationAsync(string jobToken);
        Task<OnvifResult> SetRecordingJobModeAsync(string jobToken, string mode);
        Task<OnvifClientResult<RecordingJobStateInformation>> GetRecordingJobStateAsync(string jobToken);
    }
}
