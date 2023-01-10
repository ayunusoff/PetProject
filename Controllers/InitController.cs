using Microsoft.AspNetCore.Mvc;
using PetProject.Interfaces;
using PetProject.Data;

namespace PetProject.Controllers
{
    [ApiController]
    public class InitController<TEntity> : Controller where TEntity : class
    {
        protected readonly IUnitOfWork _uof;
        protected readonly PetProjectContext _context;
        public InitController(PetProjectContext context, IUnitOfWork uof) 
        {
            _uof = uof;
            _context = context;
        }
    }
}