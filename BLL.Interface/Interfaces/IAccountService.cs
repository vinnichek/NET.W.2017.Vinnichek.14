using System.Collections.Generic;
using BLL.Interface.Entities;
using DAL.Interface.DTO;
using System.Threading.Tasks;

namespace BLL.Interface.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAllAccounts();
        string OpenAccount(AccountType accountType, IAccountNumberCreateService creator, string ownerName, string ownerEmail, decimal balance = 0m, int benefitPoints = 0);
        void CloseAccount(string accountNumber);
        void DepositAccount(string accountNumber, decimal amount);
        void WithdrawAccount(string accountNumber, decimal amount);
        string GetAccoutInformation(string accountNumber);
        Task SendMail(string to, string message, string subject);
    }
}