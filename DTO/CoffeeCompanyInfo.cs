using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CoffeeCompanyInfo
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual IEnumerable<CoffeeInfo> Coffees { get; set; }
    }
}
