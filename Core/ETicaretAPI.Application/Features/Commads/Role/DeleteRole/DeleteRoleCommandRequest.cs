using MediatR;

namespace ETicaretAPI.Application.Features.Commads.Role.DeleteRole;

public class DeleteRoleCommandRequest : IRequest<DeleteRoleCommandResponse>
{
    public string Id { get; set; }
}