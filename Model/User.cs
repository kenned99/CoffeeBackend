using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User:IdRec
    {

        [MaxLength(50)]
        [JsonProperty("FirstName")]
        public string FirstName { get; set; }
        [MaxLength(50)]
        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [EmailAddress]
        [MaxLength(100)]
        [JsonProperty("Email")]
        public string Email { get; set; }

        //hash'er altid til 84 karraktere
        [MaxLength(84)]
        [JsonProperty("Password")]
        public string Password { get; set; }

        public virtual ICollection<Friend> Friends { get; set; }

        public virtual ICollection<Coffee> Coffee { get; set; }
    }

    public class ProductImage
    {
        public int ProductId { get; set; }
        public byte[] Image { get; set; }
    }
}
