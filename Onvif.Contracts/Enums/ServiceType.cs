using System.Runtime.Serialization;

namespace Onvif.Contracts.Enums
{
    [DataContract]
    public enum ServiceType
    {
        [EnumMember]
        Encoder,
        [EnumMember]
        Onvif
    }
}
