using System;
using Akka.Actor;
using onvif.services;
using Onvif.Camera.Client.Settings;
using Onvif.Contracts.Constants;
using Onvif.Contracts.Enums;
using Onvif.Contracts.Messages;
using Onvif.Contracts.Messages.Onvif;
using Onvif.Contracts.Messages.Onvif.Actions;
using Onvif.Contracts.Messages.Onvif.Analytics;
using Onvif.Contracts.Messages.Onvif.Audio;
using Onvif.Contracts.Messages.Onvif.Certificates;
using Onvif.Contracts.Messages.Onvif.Control;
using Onvif.Contracts.Messages.Onvif.Device;
using Onvif.Contracts.Messages.Onvif.Imaging;
using Onvif.Contracts.Messages.Onvif.Metadata;
using Onvif.Contracts.Messages.Onvif.Network;
using Onvif.Contracts.Messages.Onvif.Profiles;
using Onvif.Contracts.Messages.Onvif.Ptz;
using Onvif.Contracts.Messages.Onvif.Receiver;
using Onvif.Contracts.Messages.Onvif.Recording;
using Onvif.Contracts.Messages.Onvif.Relay;
using Onvif.Contracts.Messages.Onvif.Rules;
using Onvif.Contracts.Messages.Onvif.SystemDate;
using Onvif.Contracts.Messages.Onvif.SystemLog;
using Onvif.Contracts.Messages.Onvif.Users;
using Onvif.Contracts.Messages.Onvif.Video;
using Onvif.Contracts.Model;

namespace Onvif.Camera.Client.Actors
{
    public class OnvifProxyWorkerActor : ReceiveActor
    {
        private readonly ActorSelection _actorSelectionOnvifCoordinator;
        private readonly ActorSelection _actorSelectionOnvifEventCoordinator;

        public OnvifProxyWorkerActor()
        {
            _actorSelectionOnvifCoordinator = Context.System.ActorSelection(string.Format("akka.tcp://{0}@{2}:{3}/user/{1}", 
                Constant.OnvifServerActorSystemName, 
                Constant.OnvifCoordinatorActorName, 
                ClientAppSettings.Server,
                ClientAppSettings.ServerPort
                ));
            _actorSelectionOnvifEventCoordinator = Context.System.ActorSelection(string.Format("akka.tcp://{0}@{2}:{3}/user/{1}", 
                Constant.OnvifServerActorSystemName,
                Constant.OnvifEventCoordinatorActorName,
                ClientAppSettings.Server,
                ClientAppSettings.ServerPort
                ));
            _actorSelectionOnvifEventCoordinator.Tell(new ActorGeneralCommand { Command = ActorCommands.StartActor });
            Become(Handlers); 
        }

        private void GetDataAndReplyPipeToWithTimeOut<T>(object msg) where T : new()
        {
            _actorSelectionOnvifCoordinator.Ask<T>(msg, TimeSpan.FromSeconds(Constant.ClientAskTimeOutSeconds)).
            ContinueWith(tn => (tn.IsCanceled || tn.IsFaulted) ? (T)Activator.CreateInstance(typeof(T)) : tn.IsCompleted ? tn.Result : (T)Activator.CreateInstance(typeof(T))).
            PipeTo(Sender);
        }

        private void ForwardToEventCoordinatorActor(object msg)
        {
            _actorSelectionOnvifEventCoordinator.Tell(msg);
        }

        #region Grouping Handlers
        private void ActionsHandlers()
        {
            Receive<OnvifGetSupportedActions>(msg => GetDataAndReplyPipeToWithTimeOut<Container<SupportedActions>>(msg));
            Receive<OnvifGetActions>(msg => GetDataAndReplyPipeToWithTimeOut<Container<Action1[]>>(msg));
            Receive<OnvifGetActionTriggers>(msg => GetDataAndReplyPipeToWithTimeOut<Container<ActionTrigger[]>>(msg));
            Receive<OnvifCreateActions>(msg => GetDataAndReplyPipeToWithTimeOut<Container<Action1[]>>(msg));
            Receive<OnvifDeleteActions>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifModifyActions>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifCreateActionTriggers>(msg => GetDataAndReplyPipeToWithTimeOut<Container<ActionTrigger[]>>(msg));
            Receive<OnvifDeleteActionTriggers>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifModifyActionTriggers>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
        }

