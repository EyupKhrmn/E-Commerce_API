using ETicaretAPI.Application.Features.Queries.Role.GetRoles;
using MediatR;

namespace ETicaretAPI.Application.Features.Queries.Role.GetRoles;

public class GetRolesQueryRequest : IRequest<GetRolesQueryResponse>
{
    public int Page { get; set; }
    public int Size { get; set; }
}