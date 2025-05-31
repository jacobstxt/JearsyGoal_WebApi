using AutoMapper;
using Domain.Entitties;
using Core.Models.Category;
using Core.Models.Seeder;

namespace Core.Mapper
{
    public class IngridientMapper:Profile
    {
        public IngridientMapper()
        {
            CreateMap<SeederIngridientModel, IngredientEntity>();
        } 


    }
}
