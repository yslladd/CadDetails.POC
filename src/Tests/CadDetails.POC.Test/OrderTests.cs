using Xunit;
using System;
using System.Collections.Generic;
using CadDetails.POC.Domain.Entities;

namespace CadDetails.POC.Test
{
  
    public class OrderTests
    {
        [Fact]
        public void ShouldProcess_ReturnsFalse_IfCancelled()
        {
            var order = new Order
            {
                IsCancelled = true,
                CreatedAt = DateTime.UtcNow,
                Products = new List<Product> { new Product { Price = 10, Quantity = 1 } }
            };

            Assert.False(order.ShouldProcess());
        }

        [Fact]
        public void ShouldProcess_ReturnsFalse_IfOlderThanOneYear()
        {
            var order = new Order
            {
                CreatedAt = DateTime.UtcNow.AddYears(-2),
                Products = new List<Product> { new Product { Price = 10, Quantity = 1 } }
            };

            Assert.False(order.ShouldProcess());
        }

        [Fact]
        public void ShouldProcess_ReturnsFalse_IfNoValidProducts()
        {
            var order = new Order
            {
                CreatedAt = DateTime.UtcNow,
                Products = new List<Product> { new Product { Price = -10, Quantity = 1 } }
            };

            Assert.False(order.ShouldProcess());
        }

        [Fact]
        public void ShouldProcess_ReturnsTrue_IfValid()
        {
            var order = new Order
            {
                CreatedAt = DateTime.UtcNow,
                Products = new List<Product> { new Product { Price = 10, Quantity = 1 } }
            };

            Assert.True(order.ShouldProcess());
        }

        [Fact]
        public void GetTotal_AppliesDiscountCorrectly()
        {
            var order = new Order
            {
                DiscountRate = 0.1,
                Products = new List<Product>
            {
                new Product { Price = 100, Quantity = 1 },
                new Product { Price = 50, Quantity = 2 }
            }
            };

            var expectedTotal = (100 + 100) * 0.9;
            Assert.Equal(expectedTotal, order.GetTotal(), 2);
        }

        [Fact]
        public void GetTotal_IgnoresInvalidProducts()
        {
            var order = new Order
            {
                DiscountRate = 0.2,
                Products = new List<Product>
            {
                new Product { Price = -100, Quantity = 2 },
                new Product { Price = 50, Quantity = 1 }
            }
            };

            Assert.Equal(40, order.GetTotal(), 2);
        }
    }

}