        private void ProfilesHandlers()
        {
            Receive<OnvifGetProfiles>(msg => GetDataAndReplyPipeToWithTimeOut<Container<Profile[]>>(msg));
            Receive<OnvifGetProfile>(msg => GetDataAndReplyPipeToWithTimeOut<Container<Profile>>(msg));
            Receive<OnvifCreateProfile>(msg => GetDataAndReplyPipeToWithTimeOut<Container<Profile>>(msg));
            Receive<OnvifDeleteProfile>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
        }

        private void UsersHandlers()
        {
            Receive<OnvifGetUsers>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifCreateUsers>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifCreateUser>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifDeleteUsers>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifDeleteUser>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifModifyUser>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
        }

        private void CertificatesHandlers()
        {
            Receive<OnvifSetCertificatesStatus>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifDeleteCertificates>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifLoadCertificates>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifGetCertificates>(msg => GetDataAndReplyPipeToWithTimeOut<Container<Certificate[]>>(msg));
            Receive<OnvifGetCertificatesStatus>(msg => GetDataAndReplyPipeToWithTimeOut<Container<CertificateStatus[]>>(msg));
        }

        private void NetworksHandlers()
        {
            Receive<OnvifGetNetworkSettings>(msg => GetDataAndReplyPipeToWithTimeOut<Container<NetworkSettings>>(msg));
            Receive<OnvifGetNetworkInterfaces>(msg => GetDataAndReplyPipeToWithTimeOut<Container<NetworkInterface[]>>(msg));
            Receive<OnvifGetNtp>(msg => GetDataAndReplyPipeToWithTimeOut<Container<NTPInformation>>(msg));
            Receive<OnvifGetHostName>(msg => GetDataAndReplyPipeToWithTimeOut<Container<HostnameInformation>>(msg));
            Receive<OnvifGetNetworkDefaultGateway>(msg => GetDataAndReplyPipeToWithTimeOut<Container<NetworkGateway>>(msg));
            Receive<OnvifGetDns>(msg => GetDataAndReplyPipeToWithTimeOut<Container<DNSInformation>>(msg));
            Receive<OnvifGetNetworkProtocols>(msg => GetDataAndReplyPipeToWithTimeOut<Container<NetworkProtocol[]>>(msg));
            Receive<OnvifGetDiscoveryMode>(msg => GetDataAndReplyPipeToWithTimeOut<Container<DiscoveryMode>>(msg));
            Receive<OnvifSetNetworkSettings>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));

