using UserService.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace UserService.DAL.EF
{
    public class UserContext : DbContext
    {
        public DbSet<OrderDetail> orderDetails { get; set; } = null!;
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderDetailConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
