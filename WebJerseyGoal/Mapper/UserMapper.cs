using AutoMapper;
using WebJerseyGoal.DataBase.Entitties;
using WebJerseyGoal.DataBase.Entitties.Identity;
using WebJerseyGoal.Models.Account;
using WebJerseyGoal.Models.Category;
using WebJerseyGoal.Models.Seeder;

namespace WebJerseyGoal.Mapper
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
