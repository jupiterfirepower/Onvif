namespace Onvif.Contracts.Messages.Onvif.Actions
{
    public class OnvifDeleteActionTriggers : OnvifBase
    {
        public string[] Triggers { get; private set; }

        public OnvifDeleteActionTriggers(string uri, string userName, string password, string[] triggers)
            : base(uri, userName, password)
        {
            Triggers = triggers;
        }
    }
}
