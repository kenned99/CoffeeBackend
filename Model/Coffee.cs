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
        public string Name { get; set; }
        [MaxLength(5)]
        public double Rating { get; set; }
        public string Company { get; set; }
        public DateTime Date { get; set; }
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
