using System;
using System.Collections.Generic;
using DAL.Interface.DTO;

namespace DAL.Interface
{
    public interface IRepository
    {
        IEnumerable<DalAccount> GetAllAccounts();
        void Create(DalAccount account);
        void Delete(DalAccount account);
        DalAccount GetByNumber(string accountNumber);
        void Update(DalAccount account);
    }
}
