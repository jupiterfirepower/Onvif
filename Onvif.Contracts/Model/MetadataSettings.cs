using onvif.services;

namespace Onvif.Contracts.Model
{
    public class MetadataSettings
    {
        public string[] MessageContentFilterDialects { get; set; }
        public string[] TopicExpressionDialects { get; set; }
        public TopicSetType TopicSet { get; set; }
        public bool IsFixedTopicSet { get; set; }
        public bool IsPtzStatusSupported { get; set; }

        public bool IsPtzPositionSupported { get; set; }

        public bool IncludeAnalitycs { get; set; }

        public bool IncludePtzStatus { get; set; }

        public bool IncludePtzPosition { get; set; }

        public bool IncludeEvents { get; set; }

        public TopicExpressionFilter[] TopicExpressionFilters { get; set; }

        public MessageContentFilter[] MessageContentFilters { get; set; }
    }
}
