using BusinessLogic;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoffeeBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeContoller : ControllerBase
    {
        private readonly APIDbContext context;


        private readonly ILogger<CoffeeContoller> _logger;

        public CoffeeContoller(ILogger<CoffeeContoller> logger, APIDbContext context)
        {
            _logger = logger;
            this.context = context;
        }


        // GET: api/<Coffee>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<Coffee>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Coffee>
        [HttpPost]
        public Coffee Post([FromBody] Coffee Coffee)
        {
            Coffee coffee = new Coffee();

            BLCoffee newcoffee = new BLCoffee(context);
            newcoffee.InsertCoffee(coffee);
            return coffee;

        }


    }
}
