using System;

namespace CatShelter.Domain.CatEvidence
{
    public class Vaccination
    {
        public virtual int Id { get; protected set; }
        public virtual string Disease { get; protected set; }
        public virtual DateTime VaccinationDate { get; protected set; }
        public virtual Cat Cat { get; protected set; }

        protected Vaccination()
        {
        }

        public Vaccination(Cat cat, string disease, DateTime vaccinationDate)
        {
            Cat = cat;
            Disease = disease;
            VaccinationDate = vaccinationDate;
        }

        public override string ToString()
        {
            return $"{nameof(Disease)}: {Disease}, {nameof(VaccinationDate)}: {VaccinationDate}";
        }
    }
}