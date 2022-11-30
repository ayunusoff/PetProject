using Microsoft.AspNetCore.Mvc;
using PetProject.Data;
using PetProject.Interfaces;
using PetProject.Models;

namespace PetProject.Data
{
    [ApiController]
    public class InitController : Controller
    {
        protected GenericRepository<IEntity> _service;
        protected PetProjectContext _context;
        private PetProjectContext context;
        private GenericRepository<Product> rep;

        public InitController(PetProjectContext context, GenericRepository<IEntity> service) 
        {
            _service = service;
            _context = context;
        }
    }
}