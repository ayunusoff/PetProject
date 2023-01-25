using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetProject.Data;
using PetProject.Entities;
using PetProject.Interfaces;
using PetProject.Models;
using PetProject.Helpers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PetProject.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AccountController : InitController<User>
    {
        public AccountController(PetProjectContext context, IUnitOfWork uof) : base(context, uof)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Registration([FromBody] RegisterRequest registerRequest) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string salt = PasswordHasher.GenerateSalt(32);
            string hashPass = PasswordHasher.HashPassword(registerRequest.Password, salt);
            
            await _uof.UserRepository.Add(new User
            {
                Id = Guid.NewGuid(),
                Nickname = registerRequest.Nickname,
                Password = hashPass,
                ImgSrc = registerRequest.ImgSrc,
                EMail = registerRequest.Email,
                UserRole = Entities.User.Role.authorized,
                RegisterDate = DateTime.UtcNow,
            });

            await _uof.Complete();
            return Ok();
        }
        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest loginRequest) 
        {
            var user = _uof.UserRepository.GetUserByNickname(loginRequest.Nickname);
            
            if (user == null)            
                return NotFound();

            string salt = user.Password.Split('|')[1];
            string requstPass = PasswordHasher.HashPassword(loginRequest.Password, salt);
            var token = Token(user.Nickname);

            if (requstPass == user.Password)
                return Ok(token);
            return Unauthorized();

            
        }
        [HttpPut]
        public IActionResult ChangePass([FromBody] LoginRequest loginRequest) 
        {

            return Ok();
        }
        private Token Token(string nickname) 
        {
            var signKey = AuthSettings.GetSymmetricSecurityKey();
            var signCredentials = new SigningCredentials(signKey, SecurityAlgorithms.HmacSha256);
            
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, nickname),
            };

            var jwt = new JwtSecurityToken(claims: claims, signingCredentials: signCredentials);
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new Token { Jwt = encodedJwt, RefreshToken = null};
        }
    }
}
