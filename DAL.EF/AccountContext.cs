using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class AccountContext : DbContext
    {
        public AccountContext() : base("DefaultConnection") { }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<AccountOwner> Owners { get; set; }

        public DbSet<AccountType> AccountTypes { get; set; }
    }
}
