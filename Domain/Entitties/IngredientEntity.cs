using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entitties.Identity;

namespace Domain.Entitties
{
    [Table("tbl_ingridients")]
    public class IngredientEntity : BaseEntity<long>
    {
        [StringLength(250)]
        public string Name { get; set; } = String.Empty;

        [StringLength(200)]
        public string Image { get; set; } = String.Empty;
        public ICollection<ProductIngredientEntity>? ProductIngredients { get; set; }

    }
}
