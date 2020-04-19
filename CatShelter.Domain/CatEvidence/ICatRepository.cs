using System;
using System.Collections.Generic;
using System.Text;

namespace CatShelter.Domain.CatEvidence
{
    public interface ICatRepository
    {

        void Save(Cat cat);


        Cat GetById(int id);

    }
}
