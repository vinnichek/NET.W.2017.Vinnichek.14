using System;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using DAL.Interface;
using DAL.Interface.DTO;
using Moq;
using NUnit.Framework;


namespace BLL.Tests
{/*
    [TestFixture]
    public class AccountTests
    {    
        [TestCase("Ira Vinnichek", "1")]
        public void AccountServiceTests_Create_Account_Number(string name, string accountNumber)
        {
            var repositoryMock = new Mock<IRepository>();

            var accountNumberCreateServiceMock = new Mock<IAccountNumberCreateService>(MockBehavior.Strict);
            accountNumberCreateServiceMock.Setup(service => service.Create(0))
                .Returns(accountNumber);

            var accountService = new AccountService(repositoryMock.Object);

            accountService.OpenAccount(AccountType.Base, accountNumberCreateServiceMock.Object, name);

            accountNumberCreateServiceMock.Verify(
                service => service.Create(0), Times.AtLeastOnce);
        }

        [TestCase("Ira Vinnichek", "2")]
        public void AccountServiceTests_Create_Account(string name, string accountNumber)
        {
            var repositoryMock = new Mock<IRepository>();

            var accountNumberCreateServiceMock = new Mock<IAccountNumberCreateService>(MockBehavior.Strict);
            accountNumberCreateServiceMock.Setup(service => service.Create(0)).Returns(accountNumber);

            var accountService = new AccountService(repositoryMock.Object);

            accountService.OpenAccount(AccountType.Base, accountNumberCreateServiceMock.Object, name);

            repositoryMock.Verify(
                repository => repository.Create(It.Is<DalAccount>(account => string.Equals(account.AccountNumber, accountNumber, StringComparison.Ordinal))), Times.Once);

        }

        [TestCase("Ira Vinnichek", "3")]
        public void AccountServiceTests_Update_Account(string name, string accountNumber)
        {

            var repositoryMock = new Mock<IRepository>();

            var accountNumberCreateServiceMock = new Mock<IAccountNumberCreateService>(MockBehavior.Strict);
            accountNumberCreateServiceMock.Setup(service => service.Create(0)).Returns(accountNumber);

            var accountService = new AccountService(repositoryMock.Object);

            accountService.OpenAccount(AccountType.Base, accountNumberCreateServiceMock.Object, name);

            var accNumbers = accountService.GetAllAccounts().Select(acc => acc.AccountNumber).ToArray();

            foreach(var a in accNumbers)
            {
                accountService.DepositAccount(a, 100);
            }

            repositoryMock.Verify(
                repository => repository.Update(It.Is<DalAccount>(account => string.Equals(account.AccountNumber, accountNumber, StringComparison.Ordinal))), Times.AtMostOnce());

        }

        [TestCase("Ira Vinnichek", "4")]
        public void AccountServiceTests_Close_Account(string name, string accountNumber)
        {
            var repositoryMock = new Mock<IRepository>();

            var accountNumberCreateServiceMock = new Mock<IAccountNumberCreateService>(MockBehavior.Strict);
            accountNumberCreateServiceMock.Setup(service => service.Create(0)).Returns(accountNumber);

            var accountService = new AccountService(repositoryMock.Object);

            accountService.OpenAccount(AccountType.Base, accountNumberCreateServiceMock.Object, name);

            var accNumbers = accountService.GetAllAccounts().Select(acc => acc.AccountNumber).ToArray();

            foreach (var a in accNumbers)
            {
                accountService.CloseAccount(a);
            }

            repositoryMock.Verify(
                repository => repository.Delete(It.Is<DalAccount>(account => string.Equals(account.AccountNumber, accountNumber, StringComparison.Ordinal))), Times.AtMostOnce());
        }
    }
}*/
}