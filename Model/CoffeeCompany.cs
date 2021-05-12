using Newtonsoft.Json;
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
        [JsonProperty("Name")]
        public string Name { get; set; }
        [MaxLength(200)]
        [JsonProperty("Address")]
        public string Address { get; set; }
        public virtual IList<Coffee> Coffee { get; set; }

    }
}
