using System.Threading.Tasks;
using APIDashboard.Models;

namespace APIDashboard.Data.Interfaces
{
    public interface ICustomer:IRepository<Customer>
    {
         Task<Customer> GetCustomerOrders(int id);
    }
}