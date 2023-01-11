using ETicaretAPI.Application.Abstraction.Services;
using ETicaretAPI.Application.Features.Queries.Role.GetRoles;
using MediatR;

namespace ETicaretAPI.Application.Features.Queries.Role.GetRoles;

public class GetRolesQueryHandler : IRequestHandler<GetRolesQueryRequest,GetRolesQueryResponse>
{
    private readonly IRoleService _roleService;

    public GetRolesQueryHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<GetRolesQueryResponse> Handle(GetRolesQueryRequest request, CancellationToken cancellationToken)
    {
       var datas =  _roleService.GetAllRoles(request.Page,request.Size);
       return new()
       {
           Datas = datas,
       };
    }
}