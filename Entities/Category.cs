using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PetProject.Interfaces;

namespace PetProject.Entities
{
    public class Category : IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("CategoryId")]
        public Guid Id { get; set; }
        public Article Article { get; set; } = new();
        public string Text { get; set; } = "";
    }
}