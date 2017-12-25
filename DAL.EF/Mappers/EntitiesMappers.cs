using DAL.Interface.DTO;
using ORM;

namespace DAL.EF.Mappers
{
    public static class EntitiesMappers
    {
        public static Account ToOrmAccount(this DalAccount account) =>
            new Account
            {
                Number = account.AccountNumber,
                Balance = account.Balance,
                BenefitPoints = account.BenefitPoints,
                AccountType = new AccountType
                {
                    Name = account.AccountType
                },
                Owner = new Owner
                {
                    Name = account.OwnerName,
                    Email = account.OwnerEmail
                },
            };

        public static DalAccount ToDalAccount(this Account account) =>
            new DalAccount
            {
                AccountType = account.AccountType.Name,
                AccountNumber = account.Number,
                OwnerName = account.Owner.Name,
                OwnerEmail = account.Owner.Email,
                Balance = account.Balance,
                BenefitPoints = account.BenefitPoints
            };
    }
}