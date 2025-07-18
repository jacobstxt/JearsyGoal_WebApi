﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

[Table("tbl_OrderStatuses")]
public class OrderStatusEntity : BaseEntity<long>
{
    [StringLength(250)]
    public string Name { get; set; } = String.Empty;
    public ICollection<OrderEntity>? Orders { get; set; }
}
