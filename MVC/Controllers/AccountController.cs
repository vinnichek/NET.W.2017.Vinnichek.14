using BLL.Interface.Interfaces;
using MVC.ViewModels;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class AccountController : Controller
    {
        private const string HostEmail = "vinnichekira@gmail.com";
        private const string HostEmailPassword = "dbyybxtrbhbyf"; 

        private readonly IAccountService accountService;
        private readonly IAccountNumberCreateService accountNumberCreator;
        private readonly IMailService mailService;

        public AccountController()
        {
            accountService = Utils.DependencyResolver.AccountService;
            accountNumberCreator = Utils.DependencyResolver.AccountNumberCreator;
            mailService = Utils.DependencyResolver.GmailService;
        }

        [HttpGet]
        public ActionResult Index() => View();

        [HttpGet]
        public ActionResult OpenAccount() => View();
        
        [HttpPost]
        public async Task<ActionResult> OpenAccount(AccountViewModel account)
        {
            if (ModelState.IsValid)
            {
                var accNumber = accountService.OpenAccount(account.Type, accountNumberCreator, account.Owner, account.Email, account.Balance);
                await accountService.SendMail(account.Email, $"Thank you for using our bank, {account.Owner}. Your account number is {accNumber}.", "Account is opened.");
                return RedirectToAction("AccountIsOpened");
            }
            return View();
        }
        
        [HttpGet]
        public ActionResult AccountIsOpened()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult AccountOperations()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult DepositMoney()
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView();
            }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> DepositMoneyOperation(TransactionsViewModel model)
        {
            if (ModelState.IsValid)
            {
                accountService.DepositAccount(model.AccountNumber, model.Amount);
                var accEmail = GetAccountEmail(model.AccountNumber);
                await accountService.SendMail(accEmail, $"Deposit {model.Amount} to your account.", "Deposit money.");
                TempData["OperationSuccess"] = true;
                return RedirectToAction("AccountOperations");
            }
            return View();
        }
        
        [HttpPost]
        public ActionResult WithdrawMoney()
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView();
            }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> WithdrawMoneyOperation(TransactionsViewModel model)
        {
            if (ModelState.IsValid)
            {
                accountService.WithdrawAccount(model.AccountNumber, model.Amount);
                var accEmail = GetAccountEmail(model.AccountNumber);
                await accountService.SendMail(accEmail, $"Withdraw {model.Amount} from your account.", "Withdraw money.");
                TempData["OperationSuccess"] = true;
                return RedirectToAction("AccountOperations");
            }
            return View();
        }
        
        [HttpPost]
        public ActionResult AccountInfo()
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView();
            }
            return View();
        }

        [HttpPost]
        public ActionResult AccountInfoOperation(AccountNumberViewModel model)
        {
            if (ModelState.IsValid)
            {
                ViewData["Message"] = accountService.GetAccoutInformation(model.AccountNumber);
                //TempData["AccountInfoSuccess"] = true;
                TempData["OperationSuccess"] = true;

                return RedirectToAction("AccountOperations");
            }
            return View();
        }

        [HttpPost]
        public ActionResult CloseAccount()
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView();
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CloseAccountOperation(AccountNumberViewModel model)
        {
            if (ModelState.IsValid)
            {
                accountService.CloseAccount(model.AccountNumber);
                return RedirectToAction("AccountOperations");
            }
            return View();
        }
        
        private string GetAccountEmail(string accountNumber)
        {
            string accountInfo = accountService.GetAccoutInformation(accountNumber);
            var data = accountInfo.Split(' ');
            return data[data.Length - 6];
        }
    }
}