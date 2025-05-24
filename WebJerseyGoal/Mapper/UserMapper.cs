using AutoMapper;
using WebJerseyGoal.DataBase.Entitties;
using WebJerseyGoal.DataBase.Entitties.Identity;
using WebJerseyGoal.Models.Category;
using WebJerseyGoal.Models.Seeder;

namespace WebJerseyGoal.Mapper
{
    public class UserMapper:Profile
    {
        public UserMapper() {
            CreateMap<SeederUserModel, UserEntity>()
             .ForMember(opt => opt.UserName, opt => opt.MapFrom(x=>x.Email));
        }

    }
}
