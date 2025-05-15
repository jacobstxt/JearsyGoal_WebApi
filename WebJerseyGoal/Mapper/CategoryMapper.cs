using AutoMapper;
using WebJerseyGoal.DataBase.Entitties;
using WebJerseyGoal.Models.Category;
using WebJerseyGoal.Models.Seeder;

namespace WebJerseyGoal.Mapper
{
    public class CategoryMapper:Profile
    {
        public CategoryMapper()
        {
            CreateMap<SeederCategoryModel, CategoryEntity>();
            CreateMap<CategoryEntity, CategoryItemViewModel>();
            CreateMap<CategoryCreateViewModel,CategoryEntity>()
                .ForMember(x=> x.Image,opt=> opt.Ignore());
        } 


    }
}
