using CoffeeInterfaces;
using System;
using System.Collections.Generic;
using Model;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic
{
    public class BLCoffee : IBLCoffee
    {

        private readonly APIDbContext _context;
        public BLCoffee(APIDbContext context) 
        {
            _context = context;
        } 
        public List<Coffee> getCoffee()
        {
            throw new NotImplementedException();
        }
        public Coffee InsertCoffee(Coffee coffee)
        {
            _context.Add<Coffee>(coffee);
            _context.SaveChanges();

            return coffee;
        }
    }
}
