using System.Configuration;
using System.Threading;
using Onvif.Contracts.Helper;

namespace Onvif.Contracts.Constants
{
    public class Constant
    {
        static Constant()
        {
            ReadParameterValueFromConfig("AskTimeOutSeconds", out AskTimeOutSeconds, 30);
            ReadParameterValueFromConfig("ClientAskTimeOutSeconds", out ClientAskTimeOutSeconds, 60);
            ReadParameterValueFromConfig("RetryHelperTryIntervalMiliseconds", out RetryHelperTryIntervalMiliseconds, 100);
            ReadParameterValueFromConfig("RetryHelperMaxTryCount", out RetryHelperMaxTryCount, 3);
            ReadParameterValueFromConfig("RetryHelperTimeLimitSeconds", out RetryHelperTimeLimitSeconds, 15);
            ReadParameterValueFromConfig("GetEventPropertiesTimeLimitSeconds", out GetEventPropertiesTimeLimitSeconds, 10);
            ReadParameterValueFromConfig("WaitMiliseconds", out WaitMiliseconds, 5000);
            ReadParameterValueFromConfig("WaitPeriodMinutes", out WaitPeriodMinutes, 3);
            ReadParameterValueFromConfig("PreStartWaitMiliseconds", out PreStartWaitMiliseconds, 3000);
            ReadParameterValueFromConfig("WaitSeconds", out WaitSeconds, 10);
            ReadParameterValueFromConfig("WaitMinutes", out WaitMinutes, 5);
            ReadParameterValueFromConfig("ScheduleWaitMinutes", out ScheduleWaitMinutes, 10);
            ReadParameterValueFromConfig("ScheduleWaitOneMinute", out ScheduleWaitOneMinute, 1);
            ReadParameterValueFromConfig("MaxNrOfRetries", out MaxNrOfRetries, 3);
            ReadParameterValueFromConfig("WithinTimeSeconds", out WithinTimeSeconds, 30);
            ReadParameterValueFromConfig("NrOfInstances", out NrOfInstances, 10);
            ReadParameterValueFromConfig("SlidingWindowSizeSeconds", out SlidingWindowSizeSeconds, 60);
            ReadParameterValueFromConfig("IntervalInSlidingWindowSeconds", out IntervalInSlidingWindowSeconds, 30);
            ReadParameterValueFromConfig("NrMaxOfInstances", out NrMaxOfInstances, 1000);
            ReadBoolParameterValueFromConfig("UseNagleAlgorithm", out UseNagleAlgorithm, true);
            ReadParameterValueFromConfig("DefaultConnectionLimit", out DefaultConnectionLimit, 1000);
            ReadParameterValueFromConfig("MaxIdleTime", out MaxIdleTime, 400);
            ReadParameterValueFromConfig("MaxServicePoints", out MaxServicePoints, 600);
            ReadParameterValueFromConfig("CameraCountForCloudWatchLogging", out CameraCountForCloudWatchLogging, 10);
            ReadParameterValueFromConfig("MinStopEventDurationInSeconds", out MinStopEventDurationInSeconds, 30);
            ReadParameterValueFromConfig("NoEventsPeriod", out NoEventsPeriod, 24);
            ReadParameterValueFromConfig("NetworkNotAvailableInMinutes", out NetworkNotAvailableInMinutes, 30);
            ReadParameterValueFromConfig("NoDataForEventProcessingSendEmailAlertPeriodInMinutes", out NoDataSendEmailAlertPeriodInMinutes, 60);
            ReadParameterValueFromConfig("HighCpuLevelAlert", out HighCpuLevelAlert, 95);
            ReadParameterValueFromConfig("CloudWatchLogDateTimeFormat", out CloudWatchLogDateTimeFormat, "dd-MM-yyyy HH:mm:ss");
        }

        public static int CameraCountForCloudWatchLogging;

        private static void ReadParameterValueFromConfig(string key, out int val, int def)
        {
            val = def;
            var value = ConfigurationManager.AppSettings[key];
            if (!string.IsNullOrEmpty(value))
            {
                int.TryParse(value, out val);
            }
        }

        private static void ReadParameterValueFromConfig(string key, out string val, string def)
        {
            val = def;
            var value = ConfigurationManager.AppSettings[key];
            if (!string.IsNullOrEmpty(value))
            {
                val = value;
            }
        }

