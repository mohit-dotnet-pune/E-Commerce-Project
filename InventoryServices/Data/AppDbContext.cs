using InventoryServices.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryServices.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Inventory> inventories { get; set; }
    }
}
