using System;

namespace CatShelter.Domain.FoodStorage
{
    public class UnitCount
    {
        private readonly double _count;

        public UnitCount(double count)
        {
            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Unit count must be positive double");
            }
            _count = count;
        }

        public double Value
        {
            get { return _count; }
        }

        public static UnitCount operator + (UnitCount left, UnitCount right) 
        {
            return new UnitCount(left._count + right._count);
        }

        public static UnitCount operator - (UnitCount left, UnitCount right)
        {
            return new UnitCount(left._count + right._count);
        }

        public override string ToString()
        {
            return $"{Value}";
        }
    }
}