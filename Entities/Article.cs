using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PetProject.Interfaces;

namespace PetProject.Entities
{
    public class Article : IEntity
    {   
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ArticleId")]
        public Guid Id { get; set; }
        public string Title { get; set; }
        
        public string Text { get; set; }

        public string? PreviewImgSrc { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateAdd { get; set; } = DateTime.UtcNow;
    }
}