using onvif.services;

namespace Onvif.Contracts.Model
{
    public class VideoSettings: ModelBase
    {
        public VideoSettings(): base(false)
        {
        }

        public VideoSettings(bool result): base(result)
        {
        }

        public int MinQuality { get; set; }
        public int MaxQuality { get; set; }

        public int MinBitrate { get; set; }

        public int MaxBitrate { get; set; }

        public int MinEncodingInterval { get; set; }

        public int MaxEncodingInterval { get; set; }

        public int MinFrameRate { get; set; }

        public int MaxFrameRate { get; set; }

        public int MinGovLength { get; set; }

        public int MaxGovLength { get; set; }

        public VideoEncoderConfigurationOptions EncoderOptions { get; set; }

        public string ProfToken { get; set; }

        public VideoEncoding Encoder { get; set; }

        public VideoResolution VideoResolution { get; set; }

        public int EncodingInterval { get; set; }

        public float Quality { get; set; }

        public float Bitrate { get; set; }

        public float FrameRate { get; set; }

        public int GovLength { get; set; }
    }
}
