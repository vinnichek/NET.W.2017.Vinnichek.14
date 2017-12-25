using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class AccountInfoViewModel
    {
        [Display(Name = "Account type")]
        [Required(ErrorMessage = "Type is not selected.", AllowEmptyStrings = false)]
        public string Type { get; set; }

        [Display(Name = "Account number")]
        [Required(ErrorMessage = "Account number is empty.", AllowEmptyStrings = false)]
        public string AccountNumber { get; set; }

        [Display(Name = "Owner name")]
        [Required(ErrorMessage = "Name is empty.", AllowEmptyStrings = false)]
        public string Owner { get; set; }

        [Display(Name = "Account balance")]
        [Required(ErrorMessage = "Account balance is empty.", AllowEmptyStrings = false)]
        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }

        [Display(Name = "Benefit points")]
        [Required(ErrorMessage = "Benefit points are empty.", AllowEmptyStrings = false)]
        public int BenefitPoints { get; set; }
    }
}
