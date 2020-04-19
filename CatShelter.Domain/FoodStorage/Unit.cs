using System;

namespace CatShelter.Domain.FoodStorage
{
    public class Unit
    {
        public string Name { get; }
        public Unit(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(name));
            }
            Name = name;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
        
    }
}