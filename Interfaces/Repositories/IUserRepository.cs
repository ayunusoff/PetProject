using PetProject.Entities;

namespace PetProject.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User? GetUserByNickname(string nickname);
    }
}