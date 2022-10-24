using MediatR;

namespace ETicaretAPI.Application.Features.Commads.RefreshToken;

public class RefreshTokenLoginCommandRequest : IRequest<RefreshTokenLoginCommandResponse>
{
    public string RefreshToken { get; set; }
}