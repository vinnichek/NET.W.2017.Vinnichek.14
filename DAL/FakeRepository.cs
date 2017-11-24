using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using DAL.Interface;

namespace DAL
{
    public class FakeRepository : IRepository
    {
        public List<Account> repository = new List<Account>();

        public void Create(Account account)
        {
            repository.Add(account);
        }

        public Account GetByNumber(string accountNumber)
        {
            var account = repository.Single(acc => acc.AccountNumber == accountNumber);
            return account;
        }

        public void Update(Account account)
        {
            repository.Remove(account);
            repository.Add(account);
        }

        public IEnumerable<Account> GetAllAccounts() => repository.ToArray();
    }
}

