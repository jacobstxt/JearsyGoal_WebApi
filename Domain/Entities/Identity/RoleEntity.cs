using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Identity;

[Table("tbl_Roles")]
public class RoleEntity : IdentityRole<long>
{
    public virtual ICollection<UserRoleEntity>? UserRoles { get; set; } = null;
    public RoleEntity() : base() { }
    public RoleEntity(string roleName) : base(roleName) { }
}
