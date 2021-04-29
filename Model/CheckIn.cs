using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CheckIn
    {
        public int CoffeeId { get; set; }
        [MaxLength(200)]
        public string Comment { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(5)]
        public string Rating { get; set; }
        [MaxLength(200)]
        public string Location { get; set; }
        [MaxLength(100)]
        public string Company { get; set; }
        public DateTime Date { get; set; }

    }
    public enum ServingStyle
    {
        Arabica,
        Americano,
    }
}
