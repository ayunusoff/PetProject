using System.ComponentModel.DataAnnotations;

namespace PetProject.Models
{
    public class LoginRequest
    {
        public string Nickname { get; set; }
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
