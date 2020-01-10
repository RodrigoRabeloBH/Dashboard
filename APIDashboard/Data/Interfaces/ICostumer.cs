using System.Collections.Generic;
using System.Threading.Tasks;
using APIDashboard.Models;

namespace APIDashboard.Data.Interfaces
{
    public interface ICostumer:IRepository<Costumer>
    {
         Task<Costumer> GetCostumerOrders(int id);
    }
}