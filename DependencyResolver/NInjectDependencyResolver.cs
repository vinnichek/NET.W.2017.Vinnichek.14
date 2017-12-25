using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using DAL.EF;
using DAL.Interface;
using Ninject;
using System.Data.Entity;
using ORM;
using DAL.Fake;

namespace DependencyResolver
{
    public class NInjectDependencyResolver
    {
        public static void Configure(IKernel kernel)
        {
            //kernel.Bind<IRepository>().To<FakeRepository>().InSingletonScope();
            kernel.Bind<IRepository>().To<DBRepository>().InSingletonScope();
            kernel.Bind<IMailService>().To<GmailService>().InSingletonScope();
            kernel.Bind<IAccountNumberCreateService>().To<AccountNumberCreator>().InSingletonScope();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
            kernel.Bind<DbContext>().To<EntityModel>().InSingletonScope();

            var accountRepository = kernel.Get<IRepository>();
            var unitOfWork = kernel.Get<IUnitOfWork>();

            kernel
                .Bind<IAccountService>()
                .To<AccountService>()
                .WithConstructorArgument("repository", accountRepository)
                .WithConstructorArgument("unitOfWork", unitOfWork);
        }
    }
}
