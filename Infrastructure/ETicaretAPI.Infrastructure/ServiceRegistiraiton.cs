using System.Reflection;
using ETicaretAPI.Application.Abstraction.Services.Configurations;
using ETicaretAPI.Application.Abstraction.Token;
using ETicaretAPI.Infrastructure.Services.Configurations;
using ETicaretAPI.Infrastructure.Services.Token;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ETicaretAPI.Infrastructure;

public static class ServiceRegistiraiton 
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<ITokenHandler, TokenHandler>();
        services.AddScoped<IApplicationService, ApplicationService>();
    }
}