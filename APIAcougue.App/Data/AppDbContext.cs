using APIAcougue.Models;
using Microsoft.EntityFrameworkCore;

namespace APIAcougue.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleItem> SaleItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("DataSource=app.db;Cache=Shared");
    }
}
