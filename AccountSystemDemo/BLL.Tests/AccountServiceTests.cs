using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using Moq;
using NUnit.Framework;

namespace BLL.Tests
{
    internal class AccountServiceTests
    {
        [Test]
        public void CreateAccTest()
        {
            var repository = new Mock<IRepository>();
            var idGen = Mock.Of<IAccountNumberCreateService>();
            var bonus = Mock.Of<IBonus>();

            AccountService service = new AccountService(repository.Object, bonus);

            service.OpenAccount("Don MOn", CardType.Base, idGen);
            repository.Verify(repo => repo.Create(It.IsAny<AccountDTO>()));
        }

        [Test]
        public void GetAllAccsTest()
        {
            var repository = new Mock<IRepository>();
            var idGen = Mock.Of<IAccountNumberCreateService>();
            var bonus = Mock.Of<IBonus>();

            AccountService service = new AccountService(repository.Object, bonus);
            service.GetAllAccounts();
            repository.Verify(repo => repo.GetAllAccounts());
        }

        [Test]
        public void DepositAccTest()
        {
            var repository = new Mock<IRepository>();
            var idGen = Mock.Of<IAccountNumberCreateService>();
            var bonus = Mock.Of<IBonus>();

            AccountService service = new AccountService(repository.Object, bonus);
            service.OpenAccount("Don MOn", CardType.Base, idGen);
            service.DepositAccount(idGen.GenerateId(1), 100);
            repository.Verify(repo => repo.Update(It.IsAny<AccountDTO>()));
        }

        [Test]
        public void WithdrawAccTest()
        {
            var repository = new Mock<IRepository>();
            var idGen = Mock.Of<IAccountNumberCreateService>();
            var bonus = Mock.Of<IBonus>();

            AccountService service = new AccountService(repository.Object, bonus);
            service.OpenAccount("Don MOn", CardType.Base, idGen);
            service.WithdrawAccount(idGen.GenerateId(1), 100);
            repository.Verify(repo => repo.Update(It.IsAny<AccountDTO>()));
        }
    }
}