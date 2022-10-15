using System.Reflection;
using ETicaretAPI.Application.Abstraction.Token;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ETicaretAPI.Application;

public static class ServiceRegistiraiton 
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(typeof(ServiceRegistiraiton),typeof(Assembly));
    }
}