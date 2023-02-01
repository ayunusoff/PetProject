using PetProject.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using PetProject.Interfaces;

namespace PetProject.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        #region Inject Repositories

        private IUserRepository? userRepository;
        public IUserRepository UserRepository => userRepository ?? new UserRepository(_context);
        private IArticleRepository? articleRepository;
        public IArticleRepository ArticleRepository => articleRepository ?? new ArticleRepository(_context);

        #endregion
        
        public async Task<bool> Complete()
            => await _context.SaveChangesAsync() > 0;

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}