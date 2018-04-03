using onvif.services;

namespace Onvif.Contracts.Messages.Onvif.SystemLog
{
    public class OnvifGetSystemLog : OnvifBase
    {
        public SystemLogType LogType { get; private set; }

        public OnvifGetSystemLog(string uri, string userName, string password, SystemLogType logType)
            : base(uri, userName, password)
        {
            LogType = logType;
        }
    }
}
