using AutoMapper;
using Domain.Entitties;
using Core.Models.Category;
using Core.Models.Seeder;

namespace Core.Mapper
{
    public class ProductSizeMapper:Profile
    {
        public ProductSizeMapper()
        {
            CreateMap<SeederProductSizeModel, ProductSizeEntity>();
        } 


    }
}
