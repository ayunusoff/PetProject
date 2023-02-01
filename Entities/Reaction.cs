using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PetProject.Interfaces;

namespace PetProject.Entities 
{
    public class Reaction : IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ReactionId")]
        public Guid Id { get; set; }
        public Article Article { get; set; } = new();
        public User User { get; set; } = new();
        public bool ReactionType { get; set; } 

    }
}