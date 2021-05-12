using CoffeeInterfaces;
using System;
using System.Collections.Generic;
using Model;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Identity;

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
        public CoffeeCompany InsertCompany(CoffeeCompany coffeeCompany)
        {

            _context.Add<CoffeeCompany>(coffeeCompany);
            _context.SaveChanges();
            return coffeeCompany;
        }
        public List<CoffeeCompany> GetCompanys()
        {
            return _context.CoffeeCompanies.ToList<CoffeeCompany>();

        }

        public double GetRating(Guid Id)
        {
            return _context.CoffeeRating.Where(x => x.CoffeeId == Id && x.CoffeeId != null).Average(x => x.Rating);
        }

        public List<CoffeeRating> GetAllCoffee(Guid Id)
        {
            return _context.CoffeeRating.Where(x => x.CoffeeId == Id && x.CoffeeId != null).ToList<CoffeeRating>();
        }

        public CoffeeCompany GetCompany(string id)
        {
            Guid gid = Guid.Parse(id);
            return _context.CoffeeCompanies.FirstOrDefault(x => x.Id == gid);
        }

   

        public CoffeeRating InsertCoffeeRating(CoffeeRating coffeeRating)
        {
            _context.Add<CoffeeRating>(coffeeRating);
            _context.SaveChanges();
            return coffeeRating;

        }
        public User InsertUser(User user)
        {
            _context.Add<User>(user);
            _context.SaveChanges();
            return user;
        }
        public List<User> GetUsers()
        {
            return _context.Users.ToList<User>();
        }
        public User GetUser(string id)
        {
            Guid gid = Guid.Parse(id);
            return _context.Users.FirstOrDefault(x => x.Id == gid);
        }
        public User GetUser(Login login)
        {
            User user = FindUserEmail(login.Email);

            if (user == null)
            {
                return user;
            }
            var VerifikationRes = new PasswordHasher<User>().VerifyHashedPassword(user, user.Password, login.Password);

            if (VerifikationRes != PasswordVerificationResult.Success)
            {
                return null;
            }

            return user;
        }
        public User FindUserEmail(string Email)
        {
            return _context.Users.FirstOrDefault(x => x.Email == Email);
        }
        public List<Coffee> GetCoffies()
        { 
            return _context.Coffee.ToList<Coffee>();
        }

    }
}
