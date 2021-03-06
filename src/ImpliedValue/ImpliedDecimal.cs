﻿using System;

namespace ImpliedValue
{
    public struct ImpliedDecimal : IComparable,
        IComparable<ImpliedDecimal>,
        IComparable<Decimal>,
        IEquatable<ImpliedDecimal>,
        IEquatable<Decimal>
    {
        public ImpliedDecimal(decimal original) : this(original, 2) { }

        public ImpliedDecimal(decimal original, byte scale)
            : this(original, scale, false) { }

        public ImpliedDecimal(decimal original, byte scale, bool allowTruncate)
        {
            this.Value = Math.Floor((original * Divisor(scale)));
            this.Scale = scale;
            this.IsDerived = false;
            this.AllowTruncation = allowTruncate;
        }

        public decimal Value { get; private set; }

        public bool AllowTruncation { get; private set; }

        public byte Scale { get; private set; }

        public bool IsDerived { get; set; }

        public (Decimal value, byte scale) ToValueTuple()
        {
            return (this.Value, this.Scale);
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }

        public string ToString(string format)
        {
            if (format == "p" && Math.Sign(this.Value) == -1)
            {
                var val = Math.Abs(this.Value).ToString();
                return $"({val})";
            }
            else
            {
                return this.ToString();
            }
        }

        public decimal ToDecimal()
        {
            return this.Value / Divisor(this.Scale);
        }

        public decimal ToDecimal(byte scale, bool truncate = false)
        {
            if (truncate && !this.AllowTruncation)
            {
                throw new InvalidOperationException(
                    $"Truncation not allowed unless value is constructed with {nameof(this.AllowTruncation)} set to true.");
            }
            int s = scale;
            if (truncate && scale < this.Scale)
            {
                s = (int)this.Scale - (int)scale;
            }
            return Math.Floor(this.Value / Divisor((byte)s));
        }

        public static implicit operator Decimal(ImpliedDecimal d)
        {
            return d.Value / Divisor(d.Scale);
        }

        internal static decimal Divisor(byte scale) => (decimal)Math.Pow(10, scale);

        int IComparable.CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        int IComparable<ImpliedDecimal>.CompareTo(ImpliedDecimal other)
        {
            throw new NotImplementedException();
        }

        int IComparable<decimal>.CompareTo(decimal other)
        {
            throw new NotImplementedException();
        }

        bool IEquatable<ImpliedDecimal>.Equals(ImpliedDecimal other)
        {
            throw new NotImplementedException();
        }

        bool IEquatable<decimal>.Equals(decimal other)
        {
            // if scale in other >= this.Scale ...
            throw new NotImplementedException();
        }

        public static bool operator ==(ImpliedDecimal item1, ImpliedDecimal item2)
        {
            if (object.ReferenceEquals(item1, item2)) { return true; }
            if ((object)item1 == null || (object)item2 == null) { return false; }
            return item1.Value == item2.Value;
        }

        public static bool operator !=(ImpliedDecimal item1, ImpliedDecimal item2)
        {
            return !(item1 == item2);
        }

        public override bool Equals(object o)
        {
            //if (!object.ReferenceEquals(item1, item2)) { return true; }
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}