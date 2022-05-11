using Microsoft.EntityFrameworkCore;
using NSE.Catalog.API.Models;
using NSE.Core.Data;

namespace NSE.Catalog.API.Data
{
    public class CatalogContext : DbContext, IUnitOfWork
    {
        public DbSet<Product> Products { get; set; }

        public CatalogContext(DbContextOptions<CatalogContext> options)
            : base(options) { }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var properties = modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string)));

            foreach (var property in properties)
            { 
                property.SetColumnType("varchar(100)");
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogContext).Assembly);
        }

        public async Task<bool> CommitAsync()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}
