﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

[Table("tbl_ProductSizes")]
public class ProductSizeEntity : BaseEntity<long>
{
    [StringLength(250)]
    public string Name { get; set; } = String.Empty;
    public ICollection<ProductEntity>? Products { get; set; }
}
