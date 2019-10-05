using BLL.Interface.Entities;

namespace BLL.Interface.Interfaces
{
    public interface IBonus
    {
        int Deposit(decimal sum, CardType type);

        int Withdraw(decimal sum, CardType type);
    }
}