using System;

namespace Onvif.Contracts.Messages.Onvif.SystemDate
{
    public class OnvifSetSystemDateAndTime : OnvifBase
    {
        public DateTime UtcDateTime { get; private set; }

        public OnvifSetSystemDateAndTime(string uri, string userName, string password, DateTime utcDateTime)
            : base(uri, userName, password)
        {
            UtcDateTime = utcDateTime;
        }
    }
}
