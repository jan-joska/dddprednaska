using System.Text.Json;

namespace CatShelter.Domain.CatEvidence
{
    public class CatEvent
    {
        protected CatEvent()
        {
            
        }

        public CatEvent(Cat cat, object eventData)
        {
            Cat = cat;
            EventType = eventData.GetType().FullName;
            EventData = JsonSerializer.Serialize(eventData, eventData.GetType(), new JsonSerializerOptions() {WriteIndented = true});
        }

        public virtual Cat Cat { get; protected set; }
        public virtual string EventType { get; protected set; }
        public virtual string EventData { get; protected set; }
    }
}