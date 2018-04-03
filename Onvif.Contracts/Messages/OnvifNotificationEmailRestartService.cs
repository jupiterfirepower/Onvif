namespace Onvif.Contracts.Messages
{
    public class OnvifNotificationEmailRestartService : OnvifNotificationEmailBase
    {
        public OnvifNotificationEmailRestartService(string[] addreses, string serverAlias, Error err) : base(addreses, serverAlias, err)
        {
        }
    }
}
