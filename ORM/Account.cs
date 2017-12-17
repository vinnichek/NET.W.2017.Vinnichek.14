namespace ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Account
    {
        public int Id { get; set; }

        
        public string Number { get; set; }

        public decimal Balance { get; set; }

        public int BenefitPoints { get; set; }

        public int TypeId { get; set; }

        public int OwnerId { get; set; }

        public virtual AccountType AccountType { get; set; }

        public virtual Owner Owner { get; set; }
    }
}
