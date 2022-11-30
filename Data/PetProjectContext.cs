using Microsoft.EntityFrameworkCore;
using PetProject.Models;

namespace PetProject.Data
{
    public class PetProjectContext : DbContext 
    {
        public PetProjectContext (DbContextOptions<PetProjectContext> options) : base (options) { }
        public DbSet<Product> Products => Set<Product>();
    }
}
