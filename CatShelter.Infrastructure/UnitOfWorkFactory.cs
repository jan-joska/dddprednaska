using CatShelter.Domain.CatEvidence;
using NHibernate;

namespace CatShelter.Infrastructure
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly ISessionFactory _sessionFactory;

        public UnitOfWorkFactory(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public IUnitOfWork Create()
        {
            return new UnitOfWork(_sessionFactory);
        }
    }
}