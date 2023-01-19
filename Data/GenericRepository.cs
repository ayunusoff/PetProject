using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PetProject.Interfaces;

namespace PetProject.Data
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity, new()
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _dbSet;
 
        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        
        public async Task<TEntity?> Get(string id)
            => await _dbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id.ToString() == id);
        public async Task<TEntity?> Find(Expression<Func<TEntity, bool>> predicate) 
            => await _dbSet.AsNoTracking().FirstOrDefaultAsync(predicate);
        public async Task<IEnumerable<TEntity>> GetAll()
            => await _dbSet.AsNoTracking().ToListAsync();
        public async Task<IEnumerable<TEntity>> GetWhere(Expression<Func<TEntity, bool>> predicate)
            => await _dbSet.AsNoTracking().Where(predicate).ToListAsync();

        public async Task Add(TEntity entity)
            => await _dbSet.AddAsync(entity);
        public async Task AddRange(IEnumerable<TEntity> entities)
            => await _dbSet.AddRangeAsync(entities);
        
        public void Update(TEntity entity) 
            => _context.Entry(entity).State = EntityState.Modified;
        public void UpdateRange(IEnumerable<TEntity> entities) 
            => _dbSet.UpdateRange(entities);
        
        public void Delete(TEntity entity) 
            => _dbSet.Remove(entity);
        public void DeleteRange(IEnumerable<TEntity> entities)
            => _dbSet.RemoveRange(entities);
        
    }
}