using Microsoft.EntityFrameworkCore;
using PetProject.Data;
using PetProject.Entities;

namespace PetProject.Interfaces.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {

        }
    }
}