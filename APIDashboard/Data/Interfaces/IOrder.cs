using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIDashboard.Models;

namespace APIDashboard.Data.Interfaces
{
    public interface IOrder : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByDate(DateTime? minDate, DateTime? maxDate);
        Task<Costumer> GetCostumerByOrdeId(int oderId);
    }
}