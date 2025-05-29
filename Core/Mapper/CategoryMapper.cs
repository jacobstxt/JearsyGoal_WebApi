using AutoMapper;
using Domain.Entitties;
using Core.Models.Category;
using Core.Models.Seeder;

namespace Core.Mapper
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
