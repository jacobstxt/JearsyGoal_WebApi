using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Delivery
{
    [Table("tbl_Cities")]
    public class CityEntity : BaseEntity<long>
    {
        public string Name { get; set; } = string.Empty;

        public ICollection<DeliveryInfoEntity>? DeliveryInfos { get; set; }
        public ICollection<PostDepartmentEntity>? PostDepartments { get; set; }
    }
}
