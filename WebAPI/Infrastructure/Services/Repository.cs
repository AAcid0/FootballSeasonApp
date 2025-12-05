using Microsoft.EntityFrameworkCore;
using WebAPI.Infrastructure.Interfaces;

namespace WebAPI.Infrastructure.Services
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DatabaseDBContext _context;

        public Repository(DatabaseDBContext context)
        {
            _context = context;
        }

        protected DbSet<T> EntitySet
        {
            get { return _context.Set<T>(); }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await EntitySet.ToListAsync();
        }
        
        public async Task<T?> GetByIdAsync(int id)
        {
            return await EntitySet.FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            await EntitySet.AddAsync(entity);
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<T> DeleteAsync(int id)
        {
            T entity = await EntitySet.FindAsync(id);
            
            if (entity != null){
                EntitySet.Remove(entity);
            }

            return entity;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    } 
}