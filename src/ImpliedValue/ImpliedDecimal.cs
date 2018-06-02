using System;

namespace ImpliedValue
{
    public struct ImpliedDecimal : IComparable,
        IComparable<ImpliedDecimal>,
        IComparable<Decimal>,
        IEquatable<ImpliedDecimal>,
        IEquatable<Decimal>
    {

        public ImpliedDecimal(decimal original) : this(original, 2) { }

        public ImpliedDecimal(int original) : this(original, 2) { }

        public ImpliedDecimal(decimal original, byte scale)
        {
            this.Value = Math.Floor((original * Divisor(scale)));
            this.Scale = scale;
            this.IsDerived = false;
            this.AllowTruncation = false;
        }

        public ImpliedDecimal(int original, byte scale)
        {
            this.Value = Math.Floor((original * Divisor(scale)));
            this.Scale = scale;
            this.IsDerived = false;
            this.AllowTruncation = false;
        }

        public ImpliedDecimal(int original, byte scale, bool allowTruncate)
        {
            this.Value = Math.Floor((original * Divisor(scale)));
            this.Scale = scale;
            this.IsDerived = false;
            this.AllowTruncation = allowTruncate;
        }

        public decimal Value { get; private set; }

        public bool AllowTruncation { get; private set; }

        ///public decimal Value2 { get; private set; } 
        //shift . floor remaining fraction
        /// require flag to floor, else excp? 

        public byte Scale { get; private set; }

        public bool IsDerived { get; set; }

        public (Decimal value, byte scale) ToValueTuple()
        {
            return (this.Value, this.Scale);
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public decimal ToDecimal()
        {
            return this.Value / Divisor(this.Scale);
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