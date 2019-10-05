using System;
using System.Collections.Generic;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

namespace DAL.Repositories
{
    public class Repository : IRepository
    {
        private List<AccountDTO> list;
        private string filePath;

        /// <summary>
        /// Default constructor
        /// </summary>
        public Repository()
        {
            filePath = "accounts.dat";
            list = new List<AccountDTO>();
        }

        /// <summary>
        /// Custom constructor
        /// </summary>
        /// <param name="path"></param>
        public Repository(string path)
        {
            filePath = path;
            list = new List<AccountDTO>();
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

            if (list.Contains(account))
            {
                throw new Exception("Account is already exist");
            }

            list.Add(account);
        }

        /// <summary>
        /// Get account from list
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Account</returns>
        public AccountDTO GetByNumber(int id)
        {
            if (list.Contains(list.Find(acc => acc.AccountId == id)))
            {
                return list.Find(acc => acc.AccountId == id);
            }
            else
            {
                throw new Exception("Account not found");
            }
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

            if (!list.Contains(account))
            {
                throw new Exception("Account not found");
            }

            list.Remove(list.Find(acc => acc.AccountId == account.AccountId));
            list.Add(account);
        }

        /// <summary>
        /// Save list to storage
        /// </summary>
        /// <param name="storage"></param>
        public void SaveToStorage(IStorage<AccountDTO> storage)
        {
            storage.SaveToStorage(list, filePath);
        }

        /// <summary>
        /// Load list from storage
        /// </summary>
        /// <param name="storage"></param>
        public void LoadFromStorage(IStorage<AccountDTO> storage)
        {
            storage.LoadFromStorage(list, filePath);
        }

        /// <summary>
        /// Get list of all accounts
        /// </summary>
        /// <returns>List</returns>
        public IEnumerable<AccountDTO> GetAllAccounts()
        {
            return list;
        }
    }
}