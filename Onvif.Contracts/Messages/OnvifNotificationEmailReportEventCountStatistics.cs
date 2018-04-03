namespace Onvif.Contracts.Messages
{
    public class OnvifNotificationEmailReportEventCountStatistics : OnvifNotificationEmailBase
    {
        public OnvifNotificationEmailReportEventCountStatistics(string[] addreses, string serverAlias, Error err) : base(addreses, serverAlias, err)
        {
        }
    }
}
