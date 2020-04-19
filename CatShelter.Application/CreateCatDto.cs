using System;

namespace CatShelter.Application
{

    public class CreateCatDto
    {
        public string Name { get; }
        public CreateCatDto(string name)
        {
            Name = name;
        }
    }
}
