using System;
using System.Collections.Generic;

namespace Onvif.Camera.Client.Contracts
{
    public interface IOnvifClientEvent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="onvifCameraUrl"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="webUrl"></param>
        /// <param name="parameters"></param>
        /// <param name="manufacturer"></param>
        void SubscribeMdtEventForProcessing(string onvifCameraUrl, string userName, string password, string webUrl, Dictionary<string, string> parameters, string manufacturer);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="onvifCameraUrl"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="webUrl"></param>
        /// <param name="parameters"></param>
        /// <param name="manufacturer"></param>
        void SubscribeMdtEventForProcessing(string onvifCameraUrl, string userName, string password, string webUrl, Tuple<string, string>[] parameters, string manufacturer);

        void SubscribeMotionAlertEventForProcessing(string onvifCameraUrl, string userName, string password, string webUrl, Dictionary<string, string> parameters, string manufacturer);

        void SubscribeMotionAlertEventForProcessing(string onvifCameraUrl, string userName, string password, string webUrl, Tuple<string, string>[] parameters, string manufacturer);

        void SubscribeMotionDetectionEventForProcessing(string onvifCameraUrl, string userName, string password, string webUrl, Dictionary<string, string> parameters, string manufacturer);

        void SubscribeMotionDetectionEventForProcessing(string onvifCameraUrl, string userName, string password, string webUrl, Tuple<string, string>[] parameters, string manufacturer);

        void SubscribeTamperingEventForProcessing(string onvifCameraUrl, string userName, string password, string webUrl, Dictionary<string, string> parameters, string manufacturer);

        void SubscribeTamperingEventForProcessing(string onvifCameraUrl, string userName, string password, string webUrl, Tuple<string, string>[] parameters, string manufacturer);

        void UnSubscribeEventsForProcessing(string onvifCameraUrl, int cameraId = -1);
    }
}