        private static void ReadBoolParameterValueFromConfig(string key, out bool val, bool def)
        {
            val = def;
            var value = ConfigurationManager.AppSettings[key];
            if (!string.IsNullOrEmpty(value))
            {
                bool.TryParse(value, out val);
            }
        }

        public const string BrandAcTi = "AcTi";
        public const string BrandAxis = "Axis";
        public const string BrandUniView = "Uniview";
        public const string BrandBrickcom = "Brickcom";
        public const string BrandDahua = "Dahua";
        public const string BrandFlexWatch = "FlexWatch";
        public const string BrandHikvision = "Hikvision";
        public const string BrandMobideos = "Mobideos";
        public const string BrandMobideos1 = "Mobideos1";
        public const string BrandTrendNet = "TrendNet";
        public const string BrandUbiquiti = "Ubiquiti";
        public const string Window = "window";
        public const string WindowSource = "window:";
        public const string NamedPipe = "Onvif.Services";
        public const string Version = "Version";
        public const string AppVersion = "AppVersion";
        public const string ActorThreadId = "ActorThreadId";
        public const string ServerAliasName = "ServerAliasName";
        public const string OnvifEventsLogS3Dir = "onvifevents-log";
        public const string S3BucketName3deyeLogs = "3deye-logs";
        public const string HoconPrefix = "hocon_";

        public const string AppConfigStartKey = "APPCONFIG";

        public const string MotionWindow0 = "root.Motion.M0";

        public const string PrefixHttp = "http://";
        public const string PrefixHttps = "https://";
        public static string CloudWatchLogDateTimeFormat = "dd-MM-yyyy HH:mm:ss";


        public static int DefaultConnectionLimit = 1000;
        public static int MaxIdleTime = 400;
        public static int MaxServicePoints = 600;

        public static int MinStopEventDurationInSeconds = 30;

        public static bool UseNagleAlgorithm = true;

        public static readonly int AskTimeOutSeconds = 30;
        public static readonly int ClientAskTimeOutSeconds = 60;
        public static readonly int RetryHelperTryIntervalMiliseconds = 100;
        public static readonly int RetryHelperMaxTryCount = 3;
        public static readonly int RetryHelperTimeLimitSeconds = 15;
        public static readonly int GetEventPropertiesTimeLimitSeconds = 10;
        public static readonly int WaitMiliseconds = 5000;
        public static readonly int WaitDelayMinutes = 1;
        public static readonly int WaitPeriodMinutes = 3;
        public static readonly int PreStartWaitMiliseconds = 3000;
        public static readonly int WaitSeconds = 10;
        public static readonly int WaitOperationAbortedExceptionSeconds = 30;
        public static readonly int WaitMinutes = 5;
        public static readonly int ScheduleWaitMinutes = 10;
        public static readonly int ScheduleWaitOneMinute = 1;
        public static readonly int MaxNrOfRetries = 5;
        public static readonly int WithinTimeSeconds = 60;
        public static readonly int NrOfInstances = 10;
        public static readonly int NrMaxOfInstances = 100;
        public static readonly int SlidingWindowSizeSeconds = 60;
        public static readonly int IntervalInSlidingWindowSeconds = 30;
        public static readonly int NoEventsPeriod = 24;
        public static readonly int NoDataSendEmailAlertPeriodInMinutes = 60;
        public static readonly int HighCpuLevelAlert = 95;

        public static readonly int NetworkNotAvailableInMinutes = 30;

        public const string AppWebUrlKey = "WebUrl";
        public static readonly string OnvifCameraEventListenerActorName = "OnvifCameraEventListener";//RandomHelper.GenUniqueActorNameId();
        public const string OnvifCameraEventListenerNoPoolActorName = "OnvifCameraEventListener";
        public const string EmailCoordinatorActorName = "emailcoordinatoractor";
        public const string CloudWatchGateWayActorName = "cloudwatchgatewayactor";
        public const string AppIsIndependentModeKey = "IsIndependentMode";

