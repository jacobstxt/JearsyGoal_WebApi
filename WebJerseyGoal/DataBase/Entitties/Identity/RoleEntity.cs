using Microsoft.AspNetCore.Identity;

namespace WebJerseyGoal.DataBase.Entitties.Identity
{
    public class RoleEntity: IdentityRole<long>
    {
        public virtual ICollection<UserRoleEntity>? UserRoles { get; set; } = null;
        public RoleEntity() : base() { }
        public RoleEntity(string roleName) : base(roleName) { }
    }
}
