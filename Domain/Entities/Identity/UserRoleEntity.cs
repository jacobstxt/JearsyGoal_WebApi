using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Identity;

[Table("tbl_UserRoles")]
public class UserRoleEntity : IdentityUserRole<long>
{
    public virtual UserEntity User { get; set; }// = new();
    public virtual RoleEntity Role { get; set; }// = new();
}
