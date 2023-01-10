using Microsoft.EntityFrameworkCore;
using PetProject.Entities;

namespace PetProject.Data
{
    public class PetProjectContext : DbContext 
    {
        public PetProjectContext (DbContextOptions<PetProjectContext> options) : base (options) 
        {
            Database.EnsureDeleted();
            Database.EnsureCreated(); 
        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleTag> ArticleTags { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
