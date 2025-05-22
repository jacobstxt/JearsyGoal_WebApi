using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebJerseyGoal.DataBase.Entitties
{
    [Table("tbl_categories")]
    public class CategoryEntity:BaseEntity<long>
     {
        [StringLength(100)]
        public string Name { get; set; } = String.Empty;
        [StringLength(200)]
        public string Image { get; set; } = String.Empty;

        [StringLength(200)]
        public string Slug { get; set; } = String.Empty;

    }
}
