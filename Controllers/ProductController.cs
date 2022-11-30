using Microsoft.EntityFrameworkCore;
using PetProject.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using PetProject.Models;

namespace PetProject.Controllers
{
    
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController : InitController
    {
        private GenericRepository<Product> _rep;
        private PetProjectContext _context;
        
        public ProductController(PetProjectContext context, GenericRepository<Product> _rep) : base(context, _rep)
        {
        }
        [HttpGet]
        public IActionResult GetById([FromHeader] int Id) 
        {
            var product = getById(Id);
            return 0;
        }
        [HttpGet]
        public IActionResult Get() 
        {
            var product = _context.Products?.ToList();
            return Json(product);
        } 
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}