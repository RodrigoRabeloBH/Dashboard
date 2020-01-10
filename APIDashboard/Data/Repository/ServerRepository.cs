using APIDashboard.Data.Interfaces;
using APIDashboard.Models;

namespace APIDashboard.Data.Repository
{
    public class ServerRepository : Repository<Server>, IServer
    {
        public ServerRepository(DataContext context) : base(context) { }

    }
}