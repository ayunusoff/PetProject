using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using PetProject.Interfaces;

namespace PetProject.Entities
{
    public class User : IEntity
    {
        public enum Role 
        {
            authorized,
            unauthorized,
            admin
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("UserId")]
        public Guid Id { get; set; }
        
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string Nickname { get; set; } = "";

        public string EMail { get; set; } = "";
        
        public string? ImgSrc { get; set; }

        public Role UserRole { get; set; } = Role.unauthorized;

        [JsonIgnore]
        public string Password { get; set; } = "";

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime RegisterDate { get; set; }
        
    }
}