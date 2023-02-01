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
using Microsoft.AspNetCore.Authentication.OAuth;
using System;

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
                return Unauthorized();

            string salt = user.Password.Split('|')[1];
            string requestPass = PasswordHasher.HashPassword(loginRequest.Password, salt);
            var token = Token(user.Nickname);
            
            if (requestPass == user.Password)
            {
                HttpContext.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                HttpContext.Response.Headers.Add("X-Xss-Protection", "1");
                HttpContext.Response.Headers.Add("X-Frame-Options", "DENY");
                HttpContext.Response.Cookies.Append(".AspNetCore.Application.Id", token.Jwt, 
                new CookieOptions
                {
                        MaxAge = TimeSpan.FromMinutes(5)
                });
                return Ok(user.Nickname);
            }
            return Unauthorized();
        }
        [HttpPut]
        public IActionResult ChangePass([FromBody] LoginRequest loginRequest) 
        {

            return Ok();
        }
        private Token Token(string nickname) 
        {
            var jwt = new JwtSecurityToken(
                    issuer: AuthSettings.ISSUER,
                    audience: AuthSettings.AUDIENCE,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(60)),
                    signingCredentials: new SigningCredentials(AuthSettings.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new Token { Jwt = encodedJwt, RefreshToken = null};
        }
    }
}
