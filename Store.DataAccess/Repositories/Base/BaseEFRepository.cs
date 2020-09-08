using Microsoft.EntityFrameworkCore;
using Store.DataAccess.AppContext;
using Store.DataAccess.Entities.Base;
using Store.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.DataAccess.Repositories.Base
{
    public class BaseEFRepository<T> : IRepository<T> where T : class, IBaseEntity
    {
        private readonly ApplicationContext _context;
        protected DbSet<T> _entityDbSet;
        public BaseEFRepository(ApplicationContext context)
        {
            _context = context;
            _entityDbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entityDbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(long id)
        {
            return await _entityDbSet.FindAsync(id);
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _entityDbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            var currentEntity = await _entityDbSet.FirstOrDefaultAsync(ce => ce.Id == entity.Id);
            currentEntity = _context.Update(entity).Entity;
            await _context.SaveChangesAsync();
            return currentEntity;
        }

        public async Task DeleteAsync(long id)
        {
            var entity = _entityDbSet.Find(id);
            _entityDbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
