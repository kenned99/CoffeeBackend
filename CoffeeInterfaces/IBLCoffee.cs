using Model;
using System;
using System.Collections.Generic;

namespace CoffeeInterfaces
{
    public interface IBLCoffee
    {
 
        public List<Coffee> getCoffee();
        public Coffee InsertCoffee(Coffee coffee);

    }
}
