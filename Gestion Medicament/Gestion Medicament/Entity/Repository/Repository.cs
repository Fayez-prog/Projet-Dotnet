using Gestion_Medicament.Data;
using Gestion_Medicament.Entity.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Gestion_Medicament.Entity.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly PharmacieDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(PharmacieDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        protected PharmacieDbContext Context => _context; // Propriété protégée
        protected DbSet<T> DbSet => _dbSet; // Propriété protégée pour DbSet si nécessaire
        

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task DeleteAsync(object id)
        {
            T entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

}
