using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entitties.Identity
{
    [Table("tbl_productIngridients")]
    public class ProductIngredientEntity
        {
            [ForeignKey("Product")]
            public long ProductId { get; set; }
            [ForeignKey("Ingredient")]
            public long IngredientId { get; set; }
            public virtual ProductEntity? Product { get; set; }
            public virtual IngredientEntity? Ingredient { get; set; }
        }
}
