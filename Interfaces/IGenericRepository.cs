namespace PetProject.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task Create(TEntity item);
        Task<TEntity> GetById(int id);
        IEnumerable<TEntity> Get();
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        Task Remove(TEntity item);
        Task Update(TEntity item);
    }
}