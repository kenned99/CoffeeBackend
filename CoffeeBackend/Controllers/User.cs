using BusinessLogic;
using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeBackend.Controllers
{
    [Route("User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly APIDbContext context;


        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, APIDbContext context)
        {
            _logger = logger;
            this.context = context;
        }
        [HttpPost]
        public User Post(String FirstName, String LastName, string Email, string Password)
        {


            User user = new Model.User();
            
            user.FirstName = FirstName;
            user.LastName= LastName;
            user.Email = Email;
            user.Password = Password;

            BLCoffee newCoffee = new BLCoffee(context);
            newCoffee.InsertUser(user);
            return user;
        }
        [Authorize]
        [HttpGet]
        public List<User> Get()
        {
            BLCoffee newCoffee = new BLCoffee(context);

            return newCoffee.GetUsers();
        }
        [HttpGet("{id}")]
        public User Get(string id)
        {
            BLCoffee newCoffee = new BLCoffee(context);
            return newCoffee.GetUser(id);
        }
        [HttpGet("{email}, {password}")]
        public User Get(string email, string password)
        {
            BLCoffee newCoffee = new BLCoffee(context);
            return newCoffee.GetUser(email, password);
        }
     
  
    }
}
