using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Login
    {
        [EmailAddress]
        [MaxLength(100)]
        [JsonProperty("Email")]
        public string Email { get; set; }

        //hash'er altid til 84 karraktere
        [MaxLength(84)]
        [JsonProperty("Password")]
        public string Password { get; set; }
        [JsonProperty("Token")]
        public string token { get; set; }
    }
}
