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
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {


        private readonly APIDbContext context;


        private readonly ILogger<CompanyController> _logger;

        public CompanyController(ILogger<CompanyController> logger, APIDbContext context)
        {
            _logger = logger;
            this.context = context;
        }

        [HttpPost]
        [Authorize]
        public CoffeeCompany Post([FromBody] CoffeeCompany company)
        {
          
            BLCoffee newCoffee = new BLCoffee(context);
            newCoffee.InsertCompany(company);
            return company;

        }
        [HttpGet]
        public List<CoffeeCompany> Get()
        {
            BLCoffee newCoffee = new BLCoffee(context);

            return newCoffee.GetCompanys();
        }

        [HttpGet("{id}")]
        public CoffeeCompany Get(string id)
        {
            BLCoffee newCoffee = new BLCoffee(context);
            return newCoffee.GetCompany(id);
        }
    }
}
