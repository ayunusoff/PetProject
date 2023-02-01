using PetProject.Entities;

namespace PetProject.Models
{
    public class UserInfoResponse
    {
        public User user { get; set; } = null!;
        public Token token { get; set; } = null!;
    }
}
