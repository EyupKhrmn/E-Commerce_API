using ETicaretAPI.API.Controllers.Base;
using ETicaretAPI.Application.Features.Commads.Role.CreateRole;
using ETicaretAPI.Application.Features.Commads.Role.DeleteRole;
using ETicaretAPI.Application.Features.Commads.Role.UpdateRole;
using ETicaretAPI.Application.Features.Queries.Role.GetRoleById;
using ETicaretAPI.Application.Features.Queries.Role.GetRoles;
using ETicaretAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;

namespace ETicaretAPI.API.Controllers;

[Authorize(AuthenticationSchemes = "Bearer")]
public class RolesController : BaseController
{
    private readonly IMediator _mediator;

    public RolesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetRoles([FromQuery]GetRolesQueryRequest getRolesQueryRequest)
    {
       GetRolesQueryResponse response = await _mediator.Send(getRolesQueryRequest);
       return Ok(response);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetRoles([FromRoute] GetRoleByIdQueryRequest getRoleByIdQueryRequest)
    {
        GetRoleByIdQueryResponse response = await _mediator.Send(getRoleByIdQueryRequest);
        return Ok(response);
    }
    
    
    [HttpPost]
    public async Task<IActionResult> CreateRole(CreateRoleCommandRequest createRoleCommandRequest)
    {
        CreateRoleCommandResponse response = await _mediator.Send(createRoleCommandRequest);
        return Ok(response);
    }
    
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRole(UpdateRoleCommandRequest updateRoleCommandRequest)
    {
        UpdateRoleCommandResponse response = await _mediator.Send(updateRoleCommandRequest);
        return Ok(response);
    }
    
    
    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteRole(DeleteRoleCommandRequest deleteRoleCommandRequest)
    {
        DeleteRoleCommandResponse response = await _mediator.Send(deleteRoleCommandRequest);
        return Ok(response);
    }
}