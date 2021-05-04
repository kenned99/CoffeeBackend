﻿using BusinessLogic;
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
         

    }
}
