using DAL.Interface.DTO;
using ORM;

namespace DAL.EF.Mappers
{
    public static class EntitiesMappers
    {
        public static Account ToOrmAccount(this DalAccount account) => 
            new Account
            { 
                AccountType = new AccountType
                {
                    Name = account.AccountType
                },
                Balance = account.Balance,
                BenefitPoints = account.BenefitPoints,
                Number = account.AccountNumber,
                Owner = new Owner
                {
                    Name = account.OwnerName
                }
            };

        public static DalAccount ToDalAccount(this Account account) =>
            new DalAccount
            {
                AccountType = account.AccountType.Name,
                Balance = account.Balance,
                BenefitPoints = account.BenefitPoints,
                AccountNumber = account.Number,
                OwnerName = account.Owner.Name
            };
    }
}
