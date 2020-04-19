using System;
using System.Collections.Generic;
using System.Text;

namespace CatShelter.Application
{
    public class CatListItemDto
    {
        public int Id { get; set; }
        public string Name { get;set;}

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}";
        }
    }

    public interface IGetCatListdQuery
    {
        IReadOnlyList<CatListItemDto> GetList();
    }
}
