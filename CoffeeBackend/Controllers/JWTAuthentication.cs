using BusinessLogic;
using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private IConfiguration _config;

        private APIDbContext context;

        private readonly ILogger<LoginController> _logger;

        public LoginController(IConfiguration config, ILogger<LoginController> logger, APIDbContext context)
        {
            _config = config;
            _logger = logger;
            this.context = context;
        }


        [AllowAnonymous]
        [HttpPost]
        
        public IActionResult Login([FromBody] Login login)
        {

            IActionResult response = Unauthorized();

            User user = AuthenticateUser(login);


            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString, user = user});
                return response;
            }
            

            return Problem(detail: "error in username or password");
        }

        private string GenerateJSONWebToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User AuthenticateUser(Login login)
        {
            BLCoffee newCoffee = new BLCoffee(context);
            return newCoffee.GetUser(login);
        }
  
        [AllowAnonymous]
        [HttpPost("Signup")]
        public IActionResult SignUp([FromBody] User user)
        {         
            if(user.Password == null)
            {
                return Problem(detail: "missing password");
            }
            else if(user.FirstName == null)
            {
                return Problem(detail: "missing firstname");
            }
            else if (user.LastName == null)
            {
                return Problem(detail: "missing lastname");
            }
            else if (user.Email == null)
            {
                return Problem(detail: "missing email");
            }

            user.Password = HashPassword(user);

            BLCoffee newCoffee = new BLCoffee(context);
            
            User excists = newCoffee.FindUserEmail(user.Email);
            if(excists != null)
            {
                return Problem(
                    detail: "Email already in use");
            }

            newCoffee.InsertUser(user);
            return Ok(user);
        }
        private string HashPassword(User user)
        {
            string hashedpassword = new PasswordHasher<User>().HashPassword(user, user.Password);
            return hashedpassword;
        }

    }
}
