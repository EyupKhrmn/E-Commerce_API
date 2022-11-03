using ETicaretAPI.Application.Abstraction.Services;
using ETicaretAPI.Application.Abstraction.Token;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.Repositories.Basket;
using ETicaretAPI.Application.Repositories.BasketItem;
using ETicaretAPI.Domain.Entities.Identity;
using ETicaretAPI.Persistance.Contexts;
using ETicaretAPI.Persistance.Repositories;
using ETicaretAPI.Persistance.Repositories.Basket;
using ETicaretAPI.Persistance.Repositories.BasketItem;
using ETicaretAPI.Persistance.Repositories.Customer;
using ETicaretAPI.Persistance.Repositories.Order;
using ETicaretAPI.Persistance.Repositories.Product;
using ETicaretAPI.Persistance.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;

namespace ETicaretAPI.Persistance;

public static class ServiceRegistiration 
{
    private static readonly IServiceScopeFactory _serviceScopeFactory;
    
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
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAutService, AutService>();
        services.AddScoped<IBasketReadRepository, BasketReadRepository>();
        services.AddScoped<IBasketWriteREpository, BasketWriteRepository>();
        services.AddScoped<IBasketItemReadRepository, BasketItemReadRepository>();
        services.AddScoped<IBasketItemWriteRepository, BasketItemWriteRepository>();
        services.AddScoped<IBasketService, BasketServices>();
        
        
    }
}