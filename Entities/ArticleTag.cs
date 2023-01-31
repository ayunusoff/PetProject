using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PetProject.Interfaces;

namespace PetProject.Entities
{
    public class ArticleTag : IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ArticleTagId")]
        public Guid Id { get; set; }
        public Article Article { get; set; } = new();
        public Tag Tag { get; set; } = new();
    }
}