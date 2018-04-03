using Onvif.Contracts.Enums;

namespace Onvif.Contracts.Model
{
    public class AlertProfile
    {
        public SystemAlerts TypeAlert { get; set; }

        public SchedulerItem[] Schedulers { get; set; }
    }
}
