using System;
using Xunit;
using ImpliedValue;

namespace ImpliedValue.Tests
{
    public class ImpliedDecimalTests
    {

        [Theory]
        [InlineData(10, 2, "1000")]
        [InlineData(123, 3, "123000")]
        [InlineData(-100, 0, "-100")]
        public void ToStringBasic(int number, byte scale, string expected)
        {
            Assert.Equal(expected, new ImpliedDecimal(number, scale).ToString());
        }

        [Fact]
        public void ToStringFormatted()
        {
            Assert.Equal("(100)", new ImpliedDecimal(-100, 0).ToString("p"));
            Assert.Equal("(10000)", new ImpliedDecimal(-100, 2).ToString("p"));
            Assert.Equal("-100", new ImpliedDecimal(-100, 0).ToString("x"));
        }


        [Fact]
        public void DecimalConversion()
        {
            var a = new ImpliedDecimal(10.0m, 2);

            Assert.NotEqual(10.00m, a.Value);
            Assert.Equal(10.00m, (decimal)a);
            Assert.Equal(10.00m, a.ToDecimal());
        }

        [Fact]
        public void DecimalOverflow()
        {
            Assert.Throws(typeof(OverflowException), () =>
            {
                new ImpliedDecimal(Decimal.MaxValue, 2);
            });
        }

        [Fact]
        public void DecimalTruncationException()
        {
            Assert.Throws(typeof(InvalidOperationException), () =>
            {
                var i = new ImpliedDecimal(1000, 2);
                i.ToDecimal(1, truncate: true);
            });
        }

        [Fact]
        public void DecimalTruncation()
        {
            var a = new ImpliedDecimal(1234.56m, 2, allowTruncate: true);

            Assert.Equal(12345, a.ToDecimal(1, true));
            Assert.Equal(1234, a.ToDecimal(0, true));
        }

        [Fact]
        public void EqualityCheck()
        {
            var a = new ImpliedDecimal(10.0m, 2);
            var b = new ImpliedDecimal(10.0m, 2);
            var c = new ImpliedDecimal(10.0m, 4);
            //var d = new ImpliedDecimal(1000m, 2);

            Assert.True(a == b);
            Assert.True(a != c);
            //Assert.True(c != d);
        }
    }
}
