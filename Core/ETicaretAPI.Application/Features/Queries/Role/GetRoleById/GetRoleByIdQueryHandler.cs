using ETicaretAPI.Application.Abstraction.Services;
using ETicaretAPI.Application.Features.Queries.Role.GetRoleById;
using ETicaretAPI.Application.Features.Queries.Role.GetRoleById;
using MediatR;

namespace ETicaretAPI.Application.Features.Queries.Role.GetRoleById;

public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQueryRequest,GetRoleByIdQueryResponse>
{
    private readonly IRoleService _roleService;

    public GetRoleByIdQueryHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<GetRoleByIdQueryResponse> Handle(GetRoleByIdQueryRequest request, CancellationToken cancellationToken)
    {
       var data =  await _roleService.GetAllRolesById(request.Id);
       return new()
       {
           Id = data.id,
           Name = data.name
       };
    }
}