        public const string CloudWatchServerKey = "CloudWatchServer";
        public const string CloudWatchServerPortKey = "CloudWatchServerPort";
        public const string NotificationServerKey = "NotificationServer";
        public const string NotificationServerPortKey = "NotificationServerPort";
        public const string OnvifNotificationEmail = "OnvifNotificationEmail";
        public const string OnvifNotificationEmailFormalCameraId = "-9999";
        public const string UsePortRangeKey = "UsePortRange";
        public const string StartPortKey = "StartPort";
        public const string EndPortKey = "EndPort";
        public const string EventStartStopModeAppKey = "EventStartStopMode";
        public const string NoEventsOnvifRebootPeriodAppKey = "NoEventsOnvifRebootPeriod";
        public const string RecconectGetEventPropertiesCountAppKey = "RecconectGetEventPropertiesCount";
        public const string ResetReconnectCountFlagAfterHoursAppKey = "ResetReconnectCountFlagAfterHours";
        public const string GetChangesCameraListSqlExceptionCameraUri = "GetChangesCameraList";
        public const string ChangesCameraList = "ChangesCameraListFromSqlProcedure";
        public const string RecoveryRestartService = "RestartService(Recovery)";
        public const string FlexWatch = "flexwatch";
        public const string Onvif = "onvif";
        public const string NoEventsPeriodAppKey = "NoEventsPeriod";
        public const string ParamCameraIdKey = "cameraId";
        public const string ParamClientKey = "client";
        public const string DimensionNameCameraId = "CameraId";
        public const string DimensionNameCameraUrl = "CameraUrl";
        public const string OnvifFacadeActor = "OnvifFacadeActor";
        private static string _onvifServerActorSystemName;
        public static string OnvifServerActorSystemName
        {
            get // Implement double-checked locking
            {
                LazyInitializer.EnsureInitialized(ref _onvifServerActorSystemName, RandomHelper.GenUniqueActorSystemId);
                return _onvifServerActorSystemName;
            }
        }
        public const string ServicesActorSystemName = "ServicesActorSystemName";
        public const string OnvifServerActorSystemNameNoProtectionMode = "OnvifServerActorSystemName";
        public const string ClusterOnvifServerActorSystemName = "ClusterOnvifServerActorSystem";

        private static string _onvifServicesActorSystemName;
        public static string OnvifServicesActorSystemName
        {
            get // Implement double-checked locking
            {
                LazyInitializer.EnsureInitialized(ref _onvifServicesActorSystemName, RandomHelper.GenUniqueActorSystemId);
                return _onvifServicesActorSystemName;
            }
        }

        public const string OnvifClientActorSystem = "OnvifClientActorSystem";
        public const string OnvifCoordinatorActorName = "coordinator";
        public const string OnvifEventCoordinatorActorName = "eventcoordinator";
        public const string AlertCoordinatorActorName = "alertcoordinator";
        public const string EmailActorName = "emailactor";
        //public static readonly string LoggerActorName = RandomHelper.GenUniqueActorNameId();
        //public static readonly string MonitoringActorName = RandomHelper.GenUniqueActorNameId();
        public const string DecisionMakerActorName = "decisionmaker";
        public const string CloudWatchLogActor = "cloudwatchlogactor";
        //public static readonly string CoordinatorCloudWatchLogActor = RandomHelper.GenUniqueActorNameId();
        public const string EmailActor = "emailactor";
        public const string CloudWatchActor = "cloudwatchactor";
        public const string ApplicationIdAppKey = "ApplicationId";
        public const string CustomMetricNameSpace = "OnvifCamera/EventMonitoring";
        //public const string MotionDetectionTopicFilterExpresion = "tns1:VideoAnalytics/tnsn:MotionDetection";
        //public const string TamperinTopicFilterExpresion = "tns1:VideoSource/tnsn:Tampering";
        public const string MotionDetectionTopicFilterExpresion = "tns1:VideoAnalytics/MotionDetection";
        public const string UniviewMotionDetectionTopicFilterExpresion = "tns1:RuleEngine/CellMotionDetector/Motion";
        //uniview
        public const string AxisMotionDetectionTopicFilterExpresion = "tns1:VideoAnalytics/tnsaxis:MotionDetection";
        //public const string TamperinTopicFilterExpresion = "tns1:VideoSource/tns1:Tampering";
        //public const string MotionDetectionTopicFilterExpresion = "MotionDetection";
        //public const string TamperinTopicFilterExpresion = "Tampering";
        public const string MotionAlarmTopicFilterExpresion = "tns1:VideoSource/MotionAlarm";
        public const string TamperinTopicFilterExpresion = "tns1:VideoSource/Tampering";
        public const string AxisTamperinTopicFilterExpresion = "tns1:VideoSource/tnsaxis:Tampering";
        public const string DefLogFormat = "{0}";
        public const string EventListenerActorSelectorPath = "akka://{0}/user/{1}/{2}/*";
        public const string ConcreteSet = "ConcreteSet";
        public const string LogSource = "file";
        public const string Action = "action";
        public const string Time = "time";
        public const string StartEvent = "startEvent";
        public const string StopEvent  = "stopEvent";
        public const string LogGroupName = "OnvifCameraEvents";
        public const string ServerAliasNameAppKey = "ServerAliasName";
        public const string AppVersionAppKey = "AppVersion";
        public const string WriteEventsInSeparateLogFilesAppKey = "WriteEventsInSeparateLogFiles";
        public const string ThrottleWriteEventsInSeparateLogFilesAppKey = "ThrottleWriteEventsInSeparateLogFiles";
        public const string OnvifRebootModeAppKey = "OnvifRebootMode";
        public const string OnvifStartRebootModeAppKey = "OnvifStartRebootMode";
        public const string CountStatisticReportModeAppKey = "CountStatisticReportMode";
        public const string AkkaPoolIndependentModeAppKey = "AkkaPoolIndependentMode";
        public const string UseConsistentHashingPoolAppKey = "UseConsistentHashingPool";
        public const string AmazoneServerAppKey = "AmazoneServer";
        public const string AmazoneServerPortAppKey = "AmazoneServerPort";
        public const string RemoteProtectedModeAppKey = "RemoteProtectedMode";
        public const string ExternalPublicIpAdressesAppKey = "ExternalPublicIpAdresses";
        public const string LocalServerModeAppKey = "LocalServerMode";

