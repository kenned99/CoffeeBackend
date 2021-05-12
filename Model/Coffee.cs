using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Coffee:IdRec 
    {
        [MaxLength(50)]
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Date")]
        public DateTime Date { get; set; }
        [JsonProperty("Genre")]
        public virtual Genre Genre { get; set; }
        //public virtual CoffeeCompany Company { get; set; }

        [JsonProperty("CoffeeCompanyId")]
        public Guid CoffeeCompanyId { get; set; }
        public virtual IList<CoffeeRating> CoffeeRating { get; set; }
    }
   public enum Genre
    {
        Arabica,
        Americano,
        Affogato,
        Black,
        Cappuccino,
        Cortado,
        Doppio,
        Espresso,
        Irish,
        Lungo,
        Latte,
        Macchiato,
        Mocha,
        Robusta,
        RedEye,
    }

}
