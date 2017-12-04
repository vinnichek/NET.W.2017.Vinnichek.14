using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using BLL.Interface.Entities;

namespace BLL.Mappers
{
    public static class AccountMapper
    {
        public static DalAccount ToDalAccount(this Account account) => new DalAccount
            {
                AccountType = account.GetType().AssemblyQualifiedName,
                AccountNumber = account.AccountNumber,
                OwnerName = account.OwnerName,
                Balance = account.Balance,
                BenefitPoints = account.BenefitPoints
            };

        public static Account ToBllAccount(this DalAccount dalAccount) => (Account)Activator.CreateInstance(
                GetBllAccountType(dalAccount.AccountType),
                dalAccount.AccountNumber,
                dalAccount.OwnerName,
                dalAccount.Balance,
                dalAccount.BenefitPoints);


        public static IEnumerable<DalAccount> ToDalAccounts(this IEnumerable<Account> accounts)
            => new List<DalAccount>(accounts.Select(account => new DalAccount
            {
                AccountType = account.GetType().AssemblyQualifiedName,
                AccountNumber = account.AccountNumber,
                OwnerName = account.OwnerName,
                Balance = account.Balance,
                BenefitPoints = account.BenefitPoints
            }));

        public static IEnumerable<Account> ToBllAccounts(this IEnumerable<DalAccount> accounts)
            => new List<Account>(accounts.Select(account => (Account)Activator.CreateInstance(
                GetBllAccountType(account.AccountType),
                account.AccountNumber,
                account.OwnerName,
                account.Balance,
                account.BenefitPoints)));

        private static Type GetBllAccountType(string type)
        {
            if (type.Contains("Gold"))
            {
                return typeof(GoldAccount);
            }

            if (type.Contains("Silver"))
            {
                return typeof(SilverAccount);
            }

            return typeof(BaseAccount);
        }
    }
}
