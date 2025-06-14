using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitties
{
    [Table("tbl_orderItems")]
    public class OrderItemEntity:BaseEntity<long>
    {
        public decimal PriceBuy { get; set; }
        public int Count { get; set; }
        [ForeignKey(nameof(Product))]
        public long ProductId { get; set; }
        [ForeignKey(nameof(Order))]
        public long OrderId { get; set; }
        public virtual ProductEntity? Product { get; set; }
        public virtual OrderEntity? Order { get; set; }


    }
}
