using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public partial class TransactionsViewModel
    {
        [Display(Name = "Account number")]
        [Required(ErrorMessage = "Field can't be empty.", AllowEmptyStrings = false)]
        public string AccountNumber { get; set; }

        [Display(Name = "Amount of money")]
        [Required(ErrorMessage = "Field can't be empty.", AllowEmptyStrings = false)] 
        public decimal Amount { get; set; }
    }
}