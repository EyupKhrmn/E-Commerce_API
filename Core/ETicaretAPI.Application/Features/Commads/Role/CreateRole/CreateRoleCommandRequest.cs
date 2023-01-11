using MediatR;

namespace ETicaretAPI.Application.Features.Commads.Role.CreateRole;

public class CreateRoleCommandRequest : IRequest<CreateRoleCommandResponse>
{
    public string Name { get; set; }
}