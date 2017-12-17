namespace ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Owner
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Owner()
        {
            Accounts = new HashSet<Account>();
        }

        public int Id { get; set; }

        
        public string Name { get; set; }

        
        public string Email { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
