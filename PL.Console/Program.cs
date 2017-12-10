using System;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using Ninject;
using DependencyResolver;

namespace PL.Console
{
    class Program
    {
        private static readonly IAccountNumberCreateService AccountNumberCreateService;
        private static readonly IKernel resolver;

        static Program()
        {
            resolver = new StandardKernel();
            resolver.ConfigurateResolverConsole();
        }

        private static void Main()
        {
            try
            {
                var service = resolver.Get<IAccountService>();
                Test(service);
            }

            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
            System.Console.ReadKey();
        }

        private static void Test(IAccountService service)
        {
            /*
            service.OpenAccount(AccountType.Base, AccountNumberCreateService,"Ira Vinnichek");
            service.OpenAccount(AccountType.Gold, AccountNumberCreateService, "Kate Shenets");
            service.OpenAccount(AccountType.Silver, AccountNumberCreateService, "Korzhova Lera");
            service.OpenAccount(AccountType.Base, AccountNumberCreateService, "Ivanov Kirill");
            */
            var list = service.GetAllAccounts();
            foreach (var user in list)
            {
                System.Console.WriteLine(user.AccountNumber);
            }
            /*
            foreach (var item in service.GetAllAccounts())
            {
                System.Console.WriteLine(item);
            }
            /*
            System.Console.WriteLine("------");

            //service.CloseAccount("1");

            service.DepositAccount("1", 130);
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
            */
        }
    }
}
