using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CoffeeRating : IdRec
    {

        [JsonProperty("Rating")]
        public double Rating { get; set; }
        [JsonProperty("Date")]
        public DateTime Date { get; set; }

        [MaxLength(200)]
        public string Comment { get; set; }

        [MaxLength(200)]
        public string Location { get; set; }


        [JsonProperty("CoffeeRatingId")]
        [Required]
        public Guid CoffeeId { get; set; }

        public ServingStyle ServeringStyle { get; set; }

    }
    public enum ServingStyle
    {
        Arabica,
        Americano,
    }
}
