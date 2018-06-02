using System;
using Xunit;
using ImpliedValue;

namespace ImpliedValue.Tests
{
    public class ImpliedDecimalTests
    {
        [Fact]
        public void ScaleIsPreserved()
        {
            var a = new ImpliedDecimal(10.0m, 2);

            Assert.Equal((decimal)1000, a);
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
        public void EqualityCheck()
        {
            var a = new ImpliedDecimal(10.0m, 2);
            var b = new ImpliedDecimal(10.0m, 2);
            var c = new ImpliedDecimal(10.0m, 4);

            Assert.True(a == b);
            Assert.True(a != c);
        }

        [Theory]
        [InlineData(null)]
        public void Theories(decimal input)
        {
            //Assert.Throws(typeof(ArgumentNullException), () => new ImpliedDecimal(input));
        }
    }
}
