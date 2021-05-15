using DTO;
using Model;
using System;
using System.Collections.Generic;

namespace CoffeeInterfaces
{
    public interface IBLCoffee
    {
 

        public CoffeeInfo InsertCoffee(Coffee coffee);
        public CoffeeCompanyInfo InsertCompany(CoffeeCompany coffeeCompany);
        public User InsertUser(User user);

        public List<User> GetUsers();
        public User GetUser(string username);
        public User FindUserEmail(string Email);
        public IEnumerable<CoffeeInfo> GetCoffeeInfo();
        public IEnumerable<CoffeeCompanyInfo> GetCompanysInfo();
    }
}
