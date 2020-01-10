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

        public async Task<Costumer> GetCostumerByOrdeId(int orderId)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == orderId);
            return await _context.Costumers.FirstOrDefaultAsync(c => c.Id == order.Costumer.Id);
        }

        public async Task<IEnumerable<Order>> GetOrdersByDate(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.Orders select obj;

            if (minDate.HasValue) result = result.Where(r => r.Placed >= minDate.Value);
            if (maxDate.HasValue) result = result.Where(r => r.Placed <= maxDate.Value);
            return await result
                        .Include(r => r.Costumer)
                        .OrderByDescending(r => r.Placed)
                        .ToListAsync();
        }
    }
}