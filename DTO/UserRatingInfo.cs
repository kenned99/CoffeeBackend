using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserRatingInfo
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public int CoffeeRatings { get; set; }
        public int CoffeeTypes { get; set; }
        public virtual IEnumerable<CoffeeRatingInfo> CoffeeRating { get; set; }

    }
}
