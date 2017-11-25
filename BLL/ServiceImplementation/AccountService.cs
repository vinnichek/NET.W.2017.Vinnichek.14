using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DAL.Interface;

namespace BLL.ServiceImplementation
{
    public class AccountService : IAccountService
    {
        private IRepository repository;

        public AccountService(IRepository repository) 
        {
            this.repository = repository;
        }

        public void OpenAccount(string name, AccountType accountType, IAccountNumberCreateService creator)
        {
            string accountNumber = creator.Create(GetNumberOfAccounts());

            Type typeOfAccount = GetTypeOfAccount(accountType);

            Account account = (Account)Activator.CreateInstance(typeOfAccount, new object[] { accountNumber, name });

            repository.Create(account);
        }

        public void CloseAccount(string accountNumber)
        {
            Account account = repository.GetByNumber(accountNumber);
            repository.Delete(account);
        }

        public void DepositAccount(string accountNumber, decimal amount)
        {
            Account account = repository.GetByNumber(accountNumber);

            account.Deposit(amount);

            repository.Update(account);
        }

        public void WithdrawAccount(string accountNumber, decimal amount)
        {
            Account account = repository.GetByNumber(accountNumber);

            account.Whithdraw(amount);

            repository.Update(account);
        }

        public IEnumerable<Account> GetAllAccounts() => repository.GetAllAccounts();

        private static Type GetTypeOfAccount(AccountType accountType)
        {
            switch (accountType)
            {
                case AccountType.Base:
                    return typeof(BaseAccount);
                case AccountType.Silver:
                    return typeof(SilverAccount);
                case AccountType.Gold:
                    return typeof(GoldAccount);
                default:
                    return typeof(BaseAccount);
            }
        }

        private int GetNumberOfAccounts() => GetAllAccounts().ToList().Count;
    }
}
