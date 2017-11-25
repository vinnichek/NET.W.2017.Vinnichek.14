using System;
using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using DAL;
using DAL.Interface;
using Ninject;

namespace DependencyResolver
{
    public static class NInjectDependencyResolver
    {
        public static void Configure(IKernel kernel)
        {
            kernel.Bind<IRepository>().To<FakeRepository>().InSingletonScope();

            kernel.Bind<IAccountNumberCreateService>().To<AccountNumberCreator>().InSingletonScope();

            var fakeRepository = kernel.Get<IRepository>();
            kernel.Bind<IAccountService>().To<AccountService>()
                  .WithConstructorArgument("accountRepository", fakeRepository);
        }
    }
}
