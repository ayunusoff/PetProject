using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PetProject.Interfaces;

namespace PetProject.Entities
{
    public class Subscriber : IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("SubscriberId")]
        public Guid Id { get; set; }
        public User Subscribe { get; set; }
        public User Author { get; set; }
    }
}