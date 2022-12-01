using Microsoft.EntityFrameworkCore;
using PetProject.Entities;

namespace PetProject.Data
{
    public class PetProjectContext : DbContext 
    {
        public PetProjectContext (DbContextOptions<PetProjectContext> options) : base (options) { }
        public DbSet<Product> Products => Set<Product>();
    }
}
