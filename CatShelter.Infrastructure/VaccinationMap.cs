using CatShelter.Domain.CatEvidence;
using FluentNHibernate.Mapping;

namespace CatShelter.Infrastructure
{
    public class VaccinationMap : ClassMap<Vaccination>
    {
        public VaccinationMap()
        {

            Id(i => i.Id).GeneratedBy.Identity();
            Map(i => i.Disease);
            Map(i => i.VaccinationDate);
            References<Cat>(i => i.Cat).Column("CatId");

            /*   Cat = cat;
            Disease = disease;
            VaccinationDate = vaccinationDate;*/

        }
    }
}