namespace Onvif.Contracts.Messages
{
    public class OnvifNotificationEmailNoEvent : OnvifNotificationEmailBase
    {
        public OnvifNotificationEmailNoEvent(string[] addreses, string serverAlias, Error err) : base(addreses, serverAlias, err)
        {
        }
    }
}
