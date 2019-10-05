using BLL.Interface.Entities;
using BLL.Interface.Interfaces;

namespace BLL.ServiceImplementation
{
    public class BonusLogic : IBonus
    {
        /// <summary>
        /// Add bonus
        /// </summary>
        /// <param name="sum"></param>
        /// <param name="type"></param>
        /// <returns>Sum to add</returns>
        public int Deposit(decimal sum, CardType type)
        {
            return (int)sum * (int)type / 100;
        }

        /// <summary>
        /// Withdraw bonus
        /// </summary>
        /// <param name="sum"></param>
        /// <param name="type"></param>
        /// <returns>Sum to withdraw</returns>
        public int Withdraw(decimal sum, CardType type)
        {
            return (int)sum * (int)type / 200;
        }
    }
}