using System;

namespace ImpliedValue
{
    public static class ImpliedDecimalExtensions
    {
        
        public static ImpliedDecimal ToImpliedDecimal(this decimal input)
        {
            return new ImpliedDecimal(0);
        }

        public static ImpliedDecimal ToImpliedDecimal(this decimal input, byte scale)
        {
            return new ImpliedDecimal(0, scale);
        }

        public static string ToImpliedDecimalString(this decimal input, byte scale)
        {
            return new ImpliedDecimal(0, scale).ToString();
        }
    }
}