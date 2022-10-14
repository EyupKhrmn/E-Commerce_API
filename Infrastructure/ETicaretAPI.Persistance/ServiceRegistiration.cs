using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities.Identity;
using ETicaretAPI.Persistance.Contexts;
using ETicaretAPI.Persistance.Repositories;
using ETicaretAPI.Persistance.Repositories.Customer;
using ETicaretAPI.Persistance.Repositories.Order;
using ETicaretAPI.Persistance.Repositories.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ETicaretAPI.Persistance;

public static class ServiceRegistiration
{
    public static void AddPersistanceService(this IServiceCollection services)
    {
        services.AddDbContext<ETicaretApıDbContext>(options =>
            options.UseSqlServer(Configuration.connectionString));

        services.AddIdentity<AppUser, AppUserRole>(options =>
        {
            options.Password.RequiredLength = 3;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
        }).AddEntityFrameworkStores<ETicaretApıDbContext>();
        services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
        services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
        services.AddScoped<IProductReadRepository, ProductReadRepository>();
        services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
        services.AddScoped<IOrderReadRepository, OrderReadRepository>();
        services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
    }
}