            Receive<OnvifSetNetworkProtocols>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifSetNtp>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifSetDns>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifSetNetworkDefaultGateway>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifSetZeroConfiguration>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifSetHostName>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifSetDiscoveryMode>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifSetNetworkInterfaces>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
        }


        private void SystemDateTimeHandlers()
        {
            Receive<OnvifGetSystemDateTime>(msg => GetDataAndReplyPipeToWithTimeOut<Container<SystemDateTime>>(msg));
            Receive<OnvifSetSystemDateAndTime>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifSyncWithSystem>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifSyncSystemDateTimeWithNtp>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
        }

        private void SystemLogHandlers()
        {
            Receive<OnvifGetSystemLog>(msg => GetDataAndReplyPipeToWithTimeOut<Container<SystemLog>>(msg));
            Receive<OnvifGetSystemLogTypes>(msg => GetDataAndReplyPipeToWithTimeOut<Container<SystemLogType[]>>(msg));
        }

        private void VideoHandlers()
        {
            Receive<OnvifGetVideoSettings>(msg => GetDataAndReplyPipeToWithTimeOut<Container<VideoSettings>>(msg));
            Receive<OnvifSetVideoResolution>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifSetVideoFrameRate>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifSetVideoBitRate>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifSetVideoQuality>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifSetVideoGovLength>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifSetVideoEncodingInterval>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifGetVideoSupportedResolutions>(msg => GetDataAndReplyPipeToWithTimeOut<Container<VideoResolution[]>>(msg));
            Receive<OnvifSetVideoSettings>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifSetVideoEncoderConfiguration>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
        }

        private void DeviceHandlers()
        {
            Receive<OnvifGetWebPageUri>(msg => GetDataAndReplyPipeToWithTimeOut<Container<string>>(msg));
            Receive<OnvifGetDeviceInfo>(msg => GetDataAndReplyPipeToWithTimeOut<Container<DeviceInfo>>(msg));
            Receive<OnvifSetDeviceIdentification>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifSetDeviceName>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifSetDeviceLocation>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifCameraReset>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifCameraReboot>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
        }

        private void EventsHandlers()
        {
            Receive<SubscribeEventsForProcessing>(msg => ForwardToEventCoordinatorActor(msg));
            Receive<UnSubscribeEventsForProcessing>(msg => ForwardToEventCoordinatorActor(msg));
        }

        private void RelayHandlers()
        {
            Receive<OnvifSetRelayOutputSettings>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifSetRelayOutputState>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
        }

        private void PtzHandlers()
        {
            Receive<OnvifPtzIsAbsoluteMoveSupported>(msg => GetDataAndReplyPipeToWithTimeOut<Container<bool>>(msg));
            Receive<OnvifPtzIsRelativeMoveSupported>(msg => GetDataAndReplyPipeToWithTimeOut<Container<bool>>(msg));
            Receive<OnvifPtzIsContinuousMoveSupported>(msg => GetDataAndReplyPipeToWithTimeOut<Container<bool>>(msg));
            Receive<OnvifPtzIsHomeSupported>(msg => GetDataAndReplyPipeToWithTimeOut<Container<bool>>(msg));
            Receive<OnvifPtzIsFixedHomePosition>(msg => GetDataAndReplyPipeToWithTimeOut<Container<bool>>(msg));
            Receive<OnvifPtzIsFixedHomePositionSpecified>(msg => GetDataAndReplyPipeToWithTimeOut<Container<bool>>(msg));
            Receive<OnvifAddPtzConfiguration>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifRemovePtzConfiguration>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifPtzGetNodes>(msg => GetDataAndReplyPipeToWithTimeOut<Container<PTZNode[]>>(msg));
            Receive<OnvifPtzGetNode>(msg => GetDataAndReplyPipeToWithTimeOut<Container<PTZNode>>(msg));
            Receive<OnvifPtzGetConfiguration>(msg => GetDataAndReplyPipeToWithTimeOut<Container<PTZConfiguration>>(msg));
            Receive<OnvifPtzGetConfigurations>(msg => GetDataAndReplyPipeToWithTimeOut<Container<PTZConfiguration[]>>(msg));
            Receive<OnvifPtzSetConfiguration>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifPtzGetConfigurationsOptions>(msg => GetDataAndReplyPipeToWithTimeOut<Container<PTZConfigurationOptions>>(msg));
            Receive<OnvifPtzSendAuxiliaryCommand>(msg => GetDataAndReplyPipeToWithTimeOut<Container<string>>(msg));
            Receive<OnvifPtzGetPresets>(msg => GetDataAndReplyPipeToWithTimeOut<Container<PTZPreset[]>>(msg));
            Receive<OnvifPtzSetPreset>(msg => GetDataAndReplyPipeToWithTimeOut<Container<string>>(msg));
            Receive<OnvifPtzRemovePreset>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifPtzGotoPreset>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifPtzGotoHomePosition>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifPtzSetHomePosition>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifPtzContinuousMove>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifPtzRelativeMove>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifPtzGetStatus>(msg => GetDataAndReplyPipeToWithTimeOut<Container<PTZStatus>>(msg));
            Receive<OnvifPtzAbsoluteMove>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifPtzStop>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifGetPtzData>(msg => GetDataAndReplyPipeToWithTimeOut<Container<PtzData>>(msg));
            Receive<OnvifLoadPtzNode>(msg => GetDataAndReplyPipeToWithTimeOut<Container<PTZNode>>(msg));
            Receive<OnvifLoadPtzStatus>(msg => GetDataAndReplyPipeToWithTimeOut<Container<PTZStatus>>(msg));
            Receive<OnvifCreateStandartPtzNode>(msg => GetDataAndReplyPipeToWithTimeOut<Container<PTZNode>>(msg));
        }

        private void AnalyticsHandlers()
        {
            Receive<OnvifGetAnalyticsEngineControls>(msg => GetDataAndReplyPipeToWithTimeOut<Container<AnalyticsEngineControl[]>>(msg));
            Receive<OnvifGetAnalyticsEngines>(msg => GetDataAndReplyPipeToWithTimeOut<Container<AnalyticsEngine[]>>(msg));
            Receive<OnvifGetAnalyticsEngine>(msg => GetDataAndReplyPipeToWithTimeOut<Container<AnalyticsEngine>>(msg));
            Receive<OnvifCreateAnalyticsEngineControl>(msg => GetDataAndReplyPipeToWithTimeOut<Container<AnalyticsEngineInput[]>>(msg));
            Receive<OnvifSetAnalyticsEngineControl>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifGetAnalyticsEngineControl>(msg => GetDataAndReplyPipeToWithTimeOut<Container<AnalyticsEngineControl>>(msg));
            Receive<OnvifDeleteAnalyticsEngineControl>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifGetAnalyticsEngineInputs>(msg => GetDataAndReplyPipeToWithTimeOut<Container<AnalyticsEngineInput[]>>(msg));
            Receive<OnvifSetAnalyticsEngineInput>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifSetVideoAnalyticsConfiguration>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifGetAnalyticsDeviceStreamUri>(msg => GetDataAndReplyPipeToWithTimeOut<Container<string>>(msg));
            Receive<OnvifGetVideoAnalyticsConfiguration>(msg => GetDataAndReplyPipeToWithTimeOut<Container<VideoAnalyticsConfiguration>>(msg));
            Receive<OnvifCreateAnalyticsEngineInputs>(msg => GetDataAndReplyPipeToWithTimeOut<Container<AnalyticsEngineInput[]>>(msg));
            Receive<OnvifDeleteAnalyticsEngineInputs>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifGetAnalyticsState>(msg => GetDataAndReplyPipeToWithTimeOut<Container<AnalyticsStateInformation>>(msg));
            Receive<OnvifCreateAnalyticsModules>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifDeleteAnalyticsModules>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifGetAnalyticsModules>(msg => GetDataAndReplyPipeToWithTimeOut<Container<Config[]>>(msg));
            Receive<OnvifModifyAnalyticsModules>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
        }

        private void RulesHandlers()
        {
            Receive<OnvifCreateRules>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifDeleteRules>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifGetRules>(msg => GetDataAndReplyPipeToWithTimeOut<Container<Config[]>>(msg));
            Receive<OnvifModifyRules>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
        }

        private void PropertiesHandlers()
        {
            Receive<OnvifGetIsAnalyticsSupported>(msg => GetDataAndReplyPipeToWithTimeOut<Container<bool>>(msg));
            Receive<OnvifGetIsEventsSupported>(msg => GetDataAndReplyPipeToWithTimeOut<Container<bool>>(msg));
            Receive<OnvifGetIsFirmwareUpgradeSupported>(msg => GetDataAndReplyPipeToWithTimeOut<Container<bool>>(msg));
            Receive<OnvifGetIsPtzSupported>(msg => GetDataAndReplyPipeToWithTimeOut<Container<bool>>(msg));
            Receive<OnvifGetIsZeroConfigurationSupported>(msg => GetDataAndReplyPipeToWithTimeOut<Container<bool>>(msg));
        }

        private void ReceiversHandlers()
        {
            Receive<OnvifGetReceivers>(msg => GetDataAndReplyPipeToWithTimeOut<Container<Receiver[]>>(msg));
            Receive<OnvifGetReceiver>(msg => GetDataAndReplyPipeToWithTimeOut<Container<Receiver>>(msg));
            Receive<OnvifCreateReceiver>(msg => GetDataAndReplyPipeToWithTimeOut<Container<Receiver>>(msg));
            Receive<OnvifDeleteReceiver>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifSetReceiverMode>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifCreateReceiver>(msg => GetDataAndReplyPipeToWithTimeOut<Container<ReceiverStateInformation>>(msg));
        }

        private void ImagingHandlers()
        {
            Receive<OnvifGetImagingSettings>(msg => GetDataAndReplyPipeToWithTimeOut<Container<ImagingSettings20>>(msg));
            Receive<OnvifSetImagingSettings>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifGetImagingOptions>(msg => GetDataAndReplyPipeToWithTimeOut<Container<ImagingOptions20>>(msg));
            Receive<OnvifImagingMove>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifGetImagingMoveOptions>(msg => GetDataAndReplyPipeToWithTimeOut<Container<MoveOptions20>>(msg));
            Receive<OnvifGetImagingStatus>(msg => GetDataAndReplyPipeToWithTimeOut<Container<ImagingStatus20>>(msg));
        }

        private void RecordingHandlers()
        {
            Receive<OnvifGetRecordings>(msg => GetDataAndReplyPipeToWithTimeOut<Container<ImagingSettings20>>(msg));
            Receive<OnvifCreateRecording>(msg => GetDataAndReplyPipeToWithTimeOut<Container<string>>(msg));
            Receive<OnvifDeleteRecording>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifGetRecordingConfiguration>(msg => GetDataAndReplyPipeToWithTimeOut<Container<RecordingConfiguration>>(msg));
            Receive<OnvifSetRecordingConfiguration>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifDeleteTrack>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifGetTrackConfiguration>(msg => GetDataAndReplyPipeToWithTimeOut<Container<TrackConfiguration>>(msg));
            Receive<OnvifSetTrackConfiguration>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifCreateRecordingJob>(msg => GetDataAndReplyPipeToWithTimeOut<Container<Tuple<string, RecordingJobConfiguration>>>(msg));
            Receive<OnvifDeleteRecordingJob>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifGetRecordingJobs>(msg => GetDataAndReplyPipeToWithTimeOut<Container<GetRecordingJobsResponseItem[]>>(msg));
            Receive<OnvifSetRecordingJobConfiguration>(msg => GetDataAndReplyPipeToWithTimeOut<Container<RecordingJobConfiguration>>(msg));
            Receive<OnvifGetRecordingJobConfiguration>(msg => GetDataAndReplyPipeToWithTimeOut<Container<RecordingJobConfiguration>>(msg));
            Receive<OnvifSetRecordingJobMode>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifGetRecordingJobState>(msg => GetDataAndReplyPipeToWithTimeOut<Container<RecordingJobStateInformation>>(msg));
        }

        private void AudioHandlers()
        {
            Receive<OnvifAddAudioEncoderConfiguration>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifRemoveAudioEncoderConfiguration>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifAddAudioSourceConfiguration>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
            Receive<OnvifRemoveAudioSourceConfiguration>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
        }

        #endregion

        private void Handlers()
        {
            AnalyticsHandlers();
            ActionsHandlers();
            ProfilesHandlers();
            UsersHandlers();
            CertificatesHandlers();
            NetworksHandlers();
            SystemDateTimeHandlers();
            SystemLogHandlers();
            VideoHandlers();
            DeviceHandlers();
            EventsHandlers();
            RelayHandlers();
            PtzHandlers();
            RulesHandlers();
            PropertiesHandlers();
            ReceiversHandlers();
            ImagingHandlers();
            RecordingHandlers();
            AudioHandlers();
            
            Receive<OnvifSetMetadataConfiguration>(msg => GetDataAndReplyPipeToWithTimeOut<OnvifResult>(msg));
        }
    }
}
