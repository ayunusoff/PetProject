using Microsoft.AspNetCore.Mvc;
using PetProject.Data;
using PetProject.Interfaces;
using PetProject.Entities;

namespace PetProject.Data
{
    [ApiController]
    public class InitController<TEntity> : Controller where TEntity : class
    {
        protected GenericRepository<TEntity> _rep;
        protected PetProjectContext _context;
        public InitController(PetProjectContext context, GenericRepository<TEntity> rep) 
        {
            _rep = rep;
            _context = context;
        }
    }
}