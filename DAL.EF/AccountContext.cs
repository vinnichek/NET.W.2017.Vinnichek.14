using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF.Models;

namespace DAL.EF
{
    public class AccountContext : DbContext
    {
        public AccountContext() : base("DefaultConnection") { }

        public DbSet<Account> Accounts { get; set; }
    }
}
