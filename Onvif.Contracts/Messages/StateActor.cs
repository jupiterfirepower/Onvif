using Onvif.Contracts.Enums;

namespace Onvif.Contracts.Messages
{
    public class StateActor
    {
        public State State { get; private set; }

        public StateActor(State state)
        {
            State = state;
        }
    }
}
