using AutoMapper;
using Core.Models.Category;
using Core.Models.Product;
using Core.Models.Product.Ingredient;
using Core.Models.Seeder;
using Domain.Entitties;

namespace Core.Mapper
{
    public class IngridientMapper:Profile
    {
        public IngridientMapper()
        {
            CreateMap<SeederIngridientModel, IngredientEntity>();
            CreateMap<IngredientEntity, ProductIngridientModel>();
            CreateMap<CreateIngredientModel, IngredientEntity>()
                .ForMember(dest => dest.Image, opt => opt.Ignore());
        } 


    }
}
