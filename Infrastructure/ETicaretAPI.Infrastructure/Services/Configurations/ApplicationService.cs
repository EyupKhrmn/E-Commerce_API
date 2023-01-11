using System.Reflection;
using ETicaretAPI.Application.Abstraction.Services.Configurations;
using ETicaretAPI.Application.CustomAttribute;
using ETicaretAPI.Application.DTOs.Configurations;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.Infrastructure.Services.Configurations;

public class ApplicationService : IApplicationService
{
    public List<Menu> GetAuthorizeDefinitionEndpoint(Type type)
    {
        Assembly assembly = Assembly.GetAssembly(type);
        var controllers = assembly.GetTypes().Where(t => t.IsAssignableTo((typeof(ControllerBase))));

        foreach (var controller in controllers)
        {
           var actions = controller.GetMethods().Where(m => m.IsDefined(typeof(AuthorizeDefinitionAttribute)));
        }
        return null;
    }
}