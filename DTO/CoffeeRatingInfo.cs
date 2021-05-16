using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CoffeeRatingInfo
    {
        public double Rating { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public string Location { get; set; }
        public Guid CoffeeId { get; set; }
        public string CoffeeName { get; set; }
        public ServingStyle ServeringStyle { get; set; }
    }
}
