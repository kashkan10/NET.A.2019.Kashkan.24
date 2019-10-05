using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interface.Interfaces;
using DAL.Interface.DTO;

namespace DAL.Repositories
{
    public class AccountRepository : IRepository
    {
        private AccountContext db;
        private readonly string filePath;

        /// <summary>
        /// Constructor
        /// </summary>
        public AccountRepository(AccountContext db)
        {
            filePath = "accounts.dat";
            this.db = new AccountContext();
        }

        /// <summary>
        /// Add account to list
        /// </summary>
        /// <param name="account"></param>
        public void Create(AccountDTO account)
        {
            if (account == null)
            {
                throw new ArgumentNullException();
            }

            db.Accounts.Add(account);
            db.SaveChanges();
        }

        /// <summary>
        /// Get account from list
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Account</returns>
        public AccountDTO GetByNumber(int id)
        {
            return db.Accounts.Find(id);
        }

        /// <summary>
        /// Update account
        /// </summary>
        /// <param name="account"></param>
        public void Update(AccountDTO account)
        {
            if (account == null)
            {
                throw new ArgumentNullException();
            }

            AccountDTO accToUpdate = db.Accounts.Find(account.AccountId);
            accToUpdate.Balance = account.Balance;
            accToUpdate.Bonus = account.Bonus;
            accToUpdate.Owner = account.Owner;
            accToUpdate.Status = account.Status;
            accToUpdate.Type = account.Type;
            db.SaveChanges();
        }

        /// <summary>
        /// Save list to storage
        /// </summary>
        /// <param name="storage"></param>
        public void SaveToStorage(IStorage<AccountDTO> storage)
        {
            storage.SaveToStorage(db.Accounts.ToList(), filePath);
        }

        /// <summary>
        /// Load list from storage
        /// </summary>
        /// <param name="storage"></param>
        public void LoadFromStorage(IStorage<AccountDTO> storage)
        {
            storage.LoadFromStorage(db.Accounts.ToList(), filePath);
        }

        /// <summary>
        /// Get list of all accounts
        /// </summary>
        /// <returns>List</returns>
        public IEnumerable<AccountDTO> GetAllAccounts()
        {
            return db.Accounts;
        }
    }
}
