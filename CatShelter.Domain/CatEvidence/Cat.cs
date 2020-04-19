using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace CatShelter.Domain.CatEvidence
{
    public class Cat
    {
        private readonly IList<CatRecord> _catRecords = new List<CatRecord>();
        private readonly IList<Vaccination> _vaccinations = new List<Vaccination>();

        protected Cat()
        {
        }

        public Cat(string name)
        {
            Name = name;
        }

        public virtual IReadOnlyList<VaccinationInfo> Vaccinations => _vaccinations.Select(i => new VaccinationInfo(i.Disease, i.VaccinationDate)).ToImmutableArray();

        public virtual bool Neutered { get; protected set; }
        public virtual string Name { get; protected set; }
        public virtual int Id { get; set; }

        public virtual bool HasVaccinationAgainst(string diseaseName)
        {
            return _vaccinations.Any(i => i.Disease.Equals(diseaseName, StringComparison.OrdinalIgnoreCase));
        }

        public virtual void RegisterVaccination(VaccinationInfo vaccination)
        {
            _vaccinations.Add(new Vaccination(this, vaccination.Disease, vaccination.VaccinationDate));
            AddRecord($"On {vaccination.VaccinationDate:u} was vaccinated against {vaccination.Disease}");
        }

        public virtual bool MayBeVaccinated(DateTime dateOfVaccination)
        {
            if (dateOfVaccination < DateTime.Now)
            {
                throw new ArgumentOutOfRangeException("Vaccination date is in past");
            }

            return new NoVaccinationInLast20Days(_vaccinations.ToImmutableArray(), DateTime.Now).Satisfies();
        }

        public virtual void NeuterThisCat()
        {
            if (Neutered)
            {
                throw new InvalidOperationException($"Cat {Name} [{Id}] id already neutered.");
            }

            Neutered = true;
            AddRecord("Cat was neutered");
        }

        protected virtual void AddRecord(string text)
        {
            _catRecords.Add(new CatRecord(this,DateTime.Now, text));
        }
    }
}