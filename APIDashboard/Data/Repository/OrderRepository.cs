using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIDashboard.Data.Interfaces;
using APIDashboard.Models;
using Microsoft.EntityFrameworkCore;

namespace APIDashboard.Data.Repository
{
    public class OrderRepository : Repository<Order>, IOrder
    {
        public OrderRepository(DataContext context) : base(context) { }

        public async Task<Customer> GetCostumerByOrdeId(int orderId)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == orderId);
            return await _context.Customers.FirstOrDefaultAsync(c => c.Id == order.Customer.Id);
        }

        public async Task<Order> GetOrderCustomer(int id)
        {
            return await _context.Orders
                .AsNoTracking()
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<IEnumerable<Order>> GetOrdersByDate(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.Orders select obj;

            if (minDate.HasValue) result = result.Where(r => r.Placed >= minDate.Value);
            if (maxDate.HasValue) result = result.Where(r => r.Placed <= maxDate.Value);
            return await result
                        .Include(r => r.Customer)
                        .OrderByDescending(r => r.Placed)
                        .ToListAsync();
        }

        public async Task<Customer> GetCustomer(int customerId)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Id == customerId);
        }
    }
}