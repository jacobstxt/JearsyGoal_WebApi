using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entitties.Identity
{
    [Table("tbl_productIngridients")]
    public class ProductIngridientEntity
        {
            [ForeignKey("Product")]
            public long ProductId { get; set; }
            [ForeignKey("Ingredient")]
            public long IngredientId { get; set; }
            public virtual ProductEntity? Product { get; set; } = new();
            public virtual IngredientEntity? Ingredient { get; set; } = new();
        }
}
