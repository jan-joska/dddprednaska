using System;
using System.Collections.Generic;
using System.Text;

namespace CatShelter.Domain.CatEvidence
{
    public interface IUowInjectable
    {
        void Inject(IUnitOfWork uow);
    }

    public interface ICatRepository : IUowInjectable
    {
        void Save(Cat cat);
        Maybe<Cat> GetById(int id);

    }
}
