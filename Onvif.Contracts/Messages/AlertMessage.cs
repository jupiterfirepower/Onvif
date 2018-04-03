using Onvif.Contracts.Enums;

namespace Onvif.Contracts.Messages
{
    public class AlertMessage
    {
        public AlarmSourceType AlarmSourceType { get; private set; }
        public int SourceId { get; private set; }
        public ServiceType ServiceType { get; private set; }
        public int CustomerId { get; private set; }
        public AlarmType AlarmType { get; private set; }
        public string Message { get; private set; }

        public string SrvDateTime { get; private set; }

        public AlertMessage(AlarmSourceType alarmSourceType, int sourceId, 
            ServiceType serviceType, int customerId, 
            AlarmType alarmType, string message, string srvDateTime)
        {
            AlarmSourceType = alarmSourceType;
            SourceId = sourceId;
            ServiceType = serviceType;
            CustomerId = customerId;
            AlarmType = alarmType;
            Message = message;
            SrvDateTime = srvDateTime;
        }

        public string Key => $"{AlarmSourceType}-{SourceId}-{ServiceType}-{CustomerId}-{AlarmType}";
    }
}
