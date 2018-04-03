namespace Onvif.Contracts.Messages.Onvif.Ptz
{
    public class OnvifPtzSendAuxiliaryCommand : OnvifBase
    {
        public string ProfileToken { get; private set; }
        public string AuxData { get; private set; }

        public OnvifPtzSendAuxiliaryCommand(string uri, string userName, string password, string profileToken, string auxData)
            : base(uri, userName, password)
        {
            ProfileToken = profileToken;
            AuxData = auxData;
        }
    }
}
