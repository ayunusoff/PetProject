using Microsoft.EntityFrameworkCore;
using PetProject.Entities;
using System.Globalization;

namespace PetProject.Data
{
    public class PetProjectContext : DbContext 
    {
        public PetProjectContext (DbContextOptions<PetProjectContext> options) : base (options) 
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Article>().HasData( new Article[] 
            { 
                new Article() 
                { 
                    Id = Guid.NewGuid(), 
                    Title = "Test1", 
                    Text = "Test1 Test1Test1 Test1 Test1Test1Test1 Test1", 
                    PreviewImgSrc = "https://www.cctraining.uk.com/wp-content/uploads/2017/09/test.png", 
                    DateAdd = DateTime.UtcNow 
                }, 
                new Article() 
                { 
                    Id = Guid.NewGuid(), 
                    Title = "Test2", 
                    Text = "Test2 Test2Test2 Test2 Test21Tes2t21T2e22st1 Test1", 
                    PreviewImgSrc = "https://play-lh.googleusercontent.com/V_P-I-UENK93ahkQgOWel8X8yFxjhOOfMAZjxXrqp311Gm_RBtlDXHLQhwFZN8n4aIQ",
                    DateAdd = DateTime.UtcNow 
                },
                new Article()
                {
                    Id = Guid.NewGuid(),
                    Title = "Test3",
                    Text = "Test3 Test3Test3 Test3 Test321Tes32t213T2e223st1 Te3st1",
                    PreviewImgSrc = "https://play-lh.googleusercontent.com/V_P-I-UENK93ahkQgOWel8X8yFxjhOOfMAZjxXrqp311Gm_RBtlDXHLQhwFZN8n4aIQ",
                    DateAdd = DateTime.UtcNow
                },
            });
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
