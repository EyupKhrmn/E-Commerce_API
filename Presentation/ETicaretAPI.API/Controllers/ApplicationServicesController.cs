using ETicaretAPI.API.Controllers.Base;
using ETicaretAPI.Application.Abstraction.Services.Configurations;
using ETicaretAPI.Infrastructure.Services.Configurations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers;

[Authorize(AuthenticationSchemes = "Bearer")]
public class ApplicationServicesController : BaseController
{
    private readonly IApplicationService _applicationService;
    public ApplicationServicesController(ApplicationService applicationService)
    {
        _applicationService = applicationService;
    }
    
    [HttpGet]
    public IActionResult GetAuthorizeDefinitionEndpoints(Type type)
    {
        var datas =  _applicationService.GetAuthorizeDefinitionEndpoint(type);
        return Ok(datas);
    }
}