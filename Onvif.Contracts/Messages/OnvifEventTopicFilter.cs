using Onvif.Contracts.Constants;
using Onvif.Contracts.Enums;

namespace Onvif.Contracts.Messages
{
    public class OnvifEventTopicFilter
    {
        public string TopicExpresion
        {
            get { return GetTopicExpresionByType(Topic); }
        }

        public OnvifEventTopic Topic
        {
            get;
            set;
        }

        public OnvifEventTopicFilter(OnvifEventTopic topic)
        {
            Topic = topic;
        }

        private string GetTopicExpresionByType(OnvifEventTopic topic)
        {
            switch (topic)
            {
                case OnvifEventTopic.MotionAlarm:
                    return Constant.MotionAlarmTopicFilterExpresion;
                case OnvifEventTopic.MotionDetection:
                    return Constant.MotionDetectionTopicFilterExpresion;
                case OnvifEventTopic.AxisMotionDetection:
                    return Constant.AxisMotionDetectionTopicFilterExpresion;
                case OnvifEventTopic.Tampering:
                    return Constant.TamperinTopicFilterExpresion;
                default:
                    return topic.ToString();
            }
        }
    }
}
