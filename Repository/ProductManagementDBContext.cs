using Microsoft.EntityFrameworkCore;
using Models;

namespace Repository
{
    public class ProductManagementDBContext : DbContext
    {
        public ProductManagementDBContext(DbContextOptions<ProductManagementDBContext> options)
            : base(options)
        {
                
        }
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
                optionsBuilder.UseInMemoryDatabase(databaseName: "ProductDb");
            
        }
    }
}
