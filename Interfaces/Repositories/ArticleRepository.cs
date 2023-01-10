using Microsoft.EntityFrameworkCore;
using PetProject.Entities;
using PetProject.Data;

namespace PetProject.Interfaces.Repositories
{
    public class ArticleRepository : GenericRepository<Article>, IArticleRepository
    {
        public ArticleRepository(DbContext context) : base(context)
        {
            
        }
    }
}