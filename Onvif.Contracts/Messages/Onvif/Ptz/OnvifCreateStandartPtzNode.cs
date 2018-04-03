namespace Onvif.Contracts.Messages.Onvif.Ptz
{
    public class OnvifCreateStandartPtzNode : OnvifBase
    {
        public string NodeToken { get; private set; }

        public OnvifCreateStandartPtzNode(string uri, string userName, string password, string nodeToken)
            : base(uri, userName, password)
        {
            NodeToken = nodeToken;
        }
    }
}
