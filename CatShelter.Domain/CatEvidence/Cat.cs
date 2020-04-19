using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace CatShelter.Domain.CatEvidence
{
    public interface IDomainEvent
    {
    }

    public class CatNeuteredEvent : IDomainEvent
    {
        public DateTime NeuteredDate { get; set; }
        public string InitiatedBy { get; set; }
    }

    public class Cat
    {
        private readonly IList<CatRecord> _catRecords = new List<CatRecord>();
        private readonly IList<CatEvent> _domainEvents = new List<CatEvent>();
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
            RaiseDomainEvent(new CatNeuteredEvent
            {
                InitiatedBy = Environment.UserName,
                NeuteredDate = DateTime.Now
            });
        }

        public virtual void AddRecord(string text)
        {
            _catRecords.Add(new CatRecord(this, DateTime.Now, text));
        }

        protected virtual void RaiseDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(new CatEvent(this, domainEvent));
        }
    }
}