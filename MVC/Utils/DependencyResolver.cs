using Ninject;
using BLL.Interface.Interfaces;
using DependencyResolver;

namespace MVC.Utils
{
    public class DependencyResolver
    {
        static DependencyResolver()
        {
            var ninjectKernel = new StandardKernel();
            NInjectDependencyResolver.Configure(ninjectKernel);

            AccountService = ninjectKernel.Get<IAccountService>();
            AccountNumberCreator = ninjectKernel.Get<IAccountNumberCreateService>();
            GmailService = ninjectKernel.Get<IMailService>();
        }

        public static IAccountService AccountService { get; }

        public static IAccountNumberCreateService AccountNumberCreator { get; }

        public static IMailService GmailService { get; }
    }
}