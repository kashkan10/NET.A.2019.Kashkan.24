using System.Collections.Generic;
using AutoMapper;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class AccountMapper
    {
        public static IMapper Mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<AccountDTO, Account>();
            cfg.CreateMap<Account, AccountDTO>();
            cfg.CreateMap<IEnumerable<Account>, IEnumerable<AccountDTO>>();
        }).CreateMapper();
    }
}
