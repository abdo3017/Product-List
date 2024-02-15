using Microsoft.EntityFrameworkCore;
using Luftborn.InfraStructure.Configuration;
using Luftborn.InfraStructure.Entity;

namespace Luftborn.InfraStructure.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ProductsConfig).Assembly);
            base.OnModelCreating(builder);
        }

        public DbSet<Products> Products { get; set; }
    }
}
