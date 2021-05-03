using BusinessLogic;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeBackend.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CoffeeController : ControllerBase
    {
        private readonly APIDbContext context;


        private readonly ILogger<CoffeeController> _logger;

        public CoffeeController(ILogger<CoffeeController> logger, APIDbContext context)
        {
            _logger = logger;
            this.context = context;
        }

        [HttpGet]
        public Coffee Get()
        {
            Coffee coffee = new Coffee();
            coffee.Name = "first";
            coffee.Rating = 5;
            coffee.Company = new CoffeeCompany();
            coffee.Date = new DateTime();
            BLCoffee newcoffee = new BLCoffee(context);
            newcoffee.InsertCoffee(coffee);
            return coffee;
        }
    }
}
