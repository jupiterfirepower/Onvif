namespace Onvif.Contracts.Messages
{
    public class OnvifNotificationEmailNetworkError : OnvifNotificationEmailBase
    {
        public OnvifNotificationEmailNetworkError(string[] addreses, string serverAlias, Error err) : base(addreses, serverAlias, err)
        {
        }
    }
}
