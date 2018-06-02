using System;

namespace ImpliedValue
{
    public static class ImpliedDecimalExtensions
    {
        
        public static ImpliedDecimal ToImpliedDecimal(this decimal input)
        {
            return new ImpliedDecimal(0);
        }

        public static ImpliedDecimal ToImpliedDecimal(this decimal input, byte fractional)
        {
            return new ImpliedDecimal(0, fractional);
        }

        public static string ToImpliedDecimalString(this decimal input, byte fractional)
        {
            throw new NotImplementedException();
        }

        public static (string value, byte frac) ToImpliedDecimalStringTuple(this decimal input, byte fractional)
        {
            throw new NotImplementedException();
        }
    }
}