using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetProject.Data;
using PetProject.Entities;
using PetProject.Interfaces;

namespace PetProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : InitController<User>
    {
        public AccountController(PetProjectContext context, IUnitOfWork uof) : base(context, uof)
        {
        }

    }
}
