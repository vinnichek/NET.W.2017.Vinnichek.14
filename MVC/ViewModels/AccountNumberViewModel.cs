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
        [Range(1, int.MaxValue, ErrorMessage = "Account number is not valid.")]
        public string AccountNumber { get; set; }
    }
}