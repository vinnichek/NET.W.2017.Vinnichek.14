using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using DAL.EF;
using DAL.Interface;
using Ninject;
using Ninject.Web.Common;
using System.Data.Entity;
using ORM;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolverWeb(this IKernel kernel)
        {
            Configure(kernel, true);
        }

        public static void ConfigurateResolverConsole(this IKernel kernel)
        {
            Configure(kernel, false);
        }

        private static void Configure(IKernel kernel, bool isWeb)
        {
            if (isWeb)
            {
                kernel.Bind<IAccountNumberCreateService>().To<AccountNumberCreator>().InRequestScope();
                kernel.Bind<DbContext>().To<EntityModel>().InRequestScope();
            }
            else
            {
                kernel.Bind<IAccountNumberCreateService>().To<AccountNumberCreator>().InSingletonScope();
                kernel.Bind<DbContext>().To<EntityModel>().InSingletonScope();
            }

            kernel.Bind<IAccountService>().To<AccountService>();
            kernel.Bind<IRepository>().To<DBRepository>();
        }
    }
}
