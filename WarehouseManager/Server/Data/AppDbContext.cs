using Microsoft.EntityFrameworkCore;
using WarehouseManager.Shared;

namespace WarehouseManager.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
        public DbSet<Product> Products { get; set; }
        
    }
}
