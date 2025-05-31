using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entitties
{
    [Table("tbl_productImages")]
    public class ProductImageEntity: BaseEntity<long>
    {
        public string Name { get; set; } = string.Empty;
        public short Priority { get; set; }

        [ForeignKey("Product")]
        public long ProductId { get; set; }
        public ProductEntity? Product { get; set; }
    }
}
