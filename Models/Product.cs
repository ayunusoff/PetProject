using System.ComponentModel.DataAnnotations;
using PetProject.Interfaces;
namespace PetProject.Models
{
    public class Product : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string? ImgSrc { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Cost { get; set; }
    }
}