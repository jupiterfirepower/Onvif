namespace Onvif.Contracts.Messages.Onvif.Ptz
{
    public class OnvifPtzGetNode : OnvifBase
    {
        public string NodeToken { get; private set; }

        public OnvifPtzGetNode(string uri, string userName, string password, string nodeToken)
            : base(uri, userName, password)
        {
            NodeToken = nodeToken;
        }
    }
}
