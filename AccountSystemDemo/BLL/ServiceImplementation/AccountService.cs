using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.Mappers;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

namespace BLL.ServiceImplementation
{
    public class AccountService : IAccountService
    {
        private readonly IBonus bonus;
        private IRepository repo;

        /// <summary>
        /// Custom constructor
        /// </summary>
        /// <param name="bonus"></param>
        /// <param name="repo"></param>
        public AccountService(IRepository repo, IBonus bonus)
        {
            this.bonus = bonus;
            this.repo = repo;
        }

        /// <summary>
        /// Create new account 
        /// </summary>
        /// <param name="account"></param>
        public void OpenAccount(string owner, CardType type, IAccountNumberCreateService id)
        {
            Account acc = new Account(id.GenerateId(GetNumberOfAccounts() + 1), owner, type);
            repo.Create(AccountMapper.Mapper.Map<AccountDTO>(acc));
        }

        /// <summary>
        /// Deposit sum to account
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sum"></param>
        public void DepositAccount(int id, decimal sum)
        {
            Account acc = AccountMapper.Mapper.Map<Account>(repo.GetByNumber(id));
            acc.Deposit(sum, bonus);
            repo.Update(AccountMapper.Mapper.Map<AccountDTO>(acc));
        }

        /// <summary>
        /// Withdraw sum from account
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sum"></param>
        public void WithdrawAccount(int id, decimal sum)
        {
            Account acc = AccountMapper.Mapper.Map<Account>(repo.GetByNumber(id));
            acc.Withdraw(sum, bonus);
            repo.Update(AccountMapper.Mapper.Map<AccountDTO>(acc));
        }

        /// <summary>
        /// Get list of accounts
        /// </summary>
        /// <returns>list</returns>
        public IEnumerable<Account> GetAllAccounts()
        {
            return AccountMapper.Mapper.Map<IEnumerable<Account>>(repo.GetAllAccounts());
        }

        /// <summary>
        /// Get number of accounts
        /// </summary>
        /// <returns>result</returns>
        private int GetNumberOfAccounts()
        {
            return repo.GetAllAccounts().Count();
        }
    }
}