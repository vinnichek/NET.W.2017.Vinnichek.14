using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DAL.EF.Models
{
    public class Account
    {
        [Key]
        public string AccountNumber { get; set; }

        public string AccountType { get; set; }
        public string OwnerName { get; set; }
        public decimal Balance { get; set; }
        public int BenefitPoints { get; set; }
    }
}
