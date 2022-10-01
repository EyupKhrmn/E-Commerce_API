using ETicaretAPI.Persistance.Contexts;
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
    }
}