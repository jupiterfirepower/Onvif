using onvif.services;

namespace Onvif.Contracts.Messages.Onvif.Control
{
    public class OnvifCameraReset : OnvifBase
    {
        public FactoryDefaultType ResetType { get; private set; }

        public OnvifCameraReset(string uri, string userName, string password, FactoryDefaultType resetType)
            : base(uri, userName, password)
        {
            ResetType = resetType;
        }
    }
}
