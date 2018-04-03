using System.Collections.ObjectModel;

namespace Onvif.Contracts.Model
{
    public class EventsStorage
    {

        public EventsStorage()
        {
            EventsCollection = new ObservableCollection<EventDescriptor>();
        }
        public void AddEvent(EventDescriptor ev)
        {
            EventsCollection.Add(ev);
            while (EventsCollection.Count > 1000)
                EventsCollection.RemoveAt(0);
        }
        public void Clear()
        {
            EventsCollection.Clear();
        }

        public ObservableCollection<EventDescriptor> EventsCollection { get; protected set; }
    }
}
