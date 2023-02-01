using Microsoft.EntityFrameworkCore;
using PetProject.Entities;
using System.Globalization;

namespace PetProject.Data
{
    public class PetProjectContext : DbContext 
    {
        public PetProjectContext (DbContextOptions<PetProjectContext> options) : base (options) 
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            
        }
        public DbSet<Article> Articles { get; set; } = null!;
        public DbSet<ArticleTag> ArticleTags { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
        public DbSet<Reaction> Reactions { get; set; } = null!;
        public DbSet<Subscriber> Subscribers { get; set; } = null!;
        public DbSet<Tag> Tags { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
    }
}
