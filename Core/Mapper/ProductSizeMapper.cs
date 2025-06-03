using AutoMapper;
using Core.Models.Category;
using Core.Models.Product;
using Core.Models.Seeder;
using Domain.Entitties;

namespace Core.Mapper
{
    public class ProductSizeMapper:Profile
    {
        public ProductSizeMapper()
        {
            CreateMap<SeederProductSizeModel, ProductSizeEntity>();
            CreateMap<ProductSizeEntity, ProductSizeModel>();
        } 


    }
}
