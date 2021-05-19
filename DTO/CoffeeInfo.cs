using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CoffeeInfo
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string GenreName { get; set; }
        public Guid CoffeeCompanyId { get; set; }
        public string CoffeeCompanyName { get; set; }
        public double AverageRating { get; set; }
        public string ImageLink { get; set; }


    }
}
