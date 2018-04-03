namespace Onvif.Contracts.Messages
{
    public class OnvifNotificationEmailMemoryLeaks : OnvifNotificationEmailBase
    {
        public OnvifNotificationEmailMemoryLeaks(string[] addreses, string serverAlias, Error err) : base(addreses, serverAlias, err)
        {
        }
    }
}