        public const string OnvifCameraStartSubscribeWithoutTopicFilteredAppKey = "OnvifCameraStartSubscribeWithoutTopicFiltered";
        
        public const string CountStatisticReportPeriodAppKey = "CountStatisticReportPeriod";
        public const string AwsAccessAppKey = "AWSAccessKey";
        public const string AwsSecretAppKey = "AWSSecretKey";
        public const string MinStopEventDurationInSecondsAppKey = "MinStopEventDurationInSeconds";
        public const string ServiceModeAppKey = "ServiceMode";
        public const string SupportEmailsAppKey = "SupportEmails";

        public const string SendEmailRemoteModeAppKey = "SendEmailRemoteMode";
        public const string SendEmailServerServiceAppKey = "SendEmailServerService";
        public const string TestModeLaggeCameraDataAppKey = "TestModeLaggeCameraData";
        public const string SendEmailServerServicePortAppKey = "SendEmailServerServicePort";
        public const string PerfMonRamInMbAppKey = "PerfMonRamInMb";
        public const string FirstChanceExceptionTraceAppKey = "FirstChanceExceptionTrace";
        public const string RemoteAccessModeAppKey = "RemoteAccessMode";
        public const string AnalyticsModeAppKey = "AnalyticsMode";
        public const string PullPointTerminationTimeAppKey = "PullPointTerminationTime";
        public const string AkkaRemoteServerAppKey = "RemoteServer";
        public const string AkkaRemoteServerPortAppKey = "RemoteServerPort";
        public const string AkkaHeliosLocalPortAppKey = "LocalHeliosPort";
        public const string PrintToConsoleAppKey = "PrintToConsole";
        public const string ServiceModeLocal  = "Local";
        public const string ServiceModeServer = "Server";
        public const string DecisionMakerActorPeriodAppKey = "DecisionMakerActorPeriod";
        public const string DelaySendEventSubscriptionAppKey = "DelaySendEventSubscription";
        public const string Ok = "ok";
        public const string PostFixOnvifDeviceService = "onvif/device_service";
        public const int BaseSubscriptionPort = 8085;

        public const string ServerKey = "#Server#";
        public const string ServerPortKey = "#Port#";

        public const string MandrillApiKeyAppKey = "MandrillApiKey";
        public const string SmtpServerAppKey = "SmtpServer";
        public const string SmtpPortrAppKey = "SmtpPort";
        public const string ServerUserAppKey = "ServerUser";
        public const string SenderAppKey = "Sender";
        
    }
}
