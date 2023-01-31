using System.ComponentModel.DataAnnotations;

namespace PetProject.Models
{
    public class LoginRequest
    {
        public string Nickname { get; set; } = null!;

        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
