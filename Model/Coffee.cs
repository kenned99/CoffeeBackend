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
        
        [JsonProperty("Rating")]
        public double Rating { get; set; }
        [JsonProperty("Date")]
        public DateTime Date { get; set; }
        [JsonProperty("Genre")]
        public Genre Genre { get; set; }
        public CoffeeCompany Company { get; set; }
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
