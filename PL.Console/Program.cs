using System;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using Ninject;
using DependencyResolver;
using System.Linq;

namespace PL.Console
{
    class Program
    {
        private static readonly IAccountNumberCreateService AccountNumberCreateService;
        private static readonly IKernel NinjectKernel;

        static Program()
        {
            NinjectKernel = new StandardKernel();
            NInjectDependencyResolver.Configure(NinjectKernel);
            AccountNumberCreateService = NinjectKernel.Get<IAccountNumberCreateService>();
        }

        private static void Main()
        {
            try
            {
                var service = NinjectKernel.Get<IAccountService>();
                Test(service);
            }

            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

        private static void Test(IAccountService service)
        {
            service.OpenAccount("Ira Vinnichek", AccountType.Base, AccountNumberCreateService);
            service.OpenAccount("Kate Shenets", AccountType.Gold, AccountNumberCreateService);
            service.OpenAccount("Korzhova Lera", AccountType.Silver, AccountNumberCreateService);
            service.OpenAccount("Ivanov Kirill", AccountType.Base, AccountNumberCreateService);

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
        }
    }
}
