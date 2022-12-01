using System.ComponentModel.DataAnnotations;
using PetProject.Interfaces;

namespace PetProject.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? ImgSrc { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public decimal Cost { get; set; } = 0.0m;
    }
}