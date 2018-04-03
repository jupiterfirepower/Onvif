using System;
using Onvif.Contracts.Extentions;

namespace Onvif.Contracts.Messages
{
    public class StopChildActors
    {
        public Guid Stamp { get; private set; }

        public StopChildActors(Guid stamp)
        {
            Stamp = stamp;
        }

        public override string ToString()
        {
            return string.Format("{0} Stamp - {1}", this.NameOf(), Stamp);
        }
    }
}
