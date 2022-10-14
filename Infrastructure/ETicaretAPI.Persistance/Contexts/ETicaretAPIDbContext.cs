using ETicaretAPI.Domain.Common;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ETicaretAPI.Persistance.Contexts;

public class ETicaretApıDbContext : IdentityDbContext<AppUser,AppUserRole,string>
{
    public ETicaretApıDbContext(DbContextOptions options): base(options)
    { }

    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
       var datas = ChangeTracker.Entries<BaseEntity>();
       foreach (var data in datas)
       {
           _ = data.State switch
           {
               EntityState.Added => data.Entity.CreatedDate = DateTime.Now,
               EntityState.Modified => data.Entity.ModifiedDate = DateTime.Now,
               _ => DateTime.Now
           };

       }
        return await base.SaveChangesAsync(cancellationToken);
    }
}