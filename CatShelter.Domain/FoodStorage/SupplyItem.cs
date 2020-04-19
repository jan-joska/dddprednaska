using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace CatShelter.Domain.FoodStorage
{
    public class SupplyItem
    {
        public string Name { get; }
        public Unit Unit { get; }
        public UnitCount UnitCount { get; }

        public SupplyItem(string name, Unit unit, UnitCount unitCount)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(name));
            }
            Name = name;
            Unit = unit ?? throw new ArgumentNullException(nameof(unit));
            UnitCount = unitCount ?? throw new ArgumentNullException(nameof(unitCount));
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Unit)}: {Unit}, {nameof(UnitCount)}: {UnitCount}";
        }
    }
}
