using System.Collections.Generic;
using System.Threading.Tasks;
using APIDashboard.Data.Interfaces;
using APIDashboard.Models;
using Microsoft.EntityFrameworkCore;

namespace APIDashboard.Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomer
    {
        public CustomerRepository(DataContext context) : base(context) { }

        public async Task<Customer> GetCustomerOrders(int id)
        {
            return await _context.Customers
            .AsNoTracking()
            .Include(c => c.Orders)
            .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}