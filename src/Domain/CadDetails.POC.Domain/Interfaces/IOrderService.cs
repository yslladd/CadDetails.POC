using CadDetails.POC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadDetails.POC.Domain.Interfaces
{
    public interface IOrderService : IDisposable
    {
        double CalculateTotalRevenue(IEnumerable<Order> orders);
    }
}
