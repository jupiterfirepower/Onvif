using Onvif.Contracts.Enums;

namespace Onvif.Contracts.Model
{
    public class CameraProfile
    {
        public int CameraId { get; set; }
        
        public AlertProfile[] AlertProfiles{ get; set; }

        
    }
}
