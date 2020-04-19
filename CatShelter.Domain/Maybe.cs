using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CatShelter.Domain
{
    public struct Maybe<T>
    {
        private readonly T _value;

        public T Value
        {
            get
            {
                if (!HasValue)
                {
                    throw new InvalidOperationException("Maybe object has no consumale value");
                }

                return _value;
            }
        }

        public bool HasValue
        {
            get { return _value != null; }
        }

        public bool HasNoValue
        {
            get { return !HasValue; }
        }

        private Maybe([AllowNull] T value)
        {
            _value = value;
        }

        public static implicit operator Maybe<T>([AllowNull] T value)
        {
            return new Maybe<T>(value);
        }
    }
}
