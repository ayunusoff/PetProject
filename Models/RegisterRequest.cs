using System.ComponentModel.DataAnnotations;

namespace PetProject.Models
{
    public class RegisterRequest
    {
        [Required]
        public string Nickname { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        public string ImgSrc { get; set; } = null!;
    }
}
