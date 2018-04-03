using onvif.services;

namespace Onvif.Contracts.Messages.Onvif.Metadata
{
    public class OnvifSetMetadataConfiguration : OnvifBase
    {
        public MetadataConfiguration MetadataConfiguration { get; private set; }

        public OnvifSetMetadataConfiguration(string uri, string userName, string password, MetadataConfiguration metadataConfiguration)
            : base(uri, userName, password)
        {
            MetadataConfiguration = metadataConfiguration;
        }
    }
}
