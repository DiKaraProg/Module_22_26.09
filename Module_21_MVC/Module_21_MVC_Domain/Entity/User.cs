using Module_21_MVC_Domain.Unum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_21_MVC_Domain.Entity
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }


        public Role Role { get; set; }
    }
}
