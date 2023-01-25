using System.Linq.Expressions;

namespace PetProject.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class, IEntity, new()
    {
       TEntity? Get(string id);
       Task<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
       Task<IEnumerable<TEntity>> GetAll();
       Task<IEnumerable<TEntity>> GetWhere(Expression<Func<TEntity, bool>> predicate);
       Task Add(TEntity entity);
       Task AddRange(IEnumerable<TEntity> entities);
       void Update(TEntity entity);
       void UpdateRange(IEnumerable<TEntity> entities);
       void Delete(TEntity entity);
       void DeleteRange(IEnumerable<TEntity> entities);
    }
}