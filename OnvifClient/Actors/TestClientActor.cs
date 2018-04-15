using System;
using System.Net;
using Akka.Actor;
using Onvif.Contracts.Messages;
using Onvif.Contracts.Model;
using Onvif.Proxy;

namespace Onvif.Camera.Client.Actors
{
    public class TestClientActor : ReceiveActor
    {
        public TestClientActor()
        {
            Receive<OnvifGetDeviceInfo>(msg =>
            {
                using (var proxyLocal = new OnvifProxy(new NetworkCredential("root", "root"), new Uri("http://115.93.45.236:1080/onvif/device_service")))
                {
                    var deviceInfo = proxyLocal.GetDeviceInformation().Result;
                    Sender.Tell(new Container<DeviceInfo>(true) { WorkItem = deviceInfo }, Self);
                }
            });


        }
    }
}
