using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CoffeeCompany: IdRec
    {
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Address { get; set; }

        public Coffee Coffee { get; set; }


    }
}
