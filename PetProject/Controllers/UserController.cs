using Microsoft.AspNetCore.Mvc;
using PetProject.Interfaces;
using PetProject.Entities;
using PetProject.Data;

namespace PetProject.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : InitController<User>
    {
        public UserController(PetProjectContext context, IUnitOfWork uof) : base(context, uof) 
        {
            
        }
        
        [HttpGet("{id}")]
        public IActionResult Get([FromHeader] string id) 
        {
            var user = _uof.UserRepository.GetById(id);
            if (user != null) 
            {
                return Json(user);
            }
            return NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] User user) 
        {
            if (user != null) 
            {
                _uof.UserRepository.Update(user);
                await _uof.Complete();
                return Ok();
            }
            return BadRequest();
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user) 
        {
            if (user != null)
            {
                await _uof.UserRepository.Add(user);
                await _uof.Complete();
                return Ok();
            }
            return BadRequest();
        }

    }
} 