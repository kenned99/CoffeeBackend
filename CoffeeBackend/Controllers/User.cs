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


        [Authorize]
        [HttpGet]
        public List<User> Users()
        {
            BLCoffee newCoffee = new BLCoffee(context);

            return newCoffee.GetUsers();
        }
        [Authorize]
        [HttpGet("{id}")]
        public User User(string id)
        {
            BLCoffee newCoffee = new BLCoffee(context);
            return newCoffee.GetUser(id);
        }


    }
}
