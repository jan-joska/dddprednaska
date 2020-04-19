using CatShelter.Domain.CatEvidence;
using FluentNHibernate.Mapping;

namespace CatShelter.Infrastructure
{
    public class CatRecordMap : ClassMap<CatRecord>
    {
        public CatRecordMap()
        {
            Id().GeneratedBy.Identity();
            Map(i => i.Date);
            Map(i => i.Text);
            References<Cat>(i => i.Cat).Column("CatId");
        }
    }
}