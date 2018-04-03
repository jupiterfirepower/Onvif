namespace Onvif.Contracts.Messages
{
    public class OnvifNotificationEmailBase
    {
        public string[] Addreses { get; private set; }
        public Error Err { get; private set; }

        public string ServerAlias { get; private set; }

        public OnvifNotificationEmailBase(string[] addreses, string serverAlias, Error err)
        {
            Err = err;
            ServerAlias = serverAlias;
            Addreses = addreses;
        }

        public override string ToString()
        {
            return string.Format("Addreses - {0},ServerAlias - {1}, Message - {2} ", string.Join(",", Addreses), ServerAlias, Err.Mesage ?? string.Empty);
        }
    }
}
