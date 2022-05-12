using Microsoft.EntityFrameworkCore;
using NSE.Core.Data;
using NSE.Customers.API.Models;

namespace NSE.Customers.API.Data
{
    public class CustomerContext : DbContext, IUnitOfWork
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {            
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerContext).Assembly);
        }

        public Task<bool> CommitAsync()
        {
            throw new NotImplementedException();
        }
    }
}
