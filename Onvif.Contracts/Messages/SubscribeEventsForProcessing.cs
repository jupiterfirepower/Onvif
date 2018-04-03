using System;
using System.Collections.Generic;
using System.Linq;
using Onvif.Contracts.Constants;
using Onvif.Contracts.Enums;
using Onvif.Contracts.Helper;
using Onvif.Contracts.Messages.Onvif;

namespace Onvif.Contracts.Messages
{
    public class SubscribeEventsForProcessing : OnvifBase, IHashKey
    {
        public string Manufacturer { get; private set; }
        public string WebUrl { get; set; }
        public TimeSpan SlidingWindowSize { get; private set;  }
        public TimeSpan IntervalInSlidingWindow { get; private set; }

        public int Source { get; private set; }

        public Dictionary<string, string> Parameters { get; private set; }

        public OnvifEventTopicFilter[] TopicFilters { get; private set; }

        public bool Reconnect { get; set; }
        public bool External { get; set; }
        public int? UseEventBasePort { get; set; }

        public SourcePoint FromSource { get; set; }

        public string Stamp { get; set; }

        public int MinMotionDuration { get; set; }
        public int MaxMotionDuration { get; set; }
        public int MinStopEventDuration { get; set; }

        public SubscribeEventsForProcessing(string uri, string userName, string password, 
            Dictionary<string, string> parameters, OnvifEventTopicFilter[] topicFilters,
            TimeSpan slidingWindowSize, TimeSpan intervalInSlidingWindow,
            string webUrl, string manufacturer, int minMotionDuration, int maxMotionDuration, int source = 0)
            : base(uri, userName, password)
        {
            Parameters = parameters;
            TopicFilters = topicFilters;
            SlidingWindowSize = slidingWindowSize;
            IntervalInSlidingWindow = intervalInSlidingWindow;
            Manufacturer = manufacturer;
            WebUrl = webUrl;
            Source = source;
            Reconnect = false;
            MinMotionDuration = minMotionDuration;
            MaxMotionDuration = maxMotionDuration;
        }

        public int[] CameraIdArray { get; set; }

        public string CameraId
        {
            get
            {
                if (Parameters != null && Parameters.ContainsKey(Constant.ParamCameraIdKey))
                    return Parameters[Constant.ParamCameraIdKey];
                return "-1";
            }
        }

        public int Port
        {
            get
            {
                return new Uri(Uri).Port;
            }
        }

        public override string ToString()
        {
            return string.Format("Uri - {0}, WebUrl - {1}, MinMotionDuration - {7}, MaxMotionDuration - {8}, SlidingWindowSize - {2}, IntervalInSlidingWindow - {3} Parameters - {4}, EventTopics - {5}, Source - {6} ",
                Uri,
                WebUrl ?? string.Empty,
                SlidingWindowSize.TotalMilliseconds,
                IntervalInSlidingWindow.TotalMilliseconds,
                Parameters != null ? ConvertorHelper.DictionaryToJson(Parameters) : string.Empty, string.Join(",", TopicFilters.Select(x => x.TopicExpresion)), 
                Source, MinMotionDuration, MaxMotionDuration);
        }

        public override int GetHashCode()
        {
            return !string.IsNullOrEmpty(Uri) ? Uri.GetHashCode() + Convert.ToInt32(CameraId) : 0;
        }

        public string Key { get { return CameraId; } }
    }
}
