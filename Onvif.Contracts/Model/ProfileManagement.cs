using onvif.services;

namespace Onvif.Contracts.Model
{
    public class ProfileManagement
    {
        public Profile[] Profiles { get; set; }
        public VideoSource[] VideoSources { get; set; }
        public AudioSource[] AudioSources { get; set; }
        public PTZNode[] PtzNodes { get; set; }
    }
}
