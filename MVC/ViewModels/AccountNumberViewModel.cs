using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class AccountNumberViewModel
    {
        [Display(Name = "Account number")]
        [Required(ErrorMessage = "Account number is empty.", AllowEmptyStrings = false)]
        public string AccountNumber { get; set; }
    }
}