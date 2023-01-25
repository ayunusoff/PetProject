namespace PetProject.Models
{
    public class Token
    {
        public string Jwt { get; set; }
        public string? RefreshToken { get; set; }
    }
}
