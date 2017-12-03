using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class Account
    {
        public int AccountId { get; set; }
        public decimal Balance { get; set; }
        public int BonusPoints { get; set; }
        public int AccountOwnerId { get; set; }

        public virtual AccountOwner AccountOwner { get; set; }

        public int AccountTypeId { get; set; }

        public virtual AccountType AccountType { get; set; }
    }
}
