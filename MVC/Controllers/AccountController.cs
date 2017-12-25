using BLL.Interface.Interfaces;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using System.Web.UI.WebControls;

namespace MVC.Controllers
{
    public class AccountController : Controller
    {
        private const string HostEmail = "vinnichekira@gmail.com";
        private const string HostEmailPassword = "myPassword"; 

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
                await SendMailAsync("vinnichekira@gmail.com", "Open Account", $"Thank you for registration, {account.Owner}! Your Account Number is {accNumber}");
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
                await SendMailAsync("vinnichekira@gmail.com", "Depothit Money", $"Deposit {model.Amount} to your bank account.");
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
                await SendMailAsync("vinnichekira@gmail.com", "Withdraw Money", $"Withdraw {model.Amount} from your bank account.");
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

        private Task SendMailAsync(string to, string subject, string message)
        {
            var mailData = new MailData
            {
                To = to,
                From = HostEmail,
                FromPassword = HostEmailPassword,
                Subject = subject,
                Message = message
            };

            return mailService.SendMailAsync(mailData);
        }
    }
}
