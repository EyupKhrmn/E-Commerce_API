using ETicaretAPI.Application.DTOs.Configurations;

namespace ETicaretAPI.Application.Abstraction.Services.Configurations;

public interface IApplicationService
{
    List<Menu> GetAuthorizeDefinitionEndpoint(Type type);
}