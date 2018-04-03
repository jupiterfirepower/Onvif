namespace Onvif.Contracts.Messages
{
    public class GeneralNotificationEmail : OnvifNotificationEmailBase
    {
        public GeneralNotificationEmail(string[] addreses, string serverAlias, Error err) : base(addreses, serverAlias, err)
        {
        }
    }
}
