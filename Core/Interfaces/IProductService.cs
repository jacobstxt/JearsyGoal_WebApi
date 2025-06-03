using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models.Product;

namespace Core.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductItemModel>> List();
        Task<ProductItemModel> GetById(int id);
        Task<List<ProductItemModel>> GetBySlug(string slug);
    }
}
