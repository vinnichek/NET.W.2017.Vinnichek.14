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

        public DBRepository(DbContext context)
        {
            this.context = context;
        }

        public void Create(DalAccount dalAccount)
        {
            if(ReferenceEquals(dalAccount,null))
            {
                throw new ArgumentException(nameof(dalAccount));
            }

            var account = dalAccount.ToOrmAccount();
            SetTypeAndOwner(account);
            context.Set<Account>().Add(account);
            context.SaveChanges();
        }

        public DalAccount GetByNumber(string accountNumber) => 
            context.Set<Account>()
               .Include(account => account.Owner)
               .Include(account => account.AccountType)
               .FirstOrDefault(account => account.Number == accountNumber)
               ?.ToDalAccount();

        public void Update(DalAccount dalAccount)
        {
            var account = GetAccountByNumber(dalAccount.AccountNumber);
            UpdateAccount(account, dalAccount);
        }

        private static void UpdateAccount(Account updatingAccount, DalAccount account)
        {
            updatingAccount.Balance = account.Balance;
            updatingAccount.BenefitPoints = account.BenefitPoints;
        }

        public void Delete(DalAccount dalAccount)
        {
            var account = GetAccountByNumber(dalAccount.AccountNumber);
            UpdateAccount(account, dalAccount);
            context.Set<Account>().Remove(account);
            context.SaveChanges();
        }

        public IEnumerable<DalAccount> GetAllAccounts() => 
            context.Set<Account>()
                .Include(account => account.Owner)
                .Include(account => account.AccountType)
                .ToList()
                .Select(account => account.ToDalAccount());

        private Owner GetAccountOwnerByName(string name)
            => context.Set<Owner>().FirstOrDefault(owner => owner.Name == name);

        private AccountType GetAccountTypeByName(string accountTypeName)
            => context.Set<AccountType>().FirstOrDefault(accountType => accountType.Name == accountTypeName);

        private Account GetAccountByNumber(string accountNumber)
            => context.Set<Account>().FirstOrDefault(account => account.Number == accountNumber);

        private void SetTypeAndOwner(Account account)
        {
            var accountOwner = GetAccountOwnerByName(account.Owner.Name);

            if (accountOwner != null)
            {
                account.Owner = null;
                account.OwnerId = accountOwner.Id;
            }

            var accountType = GetAccountTypeByName(account.AccountType.Name);

            if (accountType != null)
            {
                account.AccountType = null;
                account.TypeId = accountType.Id;
            }
        }

       
    }
}
