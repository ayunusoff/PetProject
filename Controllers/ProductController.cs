
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using PetProject.Entities;
using Microsoft.EntityFrameworkCore;
using PetProject.Data;

namespace PetProject.Controllers
{
    
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController : InitController<Product>
    {
        public ProductController(PetProjectContext context, GenericRepository<Product> rep) : base(context, rep) { }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromHeader] int id) 
        {
            var product = await _rep.GetById(id);
            if (product != null)
                return Json(product);
            return NotFound();
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Product product) 
        {
            if (product != null) 
            {
                await _rep.Update(product);
                return Ok();
            }
            return BadRequest();
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            if (product != null)
            {
                await _rep.Create(product);
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromHeader] int id) 
        {
            Product product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
            if (product != null) 
            {
                await _rep.Remove(product);
                return Ok();
            }
            return NotFound();
        }
    }
}