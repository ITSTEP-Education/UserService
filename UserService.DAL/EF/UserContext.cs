using UserService.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using AdminService.DAL.EF;

namespace UserService.DAL.EF
{
    public class UserContext : DbContext
    {
        public DbSet<OrderDetail> orderDetails { get; set; } = null!;
        public DbSet<ClientOrder> clientOrders { get; set; } = null!;
        public DbSet<ClientData> clientsData { get; set; } = null!;

        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderDetailConfig());
            modelBuilder.ApplyConfiguration(new ClientOrderConfig());
            modelBuilder.ApplyConfiguration(new ClientDataConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
