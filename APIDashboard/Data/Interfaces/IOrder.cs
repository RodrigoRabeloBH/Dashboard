using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIDashboard.Models;

namespace APIDashboard.Data.Interfaces
{
    public interface IOrder : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByDate(DateTime? minDate, DateTime? maxDate);
        Task<Customer> GetCostumerByOrdeId(int oderId);
        Task<Order> GetOrderCustomer(int id);
        Task<Customer> GetCustomer(int customerId);
    }
}