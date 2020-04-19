using System;
using System.Collections.Generic;
using System.Linq;

namespace CatShelter.Domain.CatEvidence
{
    internal class NoVaccinationInLast20Days
    {
        private readonly IReadOnlyList<Vaccination> _vaccinations;
        private readonly DateTime _date;

        public NoVaccinationInLast20Days(IReadOnlyList<Vaccination> vaccinations, DateTime date)
        {
            _vaccinations = vaccinations;
            _date = date;
        }

        public bool Satisfies()
        {
            return _vaccinations.Any(i => _date.Subtract((DateTime) i.VaccinationDate).TotalDays < 20);
        }
    }
}