using ETicaretAPI.Application.Abstraction.Services;
using MediatR;

namespace ETicaretAPI.Application.Features.Commads.Role.CreateRole;

public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommandRequest,CreateRoleCommandResponse>
{
    private readonly IRoleService _roleService;

    public CreateRoleCommandHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<CreateRoleCommandResponse> Handle(CreateRoleCommandRequest request, CancellationToken cancellationToken)
    {
      var result =   await _roleService.CreateRole(request.Name);
      return new()
      {
          Succeded = result
      };
    }
}