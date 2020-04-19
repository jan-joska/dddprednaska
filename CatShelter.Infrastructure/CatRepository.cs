using System.Linq;
using CatShelter.Application;
using CatShelter.Domain;
using CatShelter.Domain.CatEvidence;
using NHibernate;

namespace CatShelter.Infrastructure
{
    public class CatRepository : ICatRepository
    {
        private  IUnitOfWork _uow;
        
        public void Save(Cat cat)
        {
            _uow.SaveOrUpdate(cat);
        }

        public Maybe<Cat> GetById(int id)
        {
            return _uow.Query<Cat>().SingleOrDefault(i => i.Id == id);
        }

        public void InjectUow(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void Inject(IUnitOfWork uow)
        {
            _uow = uow;
        }
    }
}