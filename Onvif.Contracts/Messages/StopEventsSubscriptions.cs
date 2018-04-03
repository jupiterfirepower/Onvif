using System;
using Onvif.Contracts.Extentions;

namespace Onvif.Contracts.Messages
{
    public class StopEventsSubscriptions
    {
        public Guid Stamp { get; private set; }

        public StopEventsSubscriptions(Guid stamp)
        {
            Stamp = stamp;
        }

        public override string ToString()
        {
            return string.Format("{0} Stamp - {1}", this.NameOf(), Stamp);
        }
    }
}
