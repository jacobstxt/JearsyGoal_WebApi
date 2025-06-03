using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models.Category;

namespace Core.Models.Product
{
    public class ProductItemModel
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Weight { get; set; }
        public CategoryItemViewModel? Category { get; set; }
        public ProductSizeModel? ProductSize { get; set; }
        public ICollection<ProductIngridientModel>? Ingridients { get; set; }
        public ICollection<ProductImageModel>? ProductImages { get; set; }
    }
}
