using System.Linq;
using CatShelter.Domain.CatEvidence;
using NHibernate;

namespace CatShelter.Infrastructure
{
    public class CatRepository : ICatRepository
    {
        private readonly ISession _session;

        public CatRepository(ISession session)
        {
            _session = session;
        }

        public void Save(Cat cat)
        {
            _session.SaveOrUpdate(cat);
        }

        public Cat GetById(int id)
        {
            return _session.Query<Cat>().SingleOrDefault(i => i.Id == id);
        }
    }
}