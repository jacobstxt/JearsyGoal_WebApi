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
                .ForMember(x=>x.Name,opt=> opt.MapFrom(x=> x.Name.Trim()))
                .ForMember(x => x.Slug, opt => opt.MapFrom(x => x.Slug.Trim()))
                .ForMember(x=> x.Image,opt=> opt.Ignore());

            CreateMap<CategoryEditViewModel, CategoryEntity>()
            .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name.Trim()))
            .ForMember(x => x.Slug, opt => opt.MapFrom(x => x.Slug.Trim()))
            .ForMember(x => x.Image, opt => opt.Ignore());
        } 


    }
}
