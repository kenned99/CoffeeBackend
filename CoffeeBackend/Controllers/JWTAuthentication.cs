using BusinessLogic;
using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Model;
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
        public IActionResult Login(string Email, string Password)
        {
            IActionResult response = Unauthorized();
            User login = new Model.User();
            login.Email = Email;
            login.Password = Password;
            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
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

        private User AuthenticateUser(User login)
        {
            BLCoffee newCoffee = new BLCoffee(context);
            return newCoffee.GetUser(login.Email , login.Password);
        }

    }
}
