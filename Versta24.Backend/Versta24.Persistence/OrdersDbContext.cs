using Microsoft.EntityFrameworkCore;
using Versta24.Application.interfaces;
using Versta24.Domain;
using Versta24.Persistence.EntityTypeConfigurations;

namespace Versta24.Persistence
{
    public class OrdersDbContext : DbContext, IOrdersDbContext
    {
        public DbSet<Order> Orders { get; set; }
        public OrdersDbContext(DbContextOptions<OrdersDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
