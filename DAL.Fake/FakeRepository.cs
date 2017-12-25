using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interface;
using DAL.Interface.DTO;

namespace DAL.Fake
{
    public class FakeRepository : IRepository
    {
        public List<DalAccount> repository = new List<DalAccount>();

        public void Create(DalAccount account)
        {
            repository.Add(account);
        }

        public void Delete(DalAccount account)
        {
            if (!repository.Contains(account))
                throw new ArgumentException($"{nameof(account)} doesn't exist.");
            repository.Remove(account);
        }

        public DalAccount GetByNumber(string accountNumber)
        {
            var account = repository.Single(acc => acc.AccountNumber == accountNumber);
            return account;
        }

        public void Update(DalAccount account)
        {
            repository.RemoveAll(dalAccount => dalAccount.AccountNumber == account.AccountNumber);
            repository.Add(account);
        }

        public IEnumerable<DalAccount> GetAllAccounts() => new List<DalAccount>(repository);
    }
}

