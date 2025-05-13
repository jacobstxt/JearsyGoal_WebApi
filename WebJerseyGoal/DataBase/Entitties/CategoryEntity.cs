using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace WebJerseyGoal.DataBase.Entitties
{
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
