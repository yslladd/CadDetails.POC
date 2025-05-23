using Xunit;
using System;
using System.Collections.Generic;
using CadDetails.POC.Domain.Entities;
using CadDetails.POC.Domain.Interfaces;
using CadDetails.POC.Domain.Services;

namespace CadDetails.POC.Test
{ 

    public class OrderServiceTests
    {
        private readonly IOrderService _service = new OrderService();

        [Fact]
        public void CalculateTotalRevenue_ReturnsZero_IfNullList()
        {
            Assert.Equal(0, _service.CalculateTotalRevenue(null));
        }

        [Fact]
        public void CalculateTotalRevenue_IgnoresInvalidOrders()
        {
            var orders = new List<Order>
        {
            new Order { IsCancelled = true, CreatedAt = DateTime.UtcNow },
            new Order { CreatedAt = DateTime.UtcNow.AddYears(-2) },
            new Order
            {
                CreatedAt = DateTime.UtcNow,
                Products = new List<Product> { new Product { Price = -1, Quantity = 1 } }
            }
        };

            Assert.Equal(0, _service.CalculateTotalRevenue(orders));
        }

        [Fact]
        public void CalculateTotalRevenue_ReturnsCorrectTotal_ForValidOrders()
        {
            var orders = new List<Order>
        {
            new Order
            {
                CreatedAt = DateTime.UtcNow,
                DiscountRate = 0.1,
                Products = new List<Product> { new Product { Price = 100, Quantity = 1 } }
            },
            new Order
            {
                CreatedAt = DateTime.UtcNow,
                Products = new List<Product> { new Product { Price = 50, Quantity = 2 } }
            }
        };

            var expected = 100 * 0.9 + 100;
            Assert.Equal(expected, _service.CalculateTotalRevenue(orders), 2);
        }
    }

}
