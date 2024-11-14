using Microsoft.EntityFrameworkCore;
using ProductMagementAPI.Models;

namespace ProductMagementAPI.Data
{
    public class ProductListDbContext : DbContext
    {
        public ProductListDbContext(DbContextOptions<ProductListDbContext> options)
            : base(options) 
        {   }

        public DbSet<ProductList> ProductList { get; set; }
    }
}
