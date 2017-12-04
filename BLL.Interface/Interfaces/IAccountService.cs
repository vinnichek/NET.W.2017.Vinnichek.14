using System.Collections.Generic;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Interface.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAllAccounts();
        void OpenAccount(AccountType accountType, IAccountNumberCreateService creator, string ownerName,  decimal balance = 0m, int benefitPoints = 0);
        void CloseAccount(string accountNumber);
        void DepositAccount(string accountNumber, decimal amount);
        void WithdrawAccount(string accountNumber, decimal amount);
    }
}