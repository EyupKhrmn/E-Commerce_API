using MediatR;

namespace ETicaretAPI.Application.Features.Commads.Role.UpdateRole;

public class UpdateRoleCommandRequest : IRequest<UpdateRoleCommandResponse>
{
    public string Id { get; set; }
    public string Name { get; set; }
}