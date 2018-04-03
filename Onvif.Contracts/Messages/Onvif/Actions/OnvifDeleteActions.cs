namespace Onvif.Contracts.Messages.Onvif.Actions
{
    public class OnvifDeleteActions : OnvifBase
    {
        public string[] Actions { get; private set; }

        public OnvifDeleteActions(string uri, string userName, string password, string[] actions)
            : base(uri, userName, password)
        {
            Actions = actions;
        }
    }
}
