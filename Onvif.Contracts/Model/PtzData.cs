using onvif.services;

namespace Onvif.Contracts.Model
{
    public class PtzData
    {
        public Profile Profile { get; set; }

        public PTZNode Node { get; set; }

        public PTZStatus Status { get; set; }

        public PTZPreset[] PtzPresets { get; set; }
    }
}
