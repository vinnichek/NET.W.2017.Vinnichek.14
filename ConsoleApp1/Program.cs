using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DependencyResolver;
using Ninject;
using System;

namespace ConsoleApp1
{
    class Program
    {
        private static readonly IAccountNumberCreateService AccountNumberCreateService;
        private static readonly IKernel Kernel;

        static Program()
        {
            Kernel = new StandardKernel();
            NInjectDependencyResolver.Configure(Kernel);
            AccountNumberCreateService = Kernel.Get<IAccountNumberCreateService>();
        }

        private static void Main()
        {

            try
            {
                var service = Kernel.Get<IAccountService>();
                Test(service);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                if (e.InnerException != null)
                    Console.WriteLine("Inner exception: {0}", e.InnerException);
            }
            Console.ReadKey();
        }

        private static void Test(IAccountService service)
        {
            string accountInfo = service.GetAccoutInformation("1");
            var data = accountInfo.Split(' ');
            Console.WriteLine(data[data.Length - 6]);
            service.OpenAccount(AccountType.Silver, AccountNumberCreateService, "Korzhova Lera", "vinnichekira@gmail.com");            
            service.OpenAccount(AccountType.Gold, AccountNumberCreateService, "f", "i@gmail.com", 0, 0);
            var list1 = service.GetAllAccounts();
            service.SendMail("vinnichekira@gmail.com", "hello", "hi");
            /* foreach (var user in list1)
             {
                 Console.WriteLine(user);
             }
            
            service.OpenAccount(AccountType.Silver, AccountNumberCreateService, "Korzhova Lera", "vinnichekira@gmail.com");            
            service.OpenAccount(AccountType.Gold, AccountNumberCreateService, "f", "i@gmail.com", 0, 0);
            
            var list1 = service.GetAllAccounts();

            foreach (var user in list1)
            {
                Console.WriteLine(user);
            }
            /*
            service.DepositAccount("1", 100000);
           
            service.DepositAccount("4", 2000);
            service.DepositAccount("2", 700);


            Console.WriteLine("------");

            var list = service.GetAllAccounts();
            foreach (var user in list)
            {
                Console.WriteLine(user);
            }
            /*
            foreach (var item in service.GetAllAccounts())
            {
                System.Console.WriteLine(item);
            }

            System.Console.WriteLine("------");

            service.CloseAccount("1");

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
