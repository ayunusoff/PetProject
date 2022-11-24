using System.ComponentModel.DataAnnotations;

namespace PetProject.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Cost { get; set; }
    }
}