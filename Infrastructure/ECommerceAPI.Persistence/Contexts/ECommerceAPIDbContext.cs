using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Domain.Entities.Common;
using ECommerceAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence.Contexts
{
    public class ECommerceAPIDbContext : IdentityDbContext<AppUser,AppRole, string>
    {
        public ECommerceAPIDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Domain.Entities.File> Files { get; set; }
        public DbSet<ProductImageFile> ProductImageFiles { get; set; }
        public DbSet<InvoiceFile> InvoiceFiles { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entityEntries = ChangeTracker
                .Entries<BaseEntity>();

            foreach (var entityEntry in entityEntries)
            {
                _ = entityEntry.State switch
                {
                    EntityState.Added => entityEntry.Entity.CreatedDate = DateTime.Now,
                    EntityState.Modified => entityEntry.Entity.UpdatedTime = DateTime.Now,
                    _ => DateTime.UtcNow

                } ;
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
