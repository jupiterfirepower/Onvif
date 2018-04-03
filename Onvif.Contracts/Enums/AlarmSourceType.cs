using System.Runtime.Serialization;

namespace Onvif.Contracts.Enums
{
    [DataContract]
    public enum AlarmSourceType
    {
        [EnumMember]
        Service,
        [EnumMember]
        Server
    }
}
