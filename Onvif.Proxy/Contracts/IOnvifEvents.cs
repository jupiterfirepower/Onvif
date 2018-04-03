using System;
using System.Collections.Generic;
using System.Xml.Linq;
using onvif.services;
using onvif.utils;

namespace Onvif.Proxy.Contracts
{
    public interface IOnvifEvents
    {
        bool IsEventsSupported { get; }
        IObservable<OnvifEvent> GetPullPointEvents(TopicExpressionFilter[] topArray, MessageContentFilter[] contArray);

        IObservable<OnvifEvent> GetAllPullPointEvents();

        IObservable<OnvifEvent> GetPullPointEvents(FilterType filter);

        IObservable<OnvifEvent> GetPullPointEvents(IEnumerable<XElement> filter);

        IObservable<OnvifEvent> GetBaseEvents(int port, MessageContentFilter[] contArray, TopicExpressionFilter[] topArray);

        IObservable<OnvifEvent> GetBaseEvents(int port);

        IObservable<OnvifEvent> GetBaseEvents(FilterType filter, int port);

        IObservable<OnvifEvent> GetBaseEvents(IEnumerable<XElement> filter, int port);

        IObservable<OnvifEvent> GetBaseEvents(int port, FilterType type);
        IObservable<OnvifEvent> GetPullPointEvents();
    }
}
