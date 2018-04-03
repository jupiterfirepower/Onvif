using System;

namespace Onvif.Contracts.Model
{
    public class SchedulerItem
    {
        public int MaxNumberEmailInDay { get; set; }
        public int UserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DayOfWeek[] Days { get; set; }
        public int ThrottlingDurationInSeconds { get; set; }
    }
}
