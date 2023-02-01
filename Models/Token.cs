namespace PetProject.Models
{
    public class Token
    {
        public string Jwt { get; set; } = null!;
        public string? RefreshToken { get; set; }
    }
}
