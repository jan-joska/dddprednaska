using CatShelter.Domain.CatEvidence;
using FluentNHibernate;
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

    public class CatMap : ClassMap<Cat>
    {
        public CatMap()
        {
            Id(i => i.Id).GeneratedBy.Identity();
            HasMany<Vaccination>(Reveal.Member<Cat>("_vaccinations")).Cascade.All().Inverse();
            HasMany<CatRecord>(Reveal.Member<Cat>("_catRecords")).Cascade.All().Inverse();
            Map(i => i.Neutered);
            Map(i => i.Name);
        }
    }
}