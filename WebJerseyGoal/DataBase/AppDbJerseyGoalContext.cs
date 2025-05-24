using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebJerseyGoal.DataBase.Entitties;
using WebJerseyGoal.DataBase.Entitties.Identity;

namespace WebJerseyGoal.DataBase
{
    public class AppDbJerseyGoalContext: IdentityDbContext<UserEntity, RoleEntity, long>
    {
        public AppDbJerseyGoalContext(DbContextOptions<AppDbJerseyGoalContext> opt) : base(opt) { }

        public DbSet<CategoryEntity> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserRoleEntity>(ur =>
            {
                ur.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(r => r.RoleId)
                    .IsRequired();

                ur.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(u => u.UserId)
                    .IsRequired();
            });
        }


    }

}
