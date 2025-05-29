using AutoMapper;
using Domain.Entitties;
using Domain.Entitties.Identity;
using Core.Models.Account;
using Core.Models.Category;
using Core.Models.Seeder;

namespace Core.Mapper
{
    public class UserMapper:Profile
    {
        public UserMapper() {
            CreateMap<SeederUserModel, UserEntity>()
                 .ForMember(opt => opt.UserName, opt => opt.MapFrom(x=>x.Email));

            CreateMap<RegisterModel, UserEntity>()
                 .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Name))
                 .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Surname))
                 .ForMember(x => x.Image, opt =>opt.Ignore())
                 .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.Email));
        }

    }
}
