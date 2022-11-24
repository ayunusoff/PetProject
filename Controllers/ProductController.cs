using Microsoft.EntityFrameworkCore;
using PetProject.DBContext;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace PetProject.Controllers
{
    public class ProductController : Controller
    {
        private PetProjectContext _context;
        
        public ProductController(PetProjectContext dbContext) 
        {
            _context = dbContext;
        }
        public IActionResult Get() 
        {
            
            return Ok();
        } 
    }
}