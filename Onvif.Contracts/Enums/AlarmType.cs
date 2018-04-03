using System.Runtime.Serialization;

namespace Onvif.Contracts.Enums
{
    [DataContract]
    public enum AlarmType
    {
        [EnumMember]
        Start,
        [EnumMember]
        Stop
    }
}
