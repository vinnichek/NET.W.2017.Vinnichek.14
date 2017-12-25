﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class DalAccount
    {
        public string AccountType { get; set; }
        public string AccountNumber { get; set; }
        public string OwnerName { get; set; }
        public string OwnerEmail { get; set; }
        public decimal Balance { get; set; }
        public int BenefitPoints { get; set; }
    }
}
