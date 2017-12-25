namespace MVC.ViewModels
{
    using BLL.Interface.Entities;
    using System.ComponentModel.DataAnnotations;

    public partial class AccountViewModel
    {
        [Display(Name = "Account type")]
        [Required(ErrorMessage = "Type is not selected.", AllowEmptyStrings = false)]
        public AccountType Type { get; set; }

        [Display(Name = "Owner name")]
        [Required(ErrorMessage = "Field is empty.", AllowEmptyStrings = false)]
        public string Owner { get; set; }

        [Display(Name = "Owner email")]
        [Required(ErrorMessage = "Field is empty.", AllowEmptyStrings = false)]
        public string Email { get; set; }

        [Display(Name = "Account balance")]
        [Required(ErrorMessage = "Field is empty.", AllowEmptyStrings = false)]
        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }
    }
}
