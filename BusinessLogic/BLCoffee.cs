using CoffeeInterfaces;
using System;
using System.Collections.Generic;
using Model;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using DTO;

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
        public CoffeeInfo InsertCoffee(Coffee coffee)
        {
            _context.Add<Coffee>(coffee);
            _context.SaveChanges();
            return CoffeeToCoffeeInfo(coffee);
        }
        public CoffeeCompanyInfo InsertCompany(CoffeeCompany coffeeCompany)
        {

            _context.Add<CoffeeCompany>(coffeeCompany);
            _context.SaveChanges();

            return CoffeeCompanyToCoffeeCompanyInfo(coffeeCompany);
        }

        internal List<CoffeeCompany> GetCompanys()
        {
            return _context.CoffeeCompanies.ToList<CoffeeCompany>();
        }

        public IEnumerable<CoffeeCompanyInfo> GetCompanysInfo()
        {
            return GetCompanys().Select(u => new DTO.CoffeeCompanyInfo
            {
                Id = u.Id,
                Address = u.Address,
                Coffees = u.Coffee.Select(CoffeeToCoffeeInfo),
                Name = u.Name
            });
        }

        public double GetRating(Guid Id)
        {
            return _context.CoffeeRating.Where(x => x.CoffeeId == Id && x.CoffeeId != null).Average(x => x.Rating);
        }

        public List<CoffeeRatingInfo> GetUserCoffeeRatings(string id)
        {
            User user = GetUser(id);

            List<CoffeeRatingInfo> list = new List<CoffeeRatingInfo>();
            foreach (CoffeeRating coffeeRating in user.CoffeeRating)
            {
                CoffeeRatingInfo coffeeRatingList = new CoffeeRatingInfo
                {
                    CoffeeId = coffeeRating.CoffeeId,
                    CoffeeName = _context.Coffee.Where(x => x.Id == coffeeRating.CoffeeId).SingleOrDefault()?.Name,
                    Comment = coffeeRating.Comment,
                    Date = coffeeRating.Date,
                    Location = coffeeRating.Location,
                    Rating = coffeeRating.Rating,
                    ServeringStyle = coffeeRating.ServeringStyle
                };

                list.Add(coffeeRatingList);
            }

            return list;
        }

        public List<CoffeeRating> GetAllCoffee(Guid Id)
        {
            return _context.CoffeeRating.Where(x => x.CoffeeId == Id && x.CoffeeId != null).ToList<CoffeeRating>();
        }

        public CoffeeCompanyInfo GetCompany(string id)
        {
            Guid gid = Guid.Parse(id);


            CoffeeCompany coffeeCompany = _context.CoffeeCompanies.FirstOrDefault(x => x.Id == gid);
            return new DTO.CoffeeCompanyInfo
            {
                Id = coffeeCompany.Id,
                Address = coffeeCompany.Address,
                Coffees = coffeeCompany.Coffee.Select(CoffeeToCoffeeInfo),
                Name = coffeeCompany.Name
            };
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
        public IEnumerable<CoffeeInfo> GetCoffeeInfo()
        {
            return GetCoffies().Select(CoffeeToCoffeeInfo);
        }

        internal static CoffeeInfo CoffeeToCoffeeInfo(Coffee coffee)
        {
            return new CoffeeInfo
            {
                Id = coffee.Id,
                Name = coffee.Name,
                AverageRating = coffee.AverageRating,
                CoffeeCompanyId = coffee.CoffeeCompanyId,
                CoffeeCompanyName = coffee.Company.Name
            };
            
        }
        internal static CoffeeCompanyInfo CoffeeCompanyToCoffeeCompanyInfo(CoffeeCompany coffeeCompany)
        {
            return new CoffeeCompanyInfo
            {
                Id = coffeeCompany.Id,
                Address = coffeeCompany.Address,
                Coffees = coffeeCompany.Coffee.Select(CoffeeToCoffeeInfo),
                Name = coffeeCompany.Name
            };

        }
    }
}
