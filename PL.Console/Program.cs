using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using DAL.Interface;
using DAL;

namespace PL.Console
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            IRepository rep = new FakeRepository();
            IAccountService service = new AccountService(rep);

            IAccountNumberCreateService creator = new AccountNumberCreator();

            service.OpenAccount("Ira Vinnichek", AccountType.Base, creator);
            service.OpenAccount("Kate Shenets", AccountType.Gold, creator);
            service.OpenAccount("Korzhova Lera", AccountType.Silver, creator);
            service.OpenAccount("Ivanov Kirill", AccountType.Base, creator);

            foreach (var item in service.GetAllAccounts())
            {
                System.Console.WriteLine(item);
            }

            System.Console.WriteLine("------");

            var creditNumbers = service.GetAllAccounts().Select(acc => acc.AccountNumber).ToArray();

            foreach (var t in creditNumbers)
            {
                service.DepositAccount(t, 100);
            }

            foreach (var item in service.GetAllAccounts())
            {
                System.Console.WriteLine(item);
            }

            System.Console.WriteLine("------");

            foreach (var t in creditNumbers)
            {
                service.WithdrawAccount(t, 10);
            }

            foreach (var item in service.GetAllAccounts())
            {
                System.Console.WriteLine(item);
            }
        }
    }
}
