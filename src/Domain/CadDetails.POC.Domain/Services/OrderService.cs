using CadDetails.POC.Domain.Entities;
using CadDetails.POC.Domain.Interfaces;

namespace CadDetails.POC.Domain.Services
{
    public class OrderService : IOrderService
    {
        public double CalculateTotalRevenue(IEnumerable<Order> orders)
        {
            if (orders == null) return 0;

            return orders
                .Where(order => order?.ShouldProcess() == true)
                .Sum(order => order.GetTotal());
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
