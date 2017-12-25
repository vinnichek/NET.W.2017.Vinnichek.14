﻿using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DAL.Interface;
using DAL.Interface.DTO;
using BLL.Mappers;

namespace BLL.ServiceImplementation
{
    public class AccountService : IAccountService
    {
        private readonly IRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public AccountService(IRepository repository, IUnitOfWork unitOfWork) 
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public string OpenAccount(AccountType accountType, IAccountNumberCreateService creator, string ownerName, string ownerEmail, decimal balance = 0m, int benefitPoints = 0)
        {
            string accountNumber = creator.Create(GetNumberOfAccounts());
            var account = CreateAccountType(accountNumber, accountType, ownerName, ownerEmail, balance, benefitPoints);

            repository.Create(account.ToDalAccount());
            unitOfWork.Commit();

            return accountNumber;
        }

        public void CloseAccount(string accountNumber)
        {
            var account = repository.GetByNumber(accountNumber);
            repository.Delete(account);
            unitOfWork.Commit();
        }

        public string GetAccoutInformation(string accountNumber)
        {
            return repository.GetByNumber(accountNumber).ToBllAccount().ToString();
        }

        public void DepositAccount(string accountNumber, decimal amount)
        {
            var account = repository.GetByNumber(accountNumber).ToBllAccount();
            account.Deposit(amount);
            repository.Update(account.ToDalAccount());
            unitOfWork.Commit();
        }

        public void WithdrawAccount(string accountNumber, decimal amount)
        {
            Account account = repository.GetByNumber(accountNumber).ToBllAccount();
            account.Whithdraw(amount);
            repository.Update(account.ToDalAccount());
            unitOfWork.Commit();
        }

        public IEnumerable<Account> GetAllAccounts() => repository.GetAllAccounts().ToBllAccounts();

        private int GetNumberOfAccounts() => GetAllAccounts().ToList().Count;

        private static Account CreateAccountType(string accountNumber, AccountType type, string ownerName, string ownerEmail, decimal balance, int benefitPoints)
        {
            switch (type)
            {
                case AccountType.Base:
                    return new BaseAccount(accountNumber, ownerName, ownerEmail, balance, benefitPoints);
                case AccountType.Gold:
                    return new GoldAccount(accountNumber, ownerName, ownerEmail, balance, benefitPoints);
                case AccountType.Silver:
                    return new SilverAccount(accountNumber, ownerName, ownerEmail, balance, benefitPoints);
                default:
                    return null;
            }
        }
    }
}
