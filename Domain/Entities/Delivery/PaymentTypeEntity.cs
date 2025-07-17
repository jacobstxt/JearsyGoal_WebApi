using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Delivery
{
    [Table("tblPaymentTypes")]
    public class PaymentTypeEntity: BaseEntity<long>
    {
        public string Name { get; set; } = string.Empty;

        public ICollection<DeliveryInfoEntity>? DeliveryInfos { get; set; }
    }
}
