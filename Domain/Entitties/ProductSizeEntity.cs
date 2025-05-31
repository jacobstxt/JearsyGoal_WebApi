using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitties
{
    [Table("tbl_productSizes")]
    public class ProductSizeEntity : BaseEntity<long>
    {
        [StringLength(250)]
        public string Name { get; set; } = String.Empty;
    }
}
