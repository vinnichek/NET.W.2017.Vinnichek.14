using System;
using System.Collections.Generic;
using BLL.Interface.Entities;

namespace DAL.Interface
{
    public interface IRepository
    {
        IEnumerable<Account> GetAllAccounts();
        void Create(Account account);
        void Delete(Account account);
        Account GetByNumber(string accountNumber);
        void Update(Account account);
    }
}
