using System;
using System.Net;
using System.Threading.Tasks;
using onvif.services;
using Onvif.Proxy;

namespace Onvif.Client
{
    public partial class OnvifClient
    {
        public async Task<SupportedActions> GetSupportedActionsAsync()
        {
            using (var proxy = new OnvifProxy(new NetworkCredential(_userName, _password), new Uri(_url)))
            {
                return await proxy.GetSupportedActionsAsync();
            }
        }

        public SupportedActions GetSupportedActions(string camUserName, string camPassword, string cameraUri)
        {
            using (var proxy = new OnvifProxy(new NetworkCredential(camUserName, camPassword), new Uri(cameraUri)))
            {
                var actions = proxy.GetSupportedActionsAsync().Result;
                return actions;
            }
        }

        public SupportedActions GetSupportedActions()
        {
            return GetSupportedActions(_url, _userName, _password);
        }

        public async Task<Action1[]> GetActionsAsync()
        {
            using (var proxy = new OnvifProxy(new NetworkCredential(_userName, _password), new Uri(_url)))
            {
                return await proxy.GetActionsAsync();
            }
        }

        public async Task<Action1[]> GetActionsAsync(string camUrl, string camUserName, string camPassword)
        {
            using (var proxy = new OnvifProxy(new NetworkCredential(camUserName, camPassword), new Uri(camUrl)))
            {
                return await proxy.GetActionsAsync();
            }
        }

        public Action1[] GetActions()
        {
            using (var proxy = new OnvifProxy(new NetworkCredential(_userName, _password), new Uri(_url)))
            {
                return proxy.GetActionsAsync().Result;
            }
        }

        public Action1[] GetActions(string camUrl, string camUserName, string camPassword)
        {
            using (var proxy = new OnvifProxy(new NetworkCredential(camUserName, camPassword), new Uri(camUrl)))
            {
                return proxy.GetActionsAsync().Result;
            }
        }

        public async Task<ActionTrigger[]> GetActionTriggersAsync()
        {
            using (var proxy = new OnvifProxy(new NetworkCredential(_userName, _password), new Uri(_url)))
            {
                return await proxy.GetActionTriggersAsync();
            }
        }

        public ActionTrigger[] GetActionTriggers(string camUrl, string camUserName, string camPassword)
        {
            using (var proxy = new OnvifProxy(new NetworkCredential(camUserName, camPassword), new Uri(camUrl)))
            {
                return proxy.GetActionTriggersAsync().Result;
            }
        }

        public ActionTrigger[] GetActionTriggers()
        {
            return GetActionTriggers(_url, _userName, _password);
        }

        public async Task<Action1[]> CreateActionsAsync(ActionConfiguration[] actConf)
        {
            using (var proxy = new OnvifProxy(new NetworkCredential(_userName, _password), new Uri(_url)))
            {
                return await proxy.CreateActionsAsync(actConf);
            }
        }

        public async Task<Action1[]> CreateActionsAsync(string camUrl, string camUserName, string camPassword, ActionConfiguration[] actConf)
        {
            using (var proxy = new OnvifProxy(new NetworkCredential(camUserName, camPassword), new Uri(camUrl)))
            {
                return await proxy.CreateActionsAsync(actConf);
            }
        }

        public Action1[] CreateActions(string camUrl, string camUserName, string camPassword, ActionConfiguration[] actConf)
        {
            using (var proxy = new OnvifProxy(new NetworkCredential(camUserName, camPassword), new Uri(camUrl)))
            {
                return proxy.CreateActionsAsync(actConf).Result;
            }
        }

        public Action1[] CreateActions(ActionConfiguration[] actConf)
        {
            return CreateActions(_url, _userName, _password, actConf);
        }

    }
}
