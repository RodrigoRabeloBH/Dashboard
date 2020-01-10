using System.Collections.Generic;
using System.Threading.Tasks;
using APIDashboard.Data.Interfaces;
using APIDashboard.Models;
using Microsoft.EntityFrameworkCore;

namespace APIDashboard.Data.Repository
{
    public class CostumerRepository : Repository<Costumer>, ICostumer
    {
        public CostumerRepository(DataContext context) : base(context) { }

        public async Task<Costumer> GetCostumerOrders(int id)
        {
            return await _context.Costumers
            .AsNoTracking()
            .Include(c => c.Orders)
            .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}