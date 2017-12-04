using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using DAL.Interface;
using DAL.Interface.DTO;
using DAL.EF.Models;

namespace DAL.EF
{
    public class DBRepository : IRepository
    {
        public void Create(DalAccount account)
        {
            if (ReferenceEquals(account, null))
            {
                throw new ArgumentNullException(nameof(account));
            }

            using (var db = new AccountContext())
            {
                if (db.Accounts.Any(dalAccount => dalAccount.AccountNumber == account.AccountNumber))
                {
                    throw new ArgumentException("Account already exists in db.");
                }

                var addingAccount = db.Accounts.FirstOrDefault(dalAccount => dalAccount.AccountNumber == account.AccountNumber);

                db.Accounts.Add(addingAccount);
                db.SaveChanges();
            }
        }

        public void Delete(DalAccount account)
        {
            using (var db = new AccountContext())
            {
                var removingAccount = db.Accounts.FirstOrDefault(dalAccount => dalAccount.AccountNumber == account.AccountNumber);

                db.Accounts.Remove(removingAccount);
                db.SaveChanges();
            }
        }

        public DalAccount GetByNumber(string accountNumber)
        {
            using (var db = new AccountContext())
            {
                var account = db.Accounts.FirstOrDefault(acc => acc.AccountNumber == accountNumber);
                return GetDalAccount(account);
            }
        }

        public void Update(DalAccount account)
        {
            using (var db = new AccountContext())
            {
                var updatingAccount = db.Accounts.FirstOrDefault(dalAccount => dalAccount.AccountNumber == account.AccountNumber);

                db.Accounts.Remove(updatingAccount);
                db.Accounts.Add(updatingAccount);
                db.SaveChanges();
            }
        }

        public IEnumerable<DalAccount> GetAllAccounts()
        {
            var accounts = new List<DalAccount>();
            using (var db = new AccountContext())
            {
                accounts.AddRange(db.Accounts.ToList().Select(GetDalAccount));
            }
            return accounts;
        }
        /*
        private static Account GetAccount(DalAccount account) => new Account
            {
                AccountType = account.AccountType,
                Balance = account.Balance,
                BenefitPoints = account.BenefitPoints,
                AccountNumber = account.AccountNumber,
                OwnerName = account.OwnerName
            };
            */

        private static DalAccount GetDalAccount(Models.Account account) => new DalAccount
           {
               AccountType = account.AccountType,
               Balance = account.Balance,
               BenefitPoints = account.BenefitPoints,
               AccountNumber = account.AccountNumber,
               OwnerName = account.OwnerName
           };

    }
}
