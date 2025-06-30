using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Models.Account;
using Core.Models.Category;
using Domain.Entitties;
using Domain.Entitties.Identity;

namespace Core.Mapper
{
    public class AccountMapper: Profile
    {
        public AccountMapper()
        {
            CreateMap<UserEntity, UserItemModel>();
        }
    }
}
