using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIDashboard.Models;

namespace APIDashboard.Data.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Create(TEntity entity);
        Task Edit(TEntity entity);
        Task Remove(int id);
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll();
    }
}