using BusinessLogic;
using DataAccess;
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
        public CoffeeCompany Post(String CompName, String Address)
        {
            CoffeeCompany Company = new CoffeeCompany();
            Company.Name = CompName;
            Company.Address = Address;
            BLCoffee newCoffee = new BLCoffee(context);
            newCoffee.InsertCompany(Company);
            return Company;
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
