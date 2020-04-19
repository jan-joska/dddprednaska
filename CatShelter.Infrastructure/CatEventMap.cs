using CatShelter.Domain.CatEvidence;
using FluentNHibernate.Mapping;

namespace CatShelter.Infrastructure
{
    public class CatEventMap : ClassMap<CatEvent>
    {
        public CatEventMap()
        {
            Id().GeneratedBy.Identity();
            References<Cat>(i => i.Cat).Column("CatId");
            Map(i => i.EventType);
            Map(i => i.EventData);
        }
    }
}