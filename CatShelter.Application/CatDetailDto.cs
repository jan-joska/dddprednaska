using System.Collections.Generic;

namespace CatShelter.Application
{
    public class CatDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsNeutered { get; set; }
        public List<string> Vaccinations = new List<string>();

        public override string ToString()
        {
            return $"{nameof(Vaccinations)}: {string.Join(",",Vaccinations)}, {nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(IsNeutered)}: {IsNeutered}";
        }
    }
}