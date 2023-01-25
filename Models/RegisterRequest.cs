using System.ComponentModel.DataAnnotations;

namespace PetProject.Models
{
    public class RegisterRequest
    {
        [Required]
        public string Nickname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ImgSrc { get; set; }
    }
}
