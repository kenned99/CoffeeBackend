using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Friend:IdRec
    {
        public virtual ICollection<User> Users { get; set; }
    }
}
