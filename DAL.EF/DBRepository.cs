using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interface;
using DAL.Interface.DTO;
using System.Data.Entity;
using static DAL.EF.Mappers.EntitiesMappers;
using ORM;


namespace DAL.EF
{
    public class DBRepository : IRepository
    {
        private readonly DbContext context;

        public DBRepository(DbContext uow)
        {
            this.context = uow;
        }

        public void Create(DalAccount dalAccount)
        {
            var account = dalAccount.ToOrmAccount();
            context.Set<Account>().Add(account);
        }

        public DalAccount GetByNumber(string accountNumber)
        {
            var account = context.Set<Account>().FirstOrDefault(acc => acc.Number == accountNumber);
            return account.ToDalAccount();
        }

        public void Update(DalAccount dalAccount)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalAccount dalAccount)
        {
            var account = dalAccount.ToOrmAccount();
            account = context.Set<Account>().Single(acc => acc.Number == dalAccount.AccountNumber);
            context.Set<Account>().Remove(account);
        }

        public IEnumerable<DalAccount> GetAllAccounts()
        {
            return context.Set<Account>().Include(account => account.Owner)
                    .Include(account => account.AccountType)
                    .ToList()
                    .Select(account => account.ToDalAccount());
        }
    }
}
