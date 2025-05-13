using Microsoft.EntityFrameworkCore;
using WebJerseyGoal.DataBase.Entitties;

namespace WebJerseyGoal.DataBase
{
    public class AppDbJerseyGoalContext:DbContext
    {
        public AppDbJerseyGoalContext(DbContextOptions<AppDbJerseyGoalContext> opt) : base(opt) { }

        public DbSet<CategoryEntity> Categories { get; set; }
    }

}
