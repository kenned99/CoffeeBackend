using BusinessLogic;
using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoffeeBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateCoffee : ControllerBase
    {
        private readonly APIDbContext context;


        private readonly ILogger<RateCoffee> _logger;

        public RateCoffee(ILogger<RateCoffee> logger, APIDbContext context)
        {
            _logger = logger;
            this.context = context;
        }

        // GET: api/<RateCoffee>
        [Authorize]
        [HttpGet("rating")]
        public IActionResult Rating(Guid coffeeId)
        {
            BLCoffee newCoffee = new BLCoffee(context);
            return Ok(newCoffee.GetRating(coffeeId));
        }
        [Authorize]
        [HttpGet("AllRatings")]
        public IActionResult AllRatings(Guid coffeeId)
        {
            BLCoffee newCoffee = new BLCoffee(context);
            return Ok(newCoffee.GetAllCoffee(coffeeId));

        }


        // POST api/<RateCoffee>
        [HttpPost]
        public IActionResult Post([FromBody] CoffeeRating coffeeRating)
        {
            string jwt = Request.Headers["authorization"];
            jwt = jwt.Remove(0, 7);
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwt);

            string id = token.Claims.First(claim => claim.Type == "Id").Value;

            if (id == null)
            {
                return Problem("no userkey");
            }
            coffeeRating.UserId = Guid.Parse(id);

            BLCoffee newCoffee = new BLCoffee(context);

            return Ok(newCoffee.InsertCoffeeRating(coffeeRating));

        }
    }
}
