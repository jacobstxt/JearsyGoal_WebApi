using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models.Product;
using Core.Models.Product.Ingredient;
using Domain.Entitties;

namespace Core.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductItemModel>> List();
        Task<ProductItemModel> GetById(int id);
        Task<List<ProductItemModel>> GetBySlug(string slug);
        Task<ProductEntity> Create(ProductCreateModel model);
        Task<ProductItemModel> Edit(ProductEditModel model);
        public Task<IEnumerable<ProductIngridientModel>> GetIngredientsAsync();
        public Task<IEnumerable<ProductSizeModel>> GetSizesAsync();
        Task<ProductIngridientModel> UploadIngredient(CreateIngredientModel model);
        Task  Delete(long id);
    }
}
