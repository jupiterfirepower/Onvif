using System;
using System.Collections.Generic;
using Akka.Actor;
using Onvif.Contracts.Constants;
using Onvif.Contracts.Enums;
using Onvif.Contracts.Messages;

namespace Onvif.Camera.Client
{
    public partial class OnvifClient
    {
        public void SubscribeMdtEventForProcessing(string onvifCameraUrl, string userName, string password, string webUrl, Dictionary<string, string> parameters, string manufacturer)
        {
            var msg = CreateMsgSubscribeToCameraEvent(onvifCameraUrl, userName, password, webUrl, parameters, manufacturer);
            _proxyActor.Tell(msg);
        }

        public void SubscribeMdtEventForProcessing(string onvifCameraUrl, string userName, string password,
            string webUrl, Tuple<string, string>[] parameters, string manufacturer)
        {
            var dparam = new Dictionary<string, string>();
            Array.ForEach(parameters, p => dparam.Add(p.Item1, p.Item2));
            var msg = CreateMsgSubscribeToCameraEvent(onvifCameraUrl, userName, password, webUrl, dparam, manufacturer);
            _proxyActor.Tell(msg);
        }

        public void SubscribeMotionDetectionEventForProcessing(string onvifCameraUrl, string userName, string password, string webUrl, Dictionary<string, string> parameters, string manufacturer)
        {
            Inner(onvifCameraUrl, userName, password, webUrl, parameters, OnvifEventTopic.MotionDetection, manufacturer, 1);
        }

        public void SubscribeMotionDetectionEventForProcessing(string onvifCameraUrl, string userName, string password,
            string webUrl, Tuple<string, string>[] parameters, string manufacturer)
        {
            Inner(onvifCameraUrl, userName, password, webUrl, parameters, OnvifEventTopic.MotionDetection, manufacturer, 1);
        }

        public void SubscribeMotionAlertEventForProcessing(string onvifCameraUrl, string userName, string password,
            string webUrl, Dictionary<string, string> parameters, string manufacturer)
        {
            Inner(onvifCameraUrl, userName, password, webUrl, parameters, OnvifEventTopic.MotionAlarm, manufacturer, 1);
        }

        public void SubscribeMotionAlertEventForProcessing(string onvifCameraUrl, string userName, string password,
            string webUrl, Tuple<string, string>[] parameters, string manufacturer)
        {
            Inner(onvifCameraUrl, userName, password, webUrl, parameters, OnvifEventTopic.MotionAlarm, manufacturer, 1);
        }

        public void SubscribeTamperingEventForProcessing(string onvifCameraUrl, string userName, string password, string webUrl, Dictionary<string, string> parameters, string manufacturer)
        {
            Inner(onvifCameraUrl, userName, password, webUrl, parameters, OnvifEventTopic.Tampering, manufacturer);
        }

        public void SubscribeTamperingEventForProcessing(string onvifCameraUrl, string userName, string password,
            string webUrl, Tuple<string, string>[] parameters, string manufacturer)
        {
            Inner(onvifCameraUrl, userName, password, webUrl, parameters, OnvifEventTopic.Tampering, manufacturer);
        }

        private void Inner(string onvifCameraUrl, string userName, string password, string webUrl, Dictionary<string, string> parameters, OnvifEventTopic topic, string manufacturer, int source = 0)
        {
            var msg = CreateMsgSubscribeToCameraEvent(onvifCameraUrl, userName, password, webUrl, parameters, manufacturer, new[] { new OnvifEventTopicFilter(topic) }, source);
            _proxyActor.Tell(msg);
        }

        private void Inner(string onvifCameraUrl, string userName, string password, string webUrl, Tuple<string, string>[] parameters, OnvifEventTopic topic, string manufacturer, int source = 0)
        {
            var dparam = new Dictionary<string, string>();
            Array.ForEach(parameters, p => dparam.Add(p.Item1, p.Item2));
            var msg = CreateMsgSubscribeToCameraEvent(onvifCameraUrl, userName, password, webUrl, dparam, manufacturer, new[] { new OnvifEventTopicFilter(topic) }, source);
            _proxyActor.Tell(msg);
        }

        public void UnSubscribeEventsForProcessing(string onvifCameraUrl, int cameraId = -1)
        {
            var msg = new UnSubscribeEventsForProcessing(onvifCameraUrl, cameraId, Guid.NewGuid());
            _proxyActor.Tell(msg);
        }

        private SubscribeEventsForProcessing CreateMsgSubscribeToCameraEvent(string onvifCameraUrl, string userName, string password, string webUrl, Dictionary<string, string> parameters, string manufacturer, OnvifEventTopicFilter[] paramTopicFilters = null, int source = 0)
        {
            var topicFilters = paramTopicFilters ?? new[]
            {
                new OnvifEventTopicFilter(OnvifEventTopic.MotionAlarm),
                new OnvifEventTopicFilter(OnvifEventTopic.MotionDetection),
                new OnvifEventTopicFilter(OnvifEventTopic.Tampering)
            };

            return new SubscribeEventsForProcessing(onvifCameraUrl, userName, password,
                parameters, topicFilters,
                TimeSpan.FromSeconds(Constant.SlidingWindowSizeSeconds),
                TimeSpan.FromSeconds(Constant.IntervalInSlidingWindowSeconds),
                manufacturer, webUrl, source, Constant.SlidingWindowSizeSeconds, Constant.IntervalInSlidingWindowSeconds);
        }
    }
}
