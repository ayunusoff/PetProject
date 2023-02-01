using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PetProject.Interfaces;

namespace PetProject.Entities 
{
    public class Comment : IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("CommentId")]
        public Guid Id { get; set; }
        public User User { get; set; } = new();
        public Article Article { get; set; } = new();
        public string Text { get; set; } = "";
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CommentDate { get; set; } = DateTime.Now;
    }
}