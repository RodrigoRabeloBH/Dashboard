using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIDashboard.Dto.Order;
using APIDashboard.Models;

namespace APIDashboard.Data.Interfaces
{
    public interface IOrder : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByDate(DateTime? minDate, DateTime? maxDate);
        Task<IEnumerable<Order>> GetAllOrdersAndCustomer();
        Task<IEnumerable<OrderListStateDto>> GetByState();
        Task<IEnumerable<OrderListCustomerDto>> GetByCustomer(int n);
        Task<Customer> GetCostumerByOrdeId(int oderId);
        Task<Order> GetOrderCustomer(int id);
        Task<Customer> GetCustomer(int customerId);
    }
}