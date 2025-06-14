using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entitties.Identity;

namespace Domain.Entitties
{
    [Table("tbl_order")]
    public class OrderEntity:BaseEntity<long>
    {
        [ForeignKey(nameof(OrderStatus))]
        public long OrderStatusId { get; set; }
        [ForeignKey(nameof(User))]
        public long UserId { get; set; }
        public OrderStatusEntity? OrderStatus { get; set; }
        public UserEntity? User { get; set; }
        public ICollection<OrderItemEntity>? OrderItems { get; set; }
    }
}
