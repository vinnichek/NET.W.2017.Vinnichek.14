using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class AccountOwner
    {
        public int AccountOwnerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
