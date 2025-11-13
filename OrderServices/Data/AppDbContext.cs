using Microsoft.EntityFrameworkCore;
using OrderServices.Models;

namespace OrderServices.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Order> orders { get; set; }
        public DbSet<OrderItems> orderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItems>()
                .HasOne(p=>p.order)
                .WithMany(c => c.orderItems)
                .HasForeignKey(p=>p.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
