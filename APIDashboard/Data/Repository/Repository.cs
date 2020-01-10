using System.Collections.Generic;
using System.Threading.Tasks;
using APIDashboard.Data.Interfaces;
using APIDashboard.Models;
using Microsoft.EntityFrameworkCore;

namespace APIDashboard.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _context.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public async Task Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(TEntity entity)
        {
            if (entity != null)
            {
                _context.Set<TEntity>().Update(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Remove(int id)
        {
            _context.Set<TEntity>().Remove(await GetById(id));
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}