using Model;
using System;
using System.Collections.Generic;

namespace CoffeeInterfaces
{
    public interface IBLCoffee
    {
 
        public List<Coffee> getCoffee();
        public Coffee InsertCoffee(Coffee coffee);
        public CoffeeCompany InsertCompany(CoffeeCompany coffeeCompany);
        public CheckIn InsertCheckin(CheckIn checkIn);
        public User InsertUser(User user);

        public List<User> GetUsers();
        public User GetUser(string username);
        public User FindUserEmail(string Email);
        public List<Coffee> GetCoffies();
    }
}
