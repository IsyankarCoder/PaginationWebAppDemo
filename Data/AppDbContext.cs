using Microsoft.EntityFrameworkCore;

namespace PaginationWebAppDemo.Data
{
    public class AppDbContext
        : DbContext
    {
        public DbSet<Product> Products { get; set; }    
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }
    }
}
