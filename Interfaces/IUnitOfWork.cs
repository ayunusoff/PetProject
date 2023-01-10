using PetProject.Interfaces.Repositories;

namespace PetProject.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IArticleRepository ArticleRepository { get; }
        Task<bool> Complete();
    }
}