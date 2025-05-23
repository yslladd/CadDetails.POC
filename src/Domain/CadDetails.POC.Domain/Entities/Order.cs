using System.Collections.Generic;
using System;

namespace CadDetails.POC.Domain.Entities
{
    public class Order
    {
        public List<Product> Products { get; set; } = new();
        public bool IsCancelled { get; set; }
        public DateTime CreatedAt { get; set; }
        public double? DiscountRate { get; set; }

        public bool ShouldProcess()
        {
            return !IsCancelled && CreatedAt >= DateTime.UtcNow.AddYears(-1) && Products?.Any(p => p.IsValid()) == true;
        }

        public double GetTotal()
        {
            if (Products == null) return 0;

            var subtotal = Products
                .Where(p => p != null && p.IsValid())
                .Sum(p => p.GetTotal());

            var discount = DiscountRate ?? 0;
            return subtotal * (1 - discount);
        }
    }
}