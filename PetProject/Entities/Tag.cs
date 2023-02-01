using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PetProject.Interfaces;

namespace PetProject.Entities
{
    public class Tag
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("TagId")]
        public Guid Id { get; set; }
        
        public string Text { get; set; } = "";
    }
}