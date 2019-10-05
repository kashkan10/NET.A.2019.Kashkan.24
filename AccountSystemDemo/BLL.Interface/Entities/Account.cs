using System;
using BLL.Interface.Interfaces;

namespace BLL.Interface.Entities
{
    public class Account
    {
        private decimal balance;

        /// <summary>
        /// Default constructor
        /// </summary>
        public Account()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="owner"></param>
        /// <param name="balance"></param>
        /// <param name="type"></param>
        /// <param name="bonus"></param>
        public Account(int id, string owner, decimal balance, CardType type, int bonus)
        {
            AccountId = id;
            Owner = owner;
            Balance = balance;
            Bonus = bonus;
            Type = type;
            Status = Status.Active;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="owner"></param>
        /// <param name="balance"></param>
        /// <param name="type"></param>
        public Account(int id, string owner, decimal balance, CardType type)
        {
            AccountId = id;
            Owner = owner;
            Status = Status.Active;
            Type = type;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="owner"></param>
        /// <param name="type"></param>
        public Account(int id, string owner, CardType type)
        {
            AccountId = id;
            Owner = owner;
            Status = Status.Active;
            Type = type;
        }

        /// <summary>
        /// Id property
        /// </summary>
        public int AccountId { get; private set; }

        /// <summary>
        /// Owner property
        /// </summary>
        public string Owner { get; private set; }

        public decimal Balance
        {
            get
            {
                return balance;
            }

            private set
            {
                if (value < 0)
                {
                    throw new Exception("Balance cannot be negative");
                }

                balance = value;
            }
        }

        /// <summary>
        /// Bonus property
        /// </summary>
        public int Bonus { get; private set; }

        /// <summary>
        /// Status property
        /// </summary>
        public Status Status { get; private set; }

        /// <summary>
        /// Type property
        /// </summary>
        public CardType Type { get; private set; }

        /// <summary>
        /// IsActive property
        /// </summary>
        private bool IsActive
        {
            get
            {
                if (Status == Status.Active)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Add sum to account
        /// </summary>
        /// <param name="sum"></param>
        public void Deposit(decimal sum, IBonus bonusLogic)
        {
            if (sum < 0)
            {
                throw new ArgumentException("Sum cannot be negative");
            }

            if (IsActive)
            {
                Balance += sum;
                Bonus += bonusLogic.Deposit(sum, Type);
            }
            else
            {
                throw new Exception("Account closed");
            }
        }

        /// <summary>
        /// Withdraw sum from account
        /// </summary>
        /// <param name="sum"></param>
        public void Withdraw(decimal sum, IBonus bonusLogic)
        {
            if (sum < 0)
            {
                throw new ArgumentException("Sum cannot be negative");
            }

            if (IsActive)
            {
                if (Balance >= sum)
                {
                    Balance -= sum;
                    Bonus = bonusLogic.Withdraw(sum, Type) < Bonus ? Bonus - bonusLogic.Withdraw(sum, Type) : 0;
                }
                else
                {
                    throw new Exception("Not enough money");
                }
            }
        }

        /// <summary>
        /// Close account
        /// </summary>
        public void Close()
        {
            Status = Status.Closed;
        }

        /// <summary>
        /// Override of ToString() method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>String representation</returns>
        public override string ToString()
        {
            return string.Format($"{AccountId}.{Owner}, {Balance}, {Type}");
        }
    }
}