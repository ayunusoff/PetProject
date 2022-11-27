using Microsoft.EntityFrameworkCore;
using PetProject.DBContext;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using PetProject.Models;
namespace PetProject.Controllers
{
    
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController : Controller
    {
        private PetProjectContext _context;
        
        public ProductController(PetProjectContext dbContext) 
        {
            _context = dbContext;
        }
        [HttpGet]
        public IActionResult Get() 
        {
            var product = _context.Products?.Select(p => new {p.Name, p.Description, p.Cost}).ToList();
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