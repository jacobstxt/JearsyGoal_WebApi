using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Models.Product;
using Domain.Entitties;

namespace Core.Mapper
{
    public class ProductMapper:Profile
    {
         public ProductMapper()
        {
            CreateMap<ProductImageEntity, ProductImageModel>();
            CreateMap<ProductEntity, ProductItemModel>()
                .ForMember(src => src.ProductImages, opt => opt
                    .MapFrom(x => x.ProductImages.OrderBy(p => p.Priority)))
                .ForMember(src => src.Ingridients, opt => opt
                    .MapFrom(x => x.ProductIngredients.Select(x => x.Ingredient)));



            //CreateMap<ProductImageEntity, ProductImageModel>();
            //CreateMap<ProductEntity, ProductItemModel>()
            //    .ForMember(x => x.ProductIngredients, opt => opt.MapFrom(
            //        src => src.ProductIngridients != null ?
            //        src.ProductIngridients.Where(p => p.ProductId == src.Id)
            //        .Select(p => p.Ingredient)
            //        : new List<IngredientEntity>()));
        }
    }
}
