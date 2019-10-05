using System;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DependencyResolver;
using Ninject;

namespace ConsolePL
{
    internal class Program
    {
        private static readonly IKernel Resolver;

        static Program()
        {
            Resolver = new StandardKernel();
            Resolver.ConfigurateResolver();
        }

        private static void Main(string[] args)
        {
            IAccountService service = Resolver.Get<IAccountService>();
            IAccountNumberCreateService creator = Resolver.Get<IAccountNumberCreateService>();

            service.OpenAccount("Don Milon", CardType.Base, creator);
            service.OpenAccount("Ken Down", CardType.Base, creator);
            service.OpenAccount("Lick Shane", CardType.Gold, creator);
            service.OpenAccount("Rita McGrey", CardType.Base, creator);

            var creditNumbers = service.GetAllAccounts().Select(acc => acc.AccountId).ToArray();

            

            foreach (var item in service.GetAllAccounts())
            {
                Console.WriteLine(item);
            }

            foreach (var t in creditNumbers)
            {
                service.DepositAccount(t, 100);
            }

            foreach (var item in service.GetAllAccounts())
            {
                Console.WriteLine(item);
            }

            foreach (var t in creditNumbers)
            {
                service.WithdrawAccount(t, 10);
            }

            foreach (var item in service.GetAllAccounts())
            {
                Console.WriteLine(item);
            }

            Console.Read();
        }
    }
}