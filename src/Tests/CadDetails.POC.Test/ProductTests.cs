using CadDetails.POC.Domain.Entities;
using Xunit;

namespace CadDetails.POC.Test
{

    public class ProductTests
    {
        [Theory]
        [InlineData(10, 1, true)]
        [InlineData(-1, 1, false)]
        [InlineData(10, -2, false)]
        [InlineData(0, 0, true)]
        public void IsValid_ReturnsExpected(double price, int quantity, bool expected)
        {
            var product = new Product { Price = price, Quantity = quantity };
            Assert.Equal(expected, product.IsValid());
        }

        [Fact]
        public void GetTotal_ReturnsZero_IfInvalid()
        {
            var product = new Product { Price = -10, Quantity = 5 };
            Assert.Equal(0, product.GetTotal());
        }

        [Fact]
        public void GetTotal_ReturnsCorrectTotal_IfValid()
        {
            var product = new Product { Price = 10, Quantity = 2 };
            Assert.Equal(20, product.GetTotal());
        }
    }

}
