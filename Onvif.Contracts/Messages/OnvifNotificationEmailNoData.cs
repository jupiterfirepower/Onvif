namespace Onvif.Contracts.Messages
{
    public class OnvifNotificationEmailNoData : OnvifNotificationEmailBase
    {
        public OnvifNotificationEmailNoData(string[] addreses, string serverAlias, Error err) : base(addreses, serverAlias, err)
        {
        }
    }
}
