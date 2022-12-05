using Microsoft.EntityFrameworkCore;

namespace _1TlProjectAspNetCore.Web.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
