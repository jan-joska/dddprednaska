using System;

namespace CatShelter.Domain.CatEvidence
{
    public class VaccinationInfo
    {
        public VaccinationInfo(string disease, DateTime vaccinationDate)
        {
            Disease = disease;
            VaccinationDate = vaccinationDate;
        }
        public string Disease { get;  }
        public DateTime VaccinationDate { get; }

        public override string ToString()
        {
            return $"{nameof(Disease)}: {Disease}, {nameof(VaccinationDate)}: {VaccinationDate}";
        }
    }
}