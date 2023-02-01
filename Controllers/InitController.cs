using Microsoft.AspNetCore.Mvc;
using PetProject.Interfaces;
using PetProject.Data;

namespace PetProject.Controllers
{
    [ApiController]
    public class InitController<TEntity> : ControllerBase where TEntity : class
    {
        protected readonly IUnitOfWork _uof;
        protected readonly PetProjectContext _context;
        public InitController(PetProjectContext context, IUnitOfWork uof) 
        {
            _uof = uof;
            _context = context;
        }
        virtual protected JsonResult Json(object o)
        {
            return new JsonResult(o);
        }
    }
}