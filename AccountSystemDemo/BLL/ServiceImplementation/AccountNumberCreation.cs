using BLL.Interface.Interfaces;
using System;

namespace BLL.ServiceImplementation
{
    public class AccountNumberCreator : IAccountNumberCreateService
    {
        public int GenerateId(int id)
        {
            return new Random().Next();
        }
    }
}